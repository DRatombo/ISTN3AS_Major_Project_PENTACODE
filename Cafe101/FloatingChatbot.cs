using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class FloatingChatbot : Form
    {
        private ChatbotControl chatbot;

        public FloatingChatbot()
        {
            // Form settings - makes it float and invisible except for the chatbot
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(70, 70);
            this.BackColor = Color.White;  // Changed from Transparent
            this.TopMost = true;  // This keeps it on top of all forms
            this.ShowInTaskbar = false;
            this.TransparencyKey = Color.White;  // Changed from Transparent

            // Create and add the chatbot control
            chatbot = new ChatbotControl();
            chatbot.Location = new Point(0, 0);
            this.Controls.Add(chatbot);

            // Position at bottom-right of screen
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - 90,
                Screen.PrimaryScreen.WorkingArea.Height - 90
            );
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BringToFront();
        }

        public void CloseChatbot()
        {
            this.Close();
        }

        public void BringToFront()
        {
            this.TopMost = true;  // Ensure it stays on top
            base.BringToFront();
        }

        private void FloatingChatbot_Load(object sender, EventArgs e)
        {

        }
    }
}