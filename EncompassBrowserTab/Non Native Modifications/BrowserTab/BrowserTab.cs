using EncompassBrowserTab.Objects;
using EncompassBrowserTab.Objects.Helpers;
using EncompassBrowserTab.Objects.Interface;
using EncompassBrowserTab.Objects.Models;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.ClientServer.Reporting;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.MainUI;
using EllieMae.EMLite.UI.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using EncompassBrowserTab.Objects.Extension;
using CefSharp;
using EncompassBrowserTab.Objects.Dependencies;
using System.IO;

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