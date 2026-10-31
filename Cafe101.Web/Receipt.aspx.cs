using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using Cafe101.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Cafe101.Web
{
    public partial class Receipt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int orderId;
                if (!int.TryParse(Request.QueryString["orderId"], out orderId))
                {
                    // fallback to session
                    if (Session["LastOrderID"] != null)
                        orderId = Convert.ToInt32(Session["LastOrderID"]);
                    else
                    {
                        Response.Redirect("~/CustomerDashboard.aspx");
                        return;
                    }
                }

                LoadReceipt(orderId);
                SendReceiptEmail(orderId);
            }
        }

        private void LoadReceipt(int orderId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Order header
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT OrderDateTime, PaymentMethod, TotalAmountDue, TotalChangeDue
                    FROM OrderTable 
                    WHERE OrderID = @id AND CustomerID = @cust", conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@cust", Session["UserID"]);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            Response.Redirect("~/CustomerDashboard.aspx");
                            return;
                        }

                        litOrderId.Text = orderId.ToString();
                        litOrderDate.Text = Convert.ToDateTime(r["OrderDateTime"]).ToString("dd MMM yyyy HH:mm");
                        litPaymentMethod.Text = r["PaymentMethod"].ToString();
                        litTotal.Text = Convert.ToDecimal(r["TotalAmountDue"]).ToString("0.00");

                        decimal change = Convert.ToDecimal(r["TotalChangeDue"]);
                        if (change > 0)
                        {
                            pnlChange.Visible = true;
                            litChange.Text = change.ToString("0.00");
                        }
                    }
                }

                // Order items
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT m.MenuItemName, i.QuantityOrdered AS Quantity, i.Subtotal
                    FROM ItemOrder i
                    INNER JOIN MenuItemsTable m ON m.MenuItemID = i.MenuItemID
                    WHERE i.OrderID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    rptItems.DataSource = cmd.ExecuteReader();
                    rptItems.DataBind();
                }
            }
        }

        private void SendReceiptEmail(int orderId)
        {
            try
            {
                string customerEmail = GetCustomerEmail();
                if (string.IsNullOrWhiteSpace(customerEmail))
                {
                    lblEmailStatus.Text = "Receipt ready (no email address on file).";
                    lblEmailStatus.CssClass = "text-muted";
                    return;
                }

                // Generate the PDF
                byte[] pdfBytes = GenerateReceiptPdf(orderId);

                string subject = "Your Cafe101 Receipt - Order #" + orderId;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("noreply@cafe101.co.za", "Cafe101");
                    mail.To.Add(customerEmail);
                    mail.Subject = subject;
                    mail.Body = "Thank you for your order! Please find your receipt attached.";
                    mail.IsBodyHtml = false;

                    // Attach the PDF
                    mail.Attachments.Add(new Attachment(
                        new System.IO.MemoryStream(pdfBytes),
                        $"Cafe101_Receipt_{orderId}.pdf",
                        "application/pdf"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(
                            "mayisesnakhokonke7@gmail.com",   
                            "ermv abzb oduj oomg");        
                        smtp.Send(mail);
                    }
                }

                lblEmailStatus.Text = "A PDF receipt has been sent to " + customerEmail;
                lblEmailStatus.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                // Temporary debug – remove later
                lblEmailStatus.Text = "Could not send email: " + ex.Message;
                lblEmailStatus.CssClass = "text-danger";
            }
        }
        private byte[] GenerateReceiptPdf(int orderId)
        {
            using (var ms = new MemoryStream())
            {
                // A4 page with nice margins
                var doc = new Document(PageSize.A4, 50, 50, 50, 50);
                var writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // ===== COLOURS (matching your website) =====
                var navy = new BaseColor(15, 23, 42);       // #0f172a
                var darkGray = new BaseColor(51, 65, 85);   // #334155
                var mediumGray = new BaseColor(100, 116, 139);
                var lightGray = new BaseColor(241, 245, 249);
                var green = new BaseColor(16, 185, 129);    // success green
                var white = BaseColor.WHITE;

                // ===== FONTS =====
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, navy);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, white);
                var labelFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, mediumGray);
                var valueFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, darkGray);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, darkGray);
                var totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, navy);
                var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, mediumGray);
                var thankYouFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, darkGray);

                // ===== GET DATA =====
                string orderDate = "", paymentMethod = "";
                decimal total = 0, change = 0;
                var items = new List<(string Name, int Qty, decimal Subtotal)>();

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Header info
                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT OrderDateTime, PaymentMethod, TotalAmountDue, TotalChangeDue
                FROM OrderTable WHERE OrderID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                orderDate = Convert.ToDateTime(r["OrderDateTime"]).ToString("dd MMM yyyy  HH:mm");
                                paymentMethod = r["PaymentMethod"].ToString();
                                total = Convert.ToDecimal(r["TotalAmountDue"]);
                                change = Convert.ToDecimal(r["TotalChangeDue"]);
                            }
                        }
                    }

                    // Line items
                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT m.MenuItemName, i.QuantityOrdered, i.Subtotal
                FROM ItemOrder i
                INNER JOIN MenuItemsTable m ON m.MenuItemID = i.MenuItemID
                WHERE i.OrderID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                items.Add((
                                    r["MenuItemName"].ToString(),
                                    Convert.ToInt32(r["QuantityOrdered"]),
                                    Convert.ToDecimal(r["Subtotal"])
                                ));
                            }
                        }
                    }
                }

                // ===== HEADER BAR =====
                var headerTable = new PdfPTable(1) { WidthPercentage = 100 };
                var headerCell = new PdfPCell
                {
                    BackgroundColor = navy,
                    Border = Rectangle.NO_BORDER,
                    Padding = 18f,
                    PaddingBottom = 16f
                };

                var headerInner = new PdfPTable(2) { WidthPercentage = 100 };
                headerInner.SetWidths(new float[] { 70f, 30f });

                var brandCell = new PdfPCell(new Phrase("Cafe101", titleFont))
                {
                    Border = Rectangle.NO_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                var paidCell = new PdfPCell(new Phrase("PAID", headerFont))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = green,
                    Padding = 6f,
                    PaddingLeft = 12f,
                    PaddingRight = 12f
                };

                // Make the PAID badge rounded-looking by putting it in its own small table
                var badgeTable = new PdfPTable(1);
                badgeTable.DefaultCell.Border = Rectangle.NO_BORDER;
                badgeTable.AddCell(paidCell);

                var rightCell = new PdfPCell(badgeTable)
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                headerInner.AddCell(brandCell);
                headerInner.AddCell(rightCell);
                headerCell.AddElement(headerInner);

                // Order number under brand
                headerCell.AddElement(new Paragraph($"Order #{orderId}",
                    FontFactory.GetFont(FontFactory.HELVETICA, 10, white))
                { SpacingBefore = 6f });

                headerTable.AddCell(headerCell);
                doc.Add(headerTable);

                doc.Add(new Paragraph(" ") { SpacingAfter = 8f });

                // ===== ORDER INFO =====
                var infoTable = new PdfPTable(2) { WidthPercentage = 100 };
                infoTable.SetWidths(new float[] { 50f, 50f });

                infoTable.AddCell(CreateInfoCell("Date", orderDate, labelFont, valueFont));
                infoTable.AddCell(CreateInfoCell("Payment Method", paymentMethod, labelFont, valueFont));

                doc.Add(infoTable);
                doc.Add(new Paragraph(" ") { SpacingAfter = 6f });

                // ===== ITEMS TABLE =====
                var itemsTable = new PdfPTable(3) { WidthPercentage = 100 };
                itemsTable.SetWidths(new float[] { 55f, 15f, 30f });

                // Table header
                itemsTable.AddCell(CreateHeaderCell("Item", boldFont, lightGray));
                itemsTable.AddCell(CreateHeaderCell("Qty", boldFont, lightGray, Element.ALIGN_CENTER));
                itemsTable.AddCell(CreateHeaderCell("Amount", boldFont, lightGray, Element.ALIGN_RIGHT));

                // Items
                foreach (var item in items)
                {
                    itemsTable.AddCell(CreateItemCell(item.Name, valueFont));
                    itemsTable.AddCell(CreateItemCell(item.Qty.ToString(), valueFont, Element.ALIGN_CENTER));
                    itemsTable.AddCell(CreateItemCell("R " + item.Subtotal.ToString("0.00"), valueFont, Element.ALIGN_RIGHT));
                }

                doc.Add(itemsTable);

                // ===== TOTALS =====
                doc.Add(new Paragraph(" ") { SpacingAfter = 10f });

                var totalTable = new PdfPTable(2) { WidthPercentage = 100 };
                totalTable.SetWidths(new float[] { 70f, 30f });

                totalTable.AddCell(new PdfPCell(new Phrase("Total", totalFont))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    PaddingRight = 12f
                });
                totalTable.AddCell(new PdfPCell(new Phrase("R " + total.ToString("0.00"), totalFont))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                if (change > 0)
                {
                    totalTable.AddCell(new PdfPCell(new Phrase("Change Due", labelFont))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        PaddingRight = 12f,
                        PaddingTop = 4f
                    });
                    totalTable.AddCell(new PdfPCell(new Phrase("R " + change.ToString("0.00"), valueFont))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        PaddingTop = 4f
                    });
                }

                doc.Add(totalTable);

                // ===== FOOTER =====
                doc.Add(new Paragraph(" ") { SpacingAfter = 25f });

                var line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.5f, 100f, lightGray, Element.ALIGN_CENTER, -2)))
                { SpacingAfter = 15f };
                doc.Add(line);

                var thankYou = new Paragraph("Thank you for dining with us!", thankYouFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(thankYou);

                var footer = new Paragraph("Cafe101  •  Freshly made with love", smallFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 6f
                };
                doc.Add(footer);

                var generated = new Paragraph($"Generated on {DateTime.Now:dd MMM yyyy HH:mm}", smallFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 4f
                };
                doc.Add(generated);

                doc.Close();
                return ms.ToArray();
            }
        }

        // ===== HELPER METHODS (put these inside the Receipt class) =====

        private PdfPCell CreateInfoCell(string label, string value, Font labelFont, Font valueFont)
        {
            var cell = new PdfPCell { Border = Rectangle.NO_BORDER, PaddingBottom = 8f };
            cell.AddElement(new Paragraph(label, labelFont));
            cell.AddElement(new Paragraph(value, valueFont));
            return cell;
        }

        private PdfPCell CreateHeaderCell(string text, Font font, BaseColor bg, int align = Element.ALIGN_LEFT)
        {
            return new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = bg,
                Border = Rectangle.NO_BORDER,
                Padding = 8f,
                HorizontalAlignment = align
            };
        }

        private PdfPCell CreateItemCell(string text, Font font, int align = Element.ALIGN_LEFT)
        {
            return new PdfPCell(new Phrase(text, font))
            {
                Border = Rectangle.NO_BORDER,
                BorderWidthBottom = 0.5f,
                BorderColorBottom = new BaseColor(226, 232, 240),
                Padding = 8f,
                HorizontalAlignment = align
            };
        }

        private string GetCustomerEmail()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Email FROM CustomerTable WHERE CustomerID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", Session["UserID"]);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? null : result.ToString();
            }
        }

        private string BuildEmailBody(int orderId)
        {
            // Simple HTML email – you can make this prettier later
            return $@"
                <h2>Cafe101 Receipt</h2>
                <p>Thank you for your order!</p>
                <p><strong>Order #:</strong> {orderId}</p>
                <p>You can view your full receipt by logging into your account.</p>
                <br/>
                <p>Cafe101 Team</p>";
        }
    }
}