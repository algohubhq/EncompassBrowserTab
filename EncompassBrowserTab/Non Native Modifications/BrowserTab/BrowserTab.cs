using EncompassBrowserTab.Objects;
using EncompassBrowserTab.Objects.Interface;
using System;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace EncompassBrowserTab.Non_Native_Modifications.BrowserTab
{
    public class BrowserTab : Plugin, ILogin, ITabChanged
    {

        ChromiumWebBrowser browser;

        public override bool Authorized()
        {
            return PluginAccess.CheckAccess(nameof(BrowserTab));
        }

        public override void Login(object sender, EventArgs e)
        {

            TabControl tabs = FormWrapper.TabControl;
            tabs.TabPages.Add("cefBrowser", "Browser");
            TabPage tabPage = tabs.TabPages["cefBrowser"];

            browser = new ChromiumWebBrowser("www.google.com");
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            tabPage.Controls.Add(browser);

        }

        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var b = ((ChromiumWebBrowser)sender);

        }


        public override void TabChanged(object sender, EventArgs e)
        {
            try
            {
                TabControl tabControl = sender as TabControl;
                if (tabControl.SelectedIndex < 0)
                    return;
                TabPage tabPage = tabControl.TabPages[tabControl.SelectedIndex];
                if (tabPage.Text.Contains("Browser"))
                {
                    
                }
                
            }
            catch (Exception ex)
            {
                Logger.HandleError(ex, nameof(BrowserTab));
            }
        }

    }
}