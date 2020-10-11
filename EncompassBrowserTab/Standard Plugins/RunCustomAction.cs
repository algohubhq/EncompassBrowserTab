using EncompassBrowserTab.Objects;
using EncompassBrowserTab.Objects.Helpers;
using EncompassBrowserTab.Objects.Interface;
using EllieMae.EMLite.DataEngine;
using EllieMae.EMLite.DataEngine.Log;
using EllieMae.EMLite.eFolder;
using EllieMae.EMLite.eFolder.Documents;
using EllieMae.EMLite.eFolder.LoanCenter;
using EllieMae.EMLite.RemotingServices;
using EllieMae.EMLite.UI;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using System;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace EncompassBrowserTab.Standard_Plugins
{
    public class RunCustomAction : Plugin, IFieldChange, ILoanOpened
    {
        private string actionName;

        public override bool Authorized()
        {
            return PluginAccess.CheckAccess(nameof(RunCustomAction));
        }

        public override void LoanOpened(object sender, EventArgs e)
        {

        }

        public override void FieldChanged(object sender, FieldChangeEventArgs e)
        {  
            if (e.FieldID.Equals("CX.CUSTOM.ACTION") && !string.IsNullOrEmpty(e.NewValue))
            {
                actionName = e.NewValue;
                RunAction(actionName);
                EncompassHelper.Set("CX.CUSTOM.ACTION", "");
            }
        }

        private void RunAction(string actionName)
        {
            try
            {

                if (!Session.LoanDataMgr.IsConsumerConnectLoan(true))
                {
                    using (SendConsentRequestDialog sendConsentRequestDialog = new SendConsentRequestDialog(Session.LoanDataMgr))
                    {
                        DialogResult dialogResult = sendConsentRequestDialog.ShowDialog(Form.ActiveForm);
                        if (dialogResult == DialogResult.OK)
                        {
                            Session.LoanDataMgr.Save();
                        }
                    }
                }
                else
                {
                    using (SendConsentRequestDialogCC sendConsentRequestDialogCC = new SendConsentRequestDialogCC(Session.LoanDataMgr))
                    {
                        DialogResult dialogResult = sendConsentRequestDialogCC.ShowDialog(Form.ActiveForm);
                        if (dialogResult == DialogResult.OK)
                        {
                            Session.LoanDataMgr.Save();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.HandleError(ex, nameof(RunCustomAction), (object)null);
            }
        }
    }
}
