using Cafe101.Logic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace Cafe101.Web
{
    public static class ReportPdfBuilder
    {
        private static readonly Color Navy = Color.FromRgb(27, 42, 74);
        private static readonly Color Dark = Color.FromRgb(30, 41, 59);
        private static readonly Color Grey = Color.FromRgb(110, 120, 135);
        private static readonly Color Line = Color.FromRgb(226, 230, 236);
        private static readonly Color Light = Color.FromRgb(243, 245, 249);

        // Builds the whole report and returns it as PDF bytes
        public static byte[] Build(string range, string rangeLabel, string preparedFor)
        {
            var service = new ReportService();
            var summary = service.GetSummaryByDateRange(range);
            var revenue = service.GetRevenueTrend(range);
            var category = service.GetSalesByCategory(range);
            var popular = service.GetPopularItems(range);
            var staff = service.GetStaffPerformance(range);
            var lowStock = service.GetLowStock();

            Document doc = new Document();
            doc.Info.Title = "Cafe101 Business Report";
            doc.Info.Author = "Cafe101 Manager System";

            Style normal = doc.Styles[StyleNames.Normal];
            normal.Font.Name = "Arial";
            normal.Font.Size = 10;
            normal.Font.Color = Dark;

            Section sec = doc.AddSection();
            sec.PageSetup.PageFormat = PageFormat.A4;
            sec.PageSetup.LeftMargin = Unit.FromCentimeter(2);
            sec.PageSetup.RightMargin = Unit.FromCentimeter(2);
            sec.PageSetup.TopMargin = Unit.FromCentimeter(1.8);
            sec.PageSetup.BottomMargin = Unit.FromCentimeter(2);

            AddFooter(sec);
            AddHeader(sec, rangeLabel, preparedFor);
            AddSummaryBoxes(sec, summary);

            // ---- Revenue ----
            SectionTitle(sec, "Revenue Overview",
                range == "AllTime" ? "Completed orders, by month" : "Completed orders, by day");

            if (revenue.Labels.Count == 0)
            {
                EmptyNote(sec);
            }
            else
            {
                Table t = DataTable(sec, new[] { "Period", "Revenue" }, new[] { 10.0, 7.0 }, new[] { false, true });
                for (int i = 0; i < revenue.Labels.Count; i++)
                    AddRow(t, i, revenue.Labels[i], Money(revenue.Values[i]));

                Row total = AddRow(t, 0, "Total", Money(revenue.Values.Sum()));
                total.Format.Font.Bold = true;
                total.Shading.Color = Light;
            }

            // ---- Sales by category ----
            SectionTitle(sec, "Sales by Category", "Share of sales across menu categories");

            if (category.Labels.Count == 0)
            {
                EmptyNote(sec);
            }
            else
            {
                decimal sum = category.Values.Sum();
                Table t = DataTable(sec, new[] { "Category", "Sales", "Share" }, new[] { 8.0, 5.0, 4.0 }, new[] { false, true, true });
                for (int i = 0; i < category.Labels.Count; i++)
                {
                    decimal share = sum == 0 ? 0 : category.Values[i] / sum * 100;
                    AddRow(t, i, category.Labels[i], Money(category.Values[i]), share.ToString("0.0") + "%");
                }
            }

            // ---- Popular items ----
            SectionTitle(sec, "Popular Items", "Top selling menu items by quantity");

            if (popular.Count == 0)
            {
                EmptyNote(sec);
            }
            else
            {
                Table t = DataTable(sec, new[] { "#", "Item", "Category", "Qty Sold" }, new[] { 1.5, 7.5, 5.0, 3.0 }, new[] { false, false, false, true });
                for (int i = 0; i < popular.Count; i++)
                    AddRow(t, i, (i + 1).ToString(), popular[i].Name, popular[i].Category, popular[i].Quantity.ToString());
            }

            // ---- Staff performance ----
            SectionTitle(sec, "Staff Performance", "Completed orders handled per staff member");

            if (staff.Labels.Count == 0)
            {
                EmptyNote(sec);
            }
            else
            {
                Table t = DataTable(sec, new[] { "Staff Member", "Orders Handled" }, new[] { 10.0, 7.0 }, new[] { false, true });
                for (int i = 0; i < staff.Labels.Count; i++)
                    AddRow(t, i, staff.Labels[i], staff.Values[i].ToString("0"));
            }

            // ---- Low stock ----
            SectionTitle(sec, "Low Stock Alerts", "Ingredients at or below their restock level (current stock)");

            if (lowStock.Count == 0)
            {
                Paragraph ok = sec.AddParagraph("All stock levels are healthy.");
                ok.Format.Font.Color = Grey;
            }
            else
            {
                Table t = DataTable(sec, new[] { "Ingredient", "In Stock", "Status" }, new[] { 8.0, 5.0, 4.0 }, new[] { false, true, true });
                for (int i = 0; i < lowStock.Count; i++)
                {
                    Row r = AddRow(t, i, lowStock[i].Name, lowStock[i].Quantity.ToString("0.##"), lowStock[i].Level);
                    r.Cells[2].Format.Font.Bold = true;
                    r.Cells[2].Format.Font.Color = LevelColor(lowStock[i].Level);
                }
            }

            // ---- Render ----
            PdfDocumentRenderer renderer = new PdfDocumentRenderer { Document = doc };
            renderer.RenderDocument();

            using (MemoryStream ms = new MemoryStream())
            {
                renderer.PdfDocument.Save(ms, false);
                return ms.ToArray();
            }
        }

        // -------------------- Layout pieces --------------------

        private static void AddHeader(Section sec, string rangeLabel, string preparedFor)
        {
            Table t = sec.AddTable();
            t.Borders.Visible = false;
            t.AddColumn(Unit.FromCentimeter(9));
            t.AddColumn(Unit.FromCentimeter(8));

            Row r = t.AddRow();
            r.Height = Unit.FromCentimeter(2.3);
            r.VerticalAlignment = VerticalAlignment.Center;
            r.Shading.Color = Navy;

            Paragraph brand = r.Cells[0].AddParagraph("Cafe101");
            brand.Format.Font.Size = 22;
            brand.Format.Font.Bold = true;
            brand.Format.Font.Color = Colors.White;
            brand.Format.LeftIndent = Unit.FromCentimeter(0.6);

            Paragraph title = r.Cells[1].AddParagraph("Business Report");
            title.Format.Alignment = ParagraphAlignment.Right;
            title.Format.Font.Size = 14;
            title.Format.Font.Bold = true;
            title.Format.Font.Color = Colors.White;
            title.Format.RightIndent = Unit.FromCentimeter(0.6);

            Paragraph period = r.Cells[1].AddParagraph(rangeLabel);
            period.Format.Alignment = ParagraphAlignment.Right;
            period.Format.Font.Size = 9;
            period.Format.Font.Color = Color.FromRgb(203, 213, 225);
            period.Format.RightIndent = Unit.FromCentimeter(0.6);

            Paragraph info = sec.AddParagraph(
                "Prepared for: " + preparedFor + "     |     Generated: " + DateTime.Now.ToString("dd MMMM yyyy, HH:mm"));
            info.Format.Font.Size = 8.5;
            info.Format.Font.Color = Grey;
            info.Format.SpaceBefore = Unit.FromCentimeter(0.3);
            info.Format.SpaceAfter = Unit.FromCentimeter(0.4);
        }

        private static void AddSummaryBoxes(Section sec, ReportSummary s)
        {
            Table t = sec.AddTable();
            t.Borders.Color = Colors.White;
            t.Borders.Width = Unit.FromPoint(5);
            t.LeftPadding = Unit.FromCentimeter(0.4);
            t.TopPadding = Unit.FromCentimeter(0.3);
            t.BottomPadding = Unit.FromCentimeter(0.3);

            for (int i = 0; i < 3; i++)
                t.AddColumn(Unit.FromCentimeter(17.0 / 3));

            Row r = t.AddRow();
            r.Shading.Color = Light;
            r.Height = Unit.FromCentimeter(2);
            r.VerticalAlignment = VerticalAlignment.Center;

            SummaryCell(r.Cells[0], "TOTAL REVENUE", Money(s.TotalRevenue));
            SummaryCell(r.Cells[1], "ORDERS COMPLETED", s.CompletedOrders.ToString());
            SummaryCell(r.Cells[2], "AVERAGE ORDER VALUE", Money(s.AverageOrderValue));
        }

        private static void SummaryCell(Cell cell, string label, string value)
        {
            Paragraph l = cell.AddParagraph(label);
            l.Format.Font.Size = 7.5;
            l.Format.Font.Color = Grey;
            l.Format.Font.Bold = true;

            Paragraph v = cell.AddParagraph(value);
            v.Format.Font.Size = 16;
            v.Format.Font.Bold = true;
            v.Format.Font.Color = Navy;
            v.Format.SpaceBefore = Unit.FromPoint(3);
        }

        private static void SectionTitle(Section sec, string title, string subtitle)
        {
            Paragraph p = sec.AddParagraph(title);
            p.Format.Font.Size = 13;
            p.Format.Font.Bold = true;
            p.Format.Font.Color = Navy;
            p.Format.SpaceBefore = Unit.FromCentimeter(0.8);
            p.Format.SpaceAfter = Unit.FromPoint(2);
            p.Format.KeepWithNext = true;

            Paragraph s = sec.AddParagraph(subtitle);
            s.Format.Font.Size = 8.5;
            s.Format.Font.Color = Grey;
            s.Format.SpaceAfter = Unit.FromCentimeter(0.25);
            s.Format.KeepWithNext = true;
        }

        private static Table DataTable(Section sec, string[] headers, double[] widthsCm, bool[] rightAlign)
        {
            Table t = sec.AddTable();
            t.Borders.Color = Line;
            t.Borders.Width = Unit.FromPoint(0.5);
            t.Borders.Left.Visible = false;
            t.Borders.Right.Visible = false;
            t.LeftPadding = Unit.FromCentimeter(0.25);
            t.RightPadding = Unit.FromCentimeter(0.25);

            for (int i = 0; i < widthsCm.Length; i++)
            {
                Column c = t.AddColumn(Unit.FromCentimeter(widthsCm[i]));
                c.Format.Alignment = rightAlign[i] ? ParagraphAlignment.Right : ParagraphAlignment.Left;
            }

            Row h = t.AddRow();
            h.HeadingFormat = true;
            h.Height = Unit.FromCentimeter(0.8);
            h.VerticalAlignment = VerticalAlignment.Center;
            h.Shading.Color = Navy;
            h.Format.Font.Bold = true;
            h.Format.Font.Color = Colors.White;
            h.Format.Font.Size = 9;

            for (int i = 0; i < headers.Length; i++)
                h.Cells[i].AddParagraph(headers[i]);

            return t;
        }

        private static Row AddRow(Table t, int index, params string[] cells)
        {
            Row r = t.AddRow();
            r.Height = Unit.FromCentimeter(0.75);
            r.VerticalAlignment = VerticalAlignment.Center;
            if (index % 2 == 1) r.Shading.Color = Light;

            for (int i = 0; i < cells.Length; i++)
                r.Cells[i].AddParagraph(cells[i] ?? "");

            return r;
        }

        private static void EmptyNote(Section sec)
        {
            Paragraph p = sec.AddParagraph("No data for this period.");
            p.Format.Font.Color = Grey;
        }

        private static void AddFooter(Section sec)
        {
            Paragraph f = sec.Footers.Primary.AddParagraph();
            f.Format.Alignment = ParagraphAlignment.Center;
            f.Format.Font.Size = 8;
            f.Format.Font.Color = Grey;
            f.AddText("Cafe101 Manager System  |  Confidential  |  Page ");
            f.AddPageField();
            f.AddText(" of ");
            f.AddNumPagesField();
        }

        private static Color LevelColor(string level)
        {
            switch (level)
            {
                case "Critical": return Color.FromRgb(155, 28, 28);
                case "High": return Color.FromRgb(154, 52, 18);
                case "Medium": return Color.FromRgb(146, 64, 14);
                default: return Color.FromRgb(30, 64, 175);
            }
        }

        private static string Money(decimal value)
        {
            return "R " + value.ToString("N2");
        }
    }
}