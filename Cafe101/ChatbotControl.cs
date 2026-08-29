using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class ChatbotControl : UserControl
    {
        private Button btnToggle;
        private Form chatForm;
        private bool isOpen = false;
        private TextBox txtInput;
        private Panel pnlChatArea;
        private Button btnSend;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlInput;
        private PictureBox picAvatar;
        private Label lblPlaceholder;
        private FlowLayoutPanel flowChat;
        private bool initialized = false;

        public bool IsChatOpen => isOpen;

        public ChatbotControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing component: {ex.Message}", "Initialization Error");
                return;
            }

            if (!initialized)
            {
                BuildChatbot();
                initialized = true;
            }

            this.Visible = true;
            this.BringToFront();
        }

        private void BuildChatbot()
        {
            this.Size = new Size(70, 70);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            btnToggle = new Button
            {
                Text = "",
                BackColor = Color.Transparent,
                ForeColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(70, 70),
                Location = new Point(0, 0),
                Cursor = Cursors.Hand,
                Visible = true
            };
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnToggle.Click += (s, e) => ToggleChat();

            if (!this.Controls.Contains(btnToggle))
                this.Controls.Add(btnToggle);

            this.Paint -= PaintChatbotButton;
            this.Paint += PaintChatbotButton;
        }

        private void PaintChatbotButton(object sender, PaintEventArgs e)
        {
            if (btnToggle == null || !btnToggle.Visible || btnToggle.Width <= 0 || btnToggle.Height <= 0)
            {
                e.Graphics.Clear(Color.Transparent);
                return;
            }

            try
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var brush = new SolidBrush(Color.FromArgb(25, 118, 210)))
                    g.FillEllipse(brush, 2, 2, 66, 66);

                var rect = new Rectangle(18, 18, 35, 28);
                using (var path = RoundedRect(rect, 8))
                using (var brush = new SolidBrush(Color.White))
                    g.FillPath(brush, path);

                PointF[] tail = { new PointF(28, 46), new PointF(33, 53), new PointF(38, 46) };
                using (var brush = new SolidBrush(Color.White))
                    g.FillPolygon(brush, tail);

                using (var brush = new SolidBrush(Color.FromArgb(25, 118, 210)))
                {
                    g.FillEllipse(brush, 28, 28, 5, 5);
                    g.FillEllipse(brush, 36, 28, 5, 5);
                    g.FillEllipse(brush, 44, 28, 5, 5);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Paint error: {ex.Message}");
            }
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ToggleChat()
        {
            if (isOpen) CloseChat();
            else OpenChat();
        }

        private void OpenChat()
        {
            try
            {
                if (chatForm != null && !chatForm.IsDisposed)
                {
                    chatForm.Close();
                    chatForm.Dispose();
                }

                chatForm = new Form
                {
                    Text = "",
                    Size = new Size(420, 600),
                    StartPosition = FormStartPosition.Manual,
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor = Color.White,
                    TopMost = true,
                    ShowInTaskbar = false,
                    ShowIcon = false
                };

                var wa = Screen.PrimaryScreen.WorkingArea;
                chatForm.Location = new Point(
                    Math.Max(0, wa.Width - chatForm.Width - 20),
                    Math.Max(0, (wa.Height - chatForm.Height) / 2));

                bool dragging = false;
                Point dragStart = Point.Empty;

                Action<Control> enableDrag = c =>
                {
                    c.MouseDown += (s, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            dragging = true;
                            dragStart = e.Location;
                        }
                    };
                    c.MouseMove += (s, e) =>
                    {
                        if (dragging)
                        {
                            chatForm.Location = new Point(
                                chatForm.Left + e.X - dragStart.X,
                                chatForm.Top + e.Y - dragStart.Y);
                        }
                    };
                    c.MouseUp += (s, e) => dragging = false;
                };

                enableDrag(chatForm);

                var pnlMain = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Padding = Padding.Empty,
                    Margin = Padding.Empty
                };
                enableDrag(pnlMain);

                pnlHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 85,
                    BackColor = Color.FromArgb(25, 118, 210),
                    Padding = new Padding(15, 10, 15, 10)
                };
                enableDrag(pnlHeader);

                picAvatar = new PictureBox
                {
                    Size = new Size(50, 50),
                    Location = new Point(15, 18),
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                var avatarBmp = new Bitmap(50, 50);
                using (var g = Graphics.FromImage(avatarBmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var b = new SolidBrush(Color.White))
                        g.FillEllipse(b, 0, 0, 50, 50);
                    using (var f = new Font("Segoe UI Emoji", 26f))
                        TextRenderer.DrawText(g, "🤖", f,
                            new Rectangle(0, 2, 50, 50),
                            Color.FromArgb(25, 118, 210),
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                picAvatar.Image = avatarBmp;
                pnlHeader.Controls.Add(picAvatar);

                lblTitle = new Label
                {
                    Text = "Chat with us!",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(78, 18),
                    AutoSize = true
                };
                pnlHeader.Controls.Add(lblTitle);

                var pnlStatus = new Panel
                {
                    Size = new Size(10, 10),
                    Location = new Point(78, 48),
                    BackColor = Color.Transparent
                };
                pnlStatus.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var b = new SolidBrush(Color.FromArgb(76, 175, 80)))
                        e.Graphics.FillEllipse(b, 0, 0, 10, 10);
                };
                pnlHeader.Controls.Add(pnlStatus);

                lblSub = new Label
                {
                    Text = "Online • Usually replies instantly",
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.FromArgb(200, 230, 255),
                    Location = new Point(94, 46),
                    AutoSize = true
                };
                pnlHeader.Controls.Add(lblSub);

                btnClose = new Button
                {
                    Text = "✕",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(38, 38),
                    Location = new Point(367, 24),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => CloseChat();
                btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(211, 47, 47);
                btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;
                pnlHeader.Controls.Add(btnClose);

                pnlChatArea = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(247, 249, 252),
                    AutoScroll = true,
                    Padding = Padding.Empty
                };

                flowChat = new FlowLayoutPanel
                {
                    AutoScroll = false,
                    BackColor = Color.FromArgb(247, 249, 252),
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(12, 16, 12, 20),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Width = 380
                };
                pnlChatArea.Controls.Add(flowChat);

                pnlInput = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 70,
                    BackColor = Color.White,
                    Padding = new Padding(12, 10, 12, 10)
                };

                var pnlBorder = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 1,
                    BackColor = Color.FromArgb(220, 225, 235)
                };
                pnlInput.Controls.Add(pnlBorder);

                txtInput = new TextBox
                {
                    Location = new Point(12, 15),
                    Size = new Size(280, 40),
                    Font = new Font("Segoe UI Emoji", 10.5f),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(247, 249, 252),
                    ForeColor = Color.FromArgb(60, 60, 70)
                };
                txtInput.KeyPress += (s, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        e.Handled = true;
                        SendMessage();
                    }
                };

                lblPlaceholder = new Label
                {
                    Text = "Type your message...",
                    Font = new Font("Segoe UI", 10.5f),
                    ForeColor = Color.Gray,
                    BackColor = Color.Transparent,
                    Location = new Point(20, 24),
                    AutoSize = true
                };

                txtInput.TextChanged += (s, e) =>
                    lblPlaceholder.Visible = string.IsNullOrEmpty(txtInput.Text);

                btnSend = new Button
                {
                    Text = "Send",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(25, 118, 210),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(80, 40),
                    Location = new Point(303, 15),
                    Cursor = Cursors.Hand
                };
                btnSend.FlatAppearance.BorderSize = 0;
                btnSend.Click += (s, e) => SendMessage();
                btnSend.MouseEnter += (s, e) => btnSend.BackColor = Color.FromArgb(30, 136, 229);
                btnSend.MouseLeave += (s, e) => btnSend.BackColor = Color.FromArgb(25, 118, 210);

                pnlInput.Controls.Add(txtInput);
                pnlInput.Controls.Add(lblPlaceholder);
                pnlInput.Controls.Add(btnSend);

                pnlMain.Controls.Add(pnlHeader);
                pnlMain.Controls.Add(pnlInput);
                pnlMain.Controls.Add(pnlChatArea);
                chatForm.Controls.Add(pnlMain);

                chatForm.FormClosed += (s, e) =>
                {
                    isOpen = false;
                    if (btnToggle != null && !btnToggle.IsDisposed)
                    {
                        btnToggle.Visible = true;
                        btnToggle.Location = new Point(0, 0);
                        btnToggle.Size = new Size(70, 70);
                    }
                    this.Invalidate();
                    this.BringToFront();
                };

                chatForm.Shown += (s, e) =>
                {
                    chatForm.Activate();
                    AddWelcomeMessage();
                    txtInput.Focus();
                };

                chatForm.Show();

                btnToggle.Visible = false;
                btnToggle.Location = new Point(-100, -100);
                btnToggle.Size = new Size(0, 0);

                isOpen = true;
                this.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening chat: {ex.Message}", "Error");
                isOpen = false;
            }
        }

        private void CloseChat()
        {
            try
            {
                if (chatForm != null && !chatForm.IsDisposed)
                {
                    if (picAvatar?.Image != null)
                    {
                        picAvatar.Image.Dispose();
                        picAvatar.Image = null;
                    }

                    chatForm.Close();
                    chatForm.Dispose();
                }

                chatForm = null;
                pnlHeader = null;
                pnlChatArea = null;
                pnlInput = null;
                picAvatar = null;
                txtInput = null;
                btnClose = null;
                btnSend = null;
                lblTitle = null;
                lblSub = null;
                lblPlaceholder = null;
                flowChat = null;

                isOpen = false;

                if (btnToggle != null && !btnToggle.IsDisposed)
                {
                    btnToggle.Visible = true;
                    btnToggle.Location = new Point(0, 0);
                    btnToggle.Size = new Size(70, 70);
                }

                this.Invalidate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error closing chat: {ex.Message}");
                isOpen = false;
            }
        }

        private void AddWelcomeMessage()
        {
            if (flowChat == null || flowChat.IsDisposed) return;

            flowChat.Controls.Clear();

            var spacer = new Panel
            {
                Height = 60,
                Width = 1,
                BackColor = Color.Transparent
            };
            flowChat.Controls.Add(spacer);

            string welcome =
                "Good day! 😊\n\n" +
                "I am Cafe101 Bot, your friendly online support. 🤖\n\n" +
                "Welcome! How may I assist you today? 🎉";

            AddMessage(welcome, true);
        }

        private void AddMessage(string message, bool isBot)
        {
            if (flowChat == null || flowChat.IsDisposed) return;

            int availableWidth = Math.Max(220, flowChat.ClientSize.Width - 24);
            int bubbleMaxWidth = Math.Max(180, availableWidth - 60);

            var textFont = new Font("Segoe UI Emoji", 10f);
            var textSize = TextRenderer.MeasureText(
                message, textFont,
                new Size(bubbleMaxWidth - 28, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

            var pnlMessage = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.FromArgb(247, 249, 252),
                Width = availableWidth,
                Margin = new Padding(0, 4, 0, 12),
                Padding = new Padding(0)
            };

            var bubble = new Panel
            {
                AutoSize = false,
                Size = new Size(textSize.Width + 28, textSize.Height + 22),
                BackColor = isBot ? Color.White : Color.FromArgb(25, 118, 210),
                Padding = new Padding(14, 11, 14, 11)
            };

            bubble.Paint += (s, e) =>
            {
                try
                {
                    if (bubble.Width < 20 || bubble.Height < 20) return;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, bubble.Width - 1, bubble.Height - 1);
                    using (var path = RoundedRect(rect, 16))
                    {
                        bubble.Region = new Region(path);
                        if (isBot)
                        {
                            using (var pen = new Pen(Color.FromArgb(220, 225, 230), 1))
                                e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
                catch { /* ignore paint errors */ }
            };

            var lblText = new Label
            {
                Text = message,
                Font = textFont,
                ForeColor = isBot ? Color.FromArgb(45, 45, 55) : Color.White,
                AutoSize = false,
                Size = textSize,
                TextAlign = ContentAlignment.TopLeft
            };
            bubble.Controls.Add(lblText);

            var lblEmoji = new Label
            {
                Text = isBot ? "🤖" : "👤",
                Font = new Font("Segoe UI Emoji", 16f),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTime = new Label
            {
                Text = DateTime.Now.ToString("HH:mm"),
                Font = new Font("Segoe UI", 7.5f, FontStyle.Italic),
                ForeColor = isBot ? Color.FromArgb(150, 160, 170) : Color.FromArgb(200, 220, 240),
                AutoSize = true
            };

            var tbl = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = Color.Transparent,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            if (isBot)
            {
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                tbl.Controls.Add(lblEmoji, 0, 0);
                tbl.Controls.Add(bubble, 1, 0);
                tbl.Controls.Add(lblTime, 1, 1);
                lblEmoji.Margin = new Padding(0, 6, 8, 0);
                lblTime.Margin = new Padding(4, 2, 0, 0);
            }
            else
            {
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tbl.Controls.Add(bubble, 0, 0);
                tbl.Controls.Add(lblEmoji, 1, 0);
                tbl.Controls.Add(lblTime, 0, 1);
                lblEmoji.Margin = new Padding(8, 6, 0, 0);
                lblTime.Margin = new Padding(0, 2, 4, 0);
                lblTime.TextAlign = ContentAlignment.MiddleRight;
                lblTime.Dock = DockStyle.Right;
            }

            pnlMessage.Controls.Add(tbl);
            flowChat.Controls.Add(pnlMessage);

            flowChat.PerformLayout();
            if (flowChat.Controls.Count > 0)
            {
                var last = flowChat.Controls[flowChat.Controls.Count - 1];
                flowChat.ScrollControlIntoView(last);
            }

            if (pnlChatArea != null && pnlChatArea.VerticalScroll.Visible)
                pnlChatArea.VerticalScroll.Value = pnlChatArea.VerticalScroll.Maximum;
        }

        private void SendMessage()
        {
            if (txtInput == null || flowChat == null || flowChat.IsDisposed) return;

            string input = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            try
            {
                AddMessage(input, false);
                string response = GetBotResponse(input);
                AddMessage(response, true);

                txtInput.Text = "";
                lblPlaceholder.Visible = true;
                txtInput.Focus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Send message error: {ex.Message}");
            }
        }

        private string GetBotResponse(string input)
        {
            string lower = input.ToLowerInvariant();

            // ============================================================
            // HOW TO - MANAGE MENU ITEMS
            // ============================================================
            if (lower.Contains("menu item") || lower.Contains("manage menu") || lower.Contains("add menu") ||
                lower.Contains("update menu") || lower.Contains("delete menu"))
            {
                if (lower.Contains("add") || lower.Contains("create") || lower.Contains("new"))
                {
                    return "📝 **How to Add a Menu Item:**\n\n" +
                           "1. Ensure no item is selected (check that 'Update' button shows no selection)\n" +
                           "2. Fill in all fields in 'Menu Item Details':\n" +
                           "   • Item Name: Letters and spaces only\n" +
                           "   • Selling Price: Greater than 0\n" +
                           "   • Cost Price: Greater than 0\n" +
                           "   • Category: Select from dropdown (Burger, Wings, Sides, Drinks, Combo)\n" +
                           "   • Preparation Time: Numbers only (1-999)\n" +
                           "3. Click the 'Add New' button\n" +
                           "4. Success message appears, grid refreshes automatically\n\n" +
                           "⚠️ **Important:** You do NOT need to add a recipe first.\n" +
                           "   Menu items can be added independently.\n\n" +
                           "📋 **Recommended Workflow:**\n" +
                           "   1️⃣ Add the menu item (this form)\n" +
                           "   2️⃣ Add ingredients (Manage Ingredients)\n" +
                           "   3️⃣ Link them together (Manage Recipes)";
                }
                else if (lower.Contains("update") || lower.Contains("edit") || lower.Contains("change"))
                {
                    return "📝 **How to Update a Menu Item:**\n\n" +
                           "1. Click any row in the grid to select a menu item\n" +
                           "2. Fields will populate with the selected item's data\n" +
                           "3. Make your changes to any field\n" +
                           "4. Click the 'Update' button\n" +
                           "5. Confirm the success message\n\n" +
                           "Note: Name must be unique - duplicate names are blocked";
                }
                else if (lower.Contains("delete") || lower.Contains("remove") || lower.Contains("deactivate"))
                {
                    return "📝 **How to Delete a Menu Item:**\n\n" +
                           "1. Click any row in the grid to select a menu item\n" +
                           "2. Click the 'Deactivate' button\n" +
                           "3. Confirm deletion when prompted: 'Remove this menu item from the database? This action cannot be undone.'\n" +
                           "4. Click 'Yes' to delete permanently\n" +
                           "5. Confirmation message appears and grid refreshes\n\n" +
                           "⚠️ Warning: This is a permanent DELETE operation. Data cannot be recovered!";
                }
                else
                {
                    return "📝 **Menu Item Management:**\n\n" +
                           "I can help you with:\n" +
                           "• How to add a menu item\n" +
                           "• How to update a menu item\n" +
                           "• How to delete a menu item\n\n" +
                           "Just ask me something like 'how to add a menu item'";
                }
            }

            // ============================================================
            // HOW TO - MANAGE RECIPES
            // ============================================================
            if (lower.Contains("recipe") || lower.Contains("manage recipe") || lower.Contains("add recipe") ||
                lower.Contains("remove recipe") || lower.Contains("recipe link"))
            {
                if (lower.Contains("add") || lower.Contains("create") || lower.Contains("link"))
                {
                    return "🍳 **How to Add a Recipe Link:**\n\n" +
                           "1. Select a Menu Item from the first dropdown\n" +
                           "2. Select an Ingredient from the second dropdown\n" +
                           "3. Enter the Quantity needed (must be greater than 0)\n" +
                           "4. Click the 'Add' button\n" +
                           "5. Success message appears, grid refreshes\n\n" +
                           "Example: Chicken Burger + Chicken Wings + 2 = recipe link created\n\n" +
                           "⚠️ **Note:** You must add the menu item first before you can link it to ingredients.\n" +
                           "   Menu items are added in the Manage Menu Items form.";
                }
                else if (lower.Contains("remove") || lower.Contains("delete") || lower.Contains("unlink"))
                {
                    return "🍳 **How to Remove a Recipe Link:**\n\n" +
                           "1. Either click a row in the grid to auto-select, OR\n" +
                           "2. Manually select a Menu Item and Ingredient from dropdowns\n" +
                           "3. Click the 'Remove' button\n" +
                           "4. Confirm deletion when prompted\n" +
                           "5. Click 'Yes' to delete permanently\n" +
                           "6. Confirmation message appears and grid refreshes\n\n" +
                           "⚠️ Note: To change quantity, remove the link then add with new quantity";
                }
                else
                {
                    return "🍳 **Recipe Management:**\n\n" +
                           "I can help you with:\n" +
                           "• How to add a recipe link\n" +
                           "• How to remove a recipe link\n\n" +
                           "Just ask me something like 'how to add a recipe'";
                }
            }

            // ============================================================
            // HOW TO - MANAGE INGREDIENTS
            // ============================================================
            if (lower.Contains("ingredient") || lower.Contains("manage ingredient") || lower.Contains("add ingredient") ||
                lower.Contains("update ingredient") || lower.Contains("delete ingredient") || lower.Contains("stock"))
            {
                if (lower.Contains("add") || lower.Contains("create") || lower.Contains("new"))
                {
                    return "📦 **How to Add an Ingredient:**\n\n" +
                           "1. Fill in all fields in 'Ingredient Details':\n" +
                           "   • Description: Letters and spaces only\n" +
                           "   • Quantity On Hand: Greater than 0\n" +
                           "   • Restock Level: Greater than 0\n" +
                           "   • Cost Price: Greater than 0\n" +
                           "2. Click the 'Add New' button\n" +
                           "3. Success message appears, grid refreshes\n\n" +
                           "Note: Description must be unique";
                }
                else if (lower.Contains("update") || lower.Contains("edit") || lower.Contains("change"))
                {
                    return "📦 **How to Update an Ingredient:**\n\n" +
                           "1. Click any row in the grid to select an ingredient\n" +
                           "2. Fields will populate with the selected ingredient's data\n" +
                           "3. Make your changes to any field\n" +
                           "4. Click the 'Update' button\n" +
                           "5. Success message appears, grid refreshes\n\n" +
                           "Note: Update stock levels when you receive deliveries";
                }
                else if (lower.Contains("delete") || lower.Contains("remove"))
                {
                    return "📦 **How to Delete an Ingredient:**\n\n" +
                           "1. Click any row in the grid to select an ingredient\n" +
                           "2. Click the 'Remove' button\n" +
                           "3. Confirm deletion when prompted: 'Delete this ingredient? This cannot be undone.'\n" +
                           "4. Click 'Yes' to delete permanently\n" +
                           "5. Confirmation message appears and grid refreshes\n\n" +
                           "⚠️ Warning: If used in recipes, delete will fail - remove recipe links first";
                }
                else
                {
                    return "📦 **Ingredient Management:**\n\n" +
                           "I can help you with:\n" +
                           "• How to add an ingredient\n" +
                           "• How to update an ingredient\n" +
                           "• How to delete an ingredient\n\n" +
                           "Just ask me something like 'how to add an ingredient'";
                }
            }

            // ============================================================
            // HOW TO - MANAGE CUSTOMERS
            // ============================================================
            if (lower.Contains("customer") || lower.Contains("manage customer") || lower.Contains("add customer") ||
                lower.Contains("update customer") || lower.Contains("delete customer") || lower.Contains("reset password"))
            {
                if (lower.Contains("add") || lower.Contains("create") || lower.Contains("new"))
                {
                    return "👥 **How to Add a Customer:**\n\n" +
                           "1. Fill in all fields:\n" +
                           "   • First Name: Letters only (required)\n" +
                           "   • Surname: Letters only (required)\n" +
                           "   • Email: Valid format (name@domain.com)\n" +
                           "   • Address: Must contain number and 2+ commas\n" +
                           "     Format: street number, suburb, city\n" +
                           "   • Password: Minimum 4 characters\n" +
                           "   • Status: Select Active or Inactive\n" +
                           "2. Click the 'Add' button\n" +
                           "3. Success message appears, grid refreshes";
                }
                else if (lower.Contains("update") || lower.Contains("edit") || lower.Contains("change"))
                {
                    return "👥 **How to Update a Customer:**\n\n" +
                           "1. Double-click any row in the grid to select a customer\n" +
                           "2. Fields will populate with the selected customer's data\n" +
                           "3. Make your changes to any field\n" +
                           "4. Click the 'Update' button\n" +
                           "5. Confirm update when prompted: 'Are you sure you want to update this customer?'\n" +
                           "6. Click 'Yes' to save changes\n" +
                           "7. Success message appears, grid refreshes";
                }
                else if (lower.Contains("delete") || lower.Contains("remove"))
                {
                    return "👥 **How to Delete a Customer:**\n\n" +
                           "1. Double-click any row in the grid to select a customer\n" +
                           "2. Click the 'Delete' button\n" +
                           "3. Confirm deletion when prompted: 'Are you sure you want to delete this customer?'\n" +
                           "4. Click 'Yes' to delete permanently\n" +
                           "5. Confirmation message appears and grid refreshes\n\n" +
                           "⚠️ Warning: This is a permanent DELETE operation. Data cannot be recovered!";
                }
                else if (lower.Contains("reset password") || lower.Contains("reset pass") || lower.Contains("password reset"))
                {
                    return "👥 **How to Reset a Customer's Password:**\n\n" +
                           "1. Double-click any row in the grid to select a customer\n" +
                           "2. Click the 'Reset Password' button\n" +
                           "3. Confirm reset: 'Reset password for [Customer Name]? Password will be reset to: temp123'\n" +
                           "4. Click 'Yes' to reset\n" +
                           "5. Confirmation message appears with the new password\n\n" +
                           "⚠️ Note: New password is 'temp123' - customer should change upon next login";
                }
                else
                {
                    return "👥 **Customer Management:**\n\n" +
                           "I can help you with:\n" +
                           "• How to add a customer\n" +
                           "• How to update a customer\n" +
                           "• How to delete a customer\n" +
                           "• How to reset a customer's password\n\n" +
                           "Just ask me something like 'how to add a customer'";
                }
            }

            // ============================================================
            // WORKFLOW QUESTIONS
            // ============================================================
            if ((lower.Contains("workflow") || lower.Contains("process") || lower.Contains("order") ||
                 lower.Contains("step") || lower.Contains("first")) &&
                (lower.Contains("menu item") || lower.Contains("recipe") || lower.Contains("ingredient")))
            {
                return "📋 **Complete Workflow for Creating Menu Items:**\n\n" +
                       "**Step 1:** Add the Menu Item\n" +
                       "   • Go to 'Manage Menu Items'\n" +
                       "   • Fill in name, prices, category, and prep time\n" +
                       "   • Click 'Add New'\n\n" +
                       "**Step 2:** Add Ingredients\n" +
                       "   • Go to 'Manage Ingredients'\n" +
                       "   • Add all ingredients needed\n" +
                       "   • Include quantity on hand, restock level, and cost\n\n" +
                       "**Step 3:** Link Menu Items with Ingredients\n" +
                       "   • Go to 'Manage Recipes'\n" +
                       "   • Select the menu item and ingredient\n" +
                       "   • Enter the quantity needed\n" +
                       "   • Click 'Add' to create the recipe link\n\n" +
                       "⚠️ **Important:** You can add menu items without recipes.\n" +
                       "   Recipes are only needed when you want to track ingredients.\n\n" +
                       "💡 **Tip:** Always add the menu item first, then ingredients,\n" +
                       "   then link them together.";
            }

            // ============================================================
            // TROUBLESHOOTING - VALIDATION ERRORS
            // ============================================================
            if ((lower.Contains("won't") || lower.Contains("wont") || lower.Contains("cannot") || lower.Contains("can't") ||
                 lower.Contains("not allow") || lower.Contains("error") || lower.Contains("problem")) &&
                (lower.Contains("add") || lower.Contains("update") || lower.Contains("save")))
            {
                return "🔧 **Common Validation Issues:**\n\n" +
                       "If you can't add or update, check these rules:\n\n" +
                       "**Menu Items:**\n" +
                       "• Name must be letters and spaces only (no numbers)\n" +
                       "• Prep Time must be numbers only (1-999)\n" +
                       "• Name must be unique\n" +
                       "• You do NOT need a recipe to add a menu item\n\n" +
                       "**Ingredients:**\n" +
                       "• Description must be letters and spaces only\n" +
                       "• Description must be unique\n\n" +
                       "**Recipes:**\n" +
                       "• Quantity must be greater than 0\n" +
                       "• That ingredient might already be linked to this menu item\n" +
                       "• You must add the menu item first\n\n" +
                       "**Customers:**\n" +
                       "• First Name: Letters only\n" +
                       "• Surname: Letters only\n" +
                       "• Email: Must have @ and valid domain\n" +
                       "• Password: Minimum 4 characters\n" +
                       "• Address: Must include a number and 2+ commas\n\n" +
                       "Fix highlighted (red) fields before submitting!";
            }

            // ============================================================
            // ORIGINAL RESPONSES - UNTOUCHED
            // ============================================================

            // Greetings
            if (lower.Contains("hello") || lower.Contains("hi") || lower.Contains("hey") ||
                lower.Contains("good morning") || lower.Contains("good afternoon") || lower.Contains("good evening"))
                return "Hello there! 👋 How can I help you today? 😊";

            // Login
            if (lower.Contains("login") || lower.Contains("sign in") || lower.Contains("log in") || lower.Contains("password"))
                return "🔐 **Login Process**\n\n" +
                       "1. Enter your username and password on the login screen.\n" +
                       "2. Click the Login button.\n" +
                       "3. If credentials are correct you will be taken to the Main Menu.\n\n" +
                       "Forgot password? Contact your system administrator.";

            // Main Menu
            if (lower.Contains("main menu") || lower.Contains("menu") || lower.Contains("navigate") || lower.Contains("dashboard"))
                return "📋 **Main Menu Navigation**\n\n" +
                       "From the Main Menu you can access:\n" +
                       "• Employee Management\n" +
                       "• New Order / POS\n" +
                       "• Inventory & Low Stock\n" +
                       "• Reports (Sales, Popular Products)\n" +
                       "• Settings & Logout\n\n" +
                       "Just click the tile you need!";

            // Employees
            if (lower.Contains("employee") || lower.Contains("staff") || lower.Contains("worker") || lower.Contains("user management"))
                return "👥 **Employee Management**\n\n" +
                       "Here you can:\n" +
                       "• View all employees\n" +
                       "• Add new staff members\n" +
                       "• Edit roles / permissions\n" +
                       "• Deactivate accounts\n\n" +
                       "Only administrators can modify employee records.";

            // New Order / POS
            if (lower.Contains("order") || lower.Contains("pos") || lower.Contains("new order") || lower.Contains("take order"))
                return "🛒 **New Order Process**\n\n" +
                       "1. Go to New Order from the Main Menu.\n" +
                       "2. Select items (you can search or browse categories).\n" +
                       "3. Adjust quantities.\n" +
                       "4. Add any notes / special requests.\n" +
                       "5. Proceed to Checkout when ready.";

            // Checkout
            if (lower.Contains("checkout") || lower.Contains("pay") || lower.Contains("payment") || lower.Contains("bill"))
                return "💳 **Checkout Process**\n\n" +
                       "1. Review the order summary.\n" +
                       "2. Choose payment method (Cash / Card / Mobile).\n" +
                       "3. Enter amount tendered (for cash).\n" +
                       "4. Confirm payment → receipt is generated.\n" +
                       "5. Order is sent to the kitchen / display.";

            // Low Stock
            if (lower.Contains("stock") || lower.Contains("inventory") || lower.Contains("low stock") || lower.Contains("out of stock"))
                return "📦 **Low Stock Management**\n\n" +
                       "• View items below reorder level.\n" +
                       "• Filter by category or urgency.\n" +
                       "• Create purchase orders directly from the list.\n" +
                       "• Update stock quantities after deliveries.";

            // Popular Products
            if (lower.Contains("popular") || lower.Contains("best seller") || lower.Contains("top product") || lower.Contains("favourite"))
                return "🏆 **Popular Products Report**\n\n" +
                       "Shows the best-selling items for the selected period.\n" +
                       "Useful for:\n" +
                       "• Menu planning\n" +
                       "• Stock prioritisation\n" +
                       "• Promotions\n\n" +
                       "You can filter by day / week / month / custom range.";

            // Sales / Revenue
            if (lower.Contains("sales") || lower.Contains("revenue") || lower.Contains("report") || lower.Contains("income") || lower.Contains("turnover"))
                return "📊 **Sales Revenue Report**\n\n" +
                       "View total sales, average order value, and trends.\n" +
                       "Breakdowns available by:\n" +
                       "• Day / Week / Month\n" +
                       "• Payment method\n" +
                       "• Category / Product\n" +
                       "• Cashier / Employee\n\n" +
                       "Export to Excel or PDF if needed.";

            // Help / Support
            if (lower.Contains("help") || lower.Contains("support") || lower.Contains("assist") || lower.Contains("how to"))
                return "I'm here to help! 💪 You can ask me about:\n\n" +
                       "• 🔐 Login process\n" +
                       "• 📋 Main Menu navigation\n" +
                       "• 👥 Employee management\n" +
                       "• 🛒 New Order process\n" +
                       "• 💳 Checkout process\n" +
                       "• 📦 Low Stock Management\n" +
                       "• 🏆 Popular Products Report\n" +
                       "• 📊 Sales Revenue Report\n\n" +
                       "Just type a keyword or describe what you need!";

            // Thanks / Bye
            if (lower.Contains("thank") || lower.Contains("thanks") || lower.Contains("appreciate"))
                return "You're very welcome! 😊 Anything else I can help with?";

            if (lower.Contains("bye") || lower.Contains("goodbye") || lower.Contains("see you") || lower.Contains("exit"))
                return "Goodbye! Have a wonderful day at Cafe101! ☕👋";

            // Default
            return "I'm not sure I understand. 🤔 Try asking about:\n\n" +
                   "• 🔐 Login process\n" +
                   "• 📋 Main Menu navigation\n" +
                   "• 👥 Employee management\n" +
                   "• 🛒 New Order process\n" +
                   "• 💳 Checkout process\n" +
                   "• 📦 Low Stock Management\n" +
                   "• 🏆 Popular Products Report\n" +
                   "• 📊 Sales Revenue Report\n" +
                   "• Help or support 💪";
        }
    }
}