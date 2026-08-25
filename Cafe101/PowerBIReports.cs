using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;
using System.IO;

namespace PowerBI_Reports_Demo
{
    public partial class PowerBiReports : Form
    {
        private Form previousForm;
        public PowerBiReports(Form previous)
        {
            InitializeComponent();
            this.previousForm = previous;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;  
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeWebView();
        }

        // ====================== PUT THE CODE HERE ======================
        private async Task InitializeWebView()
        {
            // Create a permanent folder so Microsoft login is remembered
            string userDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PowerBI_WebView2_Data"
            );

            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(
                userDataFolder: userDataFolder
            );

            await webView21.EnsureCoreWebView2Async(env);

            // Paste your private Power BI report link here
            string reportUrl = "https://app.powerbi.com/links/FE_urqTnLw?ctid=226827d6-a9d0-470d-8c15-b146b0192d51&pbi_source=linkShare ";

            webView21.Source = new Uri(reportUrl);
        }
        // ===============================================================
        // When the user clicks the X (close)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (previousForm != null && !previousForm.IsDisposed)
            {
                previousForm.Show();
                previousForm.WindowState = FormWindowState.Maximized; // or Maximized if you prefer
            }
            base.OnFormClosing(e);
        }

        // When the user clicks Minimize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                if (previousForm != null && !previousForm.IsDisposed)
                {
                    previousForm.Show();
                    previousForm.WindowState = FormWindowState.Maximized;
                }
                this.Hide();   // hide the report form instead of just minimizing
            }
        }


        private void PowerBiReports_Load(object sender, EventArgs e)
        {

        }
    }
}