using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAddInSample.Com;
using ExcelAddInSample.Data;
using System.IO;
using ExcelAddInSample.Properties;

namespace ExcelAddInSample
{
    public partial class RibbonMenu
    {
        public static Form menuForm = null;
        public Excel.Range selectedRange;
        public Excel.Worksheet activeSh;
        public string activePath;
        public string activeDirPath;
        FileInfo modelIdFile;
        public Excel.Range idRange;
        FileInfo settingFile;

        private void OpenCreateForm(object sender, RibbonControlEventArgs e)
        {
            if (!ExeCheck())
            {
                return;
            }

            try
            {
                if (menuForm == null || menuForm.IsDisposed)
                {
                    Cursor preCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    Reload();

                    Dictionary<object, object> titleDict = null;
                    if (selectedRange.ListObject == null)
                    {
                        titleDict = XlsOperation.GetTitleDict(activeSh);
                    }

                    UploadRequestParam paras = new UploadRequestParam
                    {
                        FileFullName = XlsOperation.MakeSelectedRangeTempFile(activePath, selectedRange, titleDict, activeSh),
                        Method = "train"
                    };
                    InputFormData<UploadRequestParam> data = new InputFormData<UploadRequestParam>
                    {
                        SettingFile = settingFile,
                        RequestParam = paras,
                        BookPath = activePath,
                        ModelIdFile = modelIdFile
                    };
                    var rsltData = UploadCommand.UploadCSV(data);
                    if (rsltData.MsgType == 0)
                    {
                        data.RequestParam.ModelID = rsltData.DsName;
                    }
                    else
                    {
                        return;
                    }
                    
                    Cursor.Current = preCursor;
                    menuForm = new ModelCreateEntranceForm(data);
                    menuForm.Show();
                }
            }
            catch(Exception ex)
            {
                MsgBox.MsgBoxShowErr(ex.Message);
            }
        }

        private void OpenApplyForm(object sender, RibbonControlEventArgs e)
        {
            if (!ExeCheck())
            {
                return;
            }

            if (menuForm == null || menuForm.IsDisposed)
            {
                Reload();
                InputFormData<object> iData = new InputFormData<object>
                {
                    ModelIdFile = modelIdFile,
                    ActiveSh = activeSh,
                    BookPath = activePath,
                    SettingFile = settingFile
                };
                menuForm = new ModelApplyForm(iData);
                menuForm.Show();
            }
        }

        private void Reload()
        {
            selectedRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
            activeSh = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
            activePath = Globals.ThisAddIn.Application.ActiveWorkbook.FullName;
            activeDirPath = Path.GetDirectoryName(activePath);
            string mydocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            modelIdFile = new FileInfo(Path.Combine(mydocPath, "Sample", "ModelList"));
            settingFile = new FileInfo(Path.Combine(mydocPath, "Sample", "Setting"));
            if (!settingFile.Directory.Exists)
            {
                settingFile.Directory.Create();
            }
        }

        private bool ExeCheck()
        {
            bool isJudge = false;
            Reload();
            string extention = Path.GetExtension(activePath);
            if (extention.Equals(".csv") || extention.Equals(".xls") || extention.Equals(".xlsx"))
            {
                isJudge = true;
            }
            return isJudge;
        }

        private void OnOpenWebPage(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://aaaa.co.jp/");
        }

        private void OnSetting(object sender, RibbonControlEventArgs e)
        {
            if (!ExeCheck())
            {
                return;
            }

            if (menuForm == null || menuForm.IsDisposed)
            {
                Reload();
                InputFormData<object> data = new InputFormData<object>
                {
                    SettingFile = settingFile
                };
                menuForm = new SettingForm(data);
                menuForm.Show();
            }
        }

        private void OnLoad(object sender, RibbonUIEventArgs e)
        {
            this.btnSetting.Label = "設定";
        }
    }
}
