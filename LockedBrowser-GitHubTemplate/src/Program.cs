
using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace LockedBrowser
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.None
            };

            var webView = new WebView2
            {
                Dock = DockStyle.Fill,
                Source = new Uri("https://www.khaled-sakr.com/")
            };
            form.Controls.Add(webView);
            form.KeyPreview = true;

            form.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                    webView.Source = new Uri("https://magacademy.co/");
            };

            Application.Run(form);
        }
    }
}
