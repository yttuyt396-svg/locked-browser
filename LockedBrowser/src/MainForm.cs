// MainForm.cs
using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

public class MainForm : Form
{
    private WebView2 webView;

    public MainForm()
    {
        Width = 800; Height = 600;
        FormBorderStyle = FormBorderStyle.None;

        webView = new WebView2 { Dock = DockStyle.Fill };
        Controls.Add(webView);
        webView.CoreWebView2InitializationCompleted += (s, e) =>
        {
            webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            NavigateTo("https://www.khaled-sakr.com/");
        };
        webView.EnsureCoreWebView2Async();
    }

    private void NavigateTo(string url)
    {
        if (url.StartsWith("https://www.khaled-sakr.com/") ||
            url.StartsWith("https://mohamed-abdelgwad.com/"))
        {
            webView.CoreWebView2.Navigate(url);
        }
        else if (url.StartsWith("intent://") || url.StartsWith("abdeljawadplayer://"))
        {
            System.Diagnostics.Process.Start("wine", $"start \"{url}\"");
        }
        else
        {
            MessageBox.Show("Access to this site is not allowed.");
        }
    }

    private void CoreWebView2_NewWindowRequested(object sender, dynamic args)
    {
        args.Handled = true;
        NavigateTo((string)args.Uri);
    }
}
