using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;

namespace ADXOutlook.Business_Logic
{
    class Debug
    {
        static System.IO.FileStream myTraceLog;
        static TextWriterTraceListener myListener;
        internal static string TracePath = "";
        private static int debugLevel = 4;
        internal static string ProductName = "ADXOutlook";

        public static void InitialiseTrace()
        {
            try
            {
                //Set trace path
                TracePath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\" + ProductName + "\\Logs";
                if (Directory.Exists(TracePath)) { }
                else
                {
                    //* Directory Doesnt Exist - Create it 
                    Directory.CreateDirectory(TracePath);
                }

                myTraceLog = new FileStream(TracePath + "\\" + ProductName + " (" + DateTime.Now.ToString("dd-MM-yy") + ").txt", FileMode.Append);
                myListener = new TextWriterTraceListener(myTraceLog);
                Trace.AutoFlush = true;
                Trace.Listeners.Add(myListener);
                System.Diagnostics.Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                System.Diagnostics.Debug.AutoFlush = true;
                System.Diagnostics.Debug.Indent();

                ClearOldDebugFiles();
                DebugMessage(3, "Application Started v" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error Initialising Trace for Debugging. " + Environment.NewLine + "The " + ProductName + " folder or Trace file may be opened :- " + ex.Message, ProductName + " Debug");
            }
        }

        internal static void DebugMessage(Int16 Level, string dbMessage, bool WriteToLog = true)
        {

            try
            {
                //using (FileStream myTraceLog = File.Open(TracePath,FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                switch (Level)
                {
                    case 1:
                        MessageBox.Show(dbMessage, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        myListener.WriteLine(DateTime.Now + " -1- " + dbMessage);
                        break;

                    case 2:
                        if (debugLevel >= 2) myListener.WriteLine(DateTime.Now + " -2- " + dbMessage);
                        break;
                    case 3:
                        if (debugLevel >= 3)
                            myListener.WriteLine(DateTime.Now + " -3- " + dbMessage);
                        break;

                    case 4:
                        if (debugLevel >= 4)
                            myListener.WriteLine(DateTime.Now + " -4- " + dbMessage);
                        break;
                }
                myListener.Flush();
              
            }
            catch (Exception)
            {
               
            }
        }

        private static bool ClearOldDebugFiles()
        {
            try
            {
                var filesArray = Directory.GetFiles(TracePath);
                Array.Sort(filesArray);
                Debug.DebugMessage(3, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Debug.DebugMessage(3, filesArray.Length.ToString() + " Log files found");
                foreach (var item in filesArray)
                {
                    string shortFilePath = item.Replace(TracePath, "");
                    int indexOfOpenBrace = shortFilePath.IndexOf("(") + 1;
                    int indexOfCloseBrace = shortFilePath.IndexOf(")");
                    if (indexOfCloseBrace < 0) continue;
                    string dateStr = shortFilePath.Substring(indexOfOpenBrace, indexOfCloseBrace - indexOfOpenBrace);
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime datetimeVal = DateTime.ParseExact(dateStr, "dd-MM-yy", provider);
                    if ((DateTime.Now - datetimeVal).Days > 30)
                    {
                        File.Delete(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugMessage(2, "Error in ClearOldDebugFiles : " + ex.Message);
                return false;
            }
        }
    }
}
