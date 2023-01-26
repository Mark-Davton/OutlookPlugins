using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AddinExpress.OL;
using Microsoft.Office.Interop.Outlook;
using ADXOutlook.Business_Logic;
using System.Reflection;

namespace ADXOutlook.Presentation.ADXForms
{
    public partial class adxMainPanel : AddinExpress.OL.ADXOlForm
    {
        public adxMainPanel()
        {
            InitializeComponent();
        }
        private void LoadSelectedEmailSubject()
        {
            Explorer oExpl = null;
            try
            {
                oExpl = this.ExplorerObj as Explorer;
                lblName.Text = OutlookHelper.GetSubjectFromMail(ref oExpl);
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, $"Error in {MethodBase.GetCurrentMethod().Name} in {MethodBase.GetCurrentMethod().DeclaringType.Name},{ex.Message}");
            }            
        }

        private void adxMainPanel_ADXSelectionChange_1()
        {
            try
            {
                LoadSelectedEmailSubject();
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, $"Error in loading the mail selected mail (adxMainPanel): ex - {ex.Message}");
            }
        }    
    }
}
