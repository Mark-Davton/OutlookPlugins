using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ADXOutlook.Business_Logic
{
    public class OutlookHelper
    {
        public static string GetSubjectFromMail(ref Explorer oExpl)
        {
            Selection oSelection = null;
            MailItem mailItem = null;
            try
            {
                var selectionCount = -1;
                if (oExpl != null)
                {
                    oSelection = oExpl.Selection;
                    selectionCount = oSelection.Count;
                    if(oSelection != null)
                    {
                        if (selectionCount < 1)
                        {
                            Debug.DebugMessage(3, $"could not found any email that selected");
                            return "There is no email selected,Please select an email ";
                        }
                        else
                        {
                            mailItem = oSelection[1] as MailItem;
                            if (mailItem != null)
                            {
                                Debug.DebugMessage(3, $"opened selected mail item, subject -{mailItem.Subject}");
                                return mailItem.Subject;
                            }
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, $"Error in {MethodBase.GetCurrentMethod().Name} in {MethodBase.GetCurrentMethod().DeclaringType.Name},{ex.Message}");               
            }
            finally
            {
                if (oSelection != null) Marshal.ReleaseComObject(oSelection);
                if (mailItem != null) Marshal.ReleaseComObject(mailItem);
            }
            return null;
        }
    }
}
