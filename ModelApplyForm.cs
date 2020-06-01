using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ExcelAddInSample.Com;
using ExcelAddInSample.Data;
using System.Net;

namespace ExcelAddInSample
{
    public partial class ModelApplyForm : Form
    {
        public string DsName { get; set; }
        public FileInfo ModelIdFile;
        public DataSource ModelIdDict = new DataSource();
        public Excel.Worksheet ThisSh { get; set; }
        public string FilePath { get; set; }
        public FileInfo SettingFile;
        public bool IsDoing { get; set; } = false;

        public ModelApplyForm(InputFormData<object> iData)
        {
            InitializeComponent();
            ModelIdFile = iData.ModelIdFile;
            ModelIdDict = DataSourceCommand.LoadFile(ModelIdFile);
            cbModelID.DataSource = ModelIdDict.DataSources.Keys.Reverse().ToList();
            cbHowToModelID.SelectedIndex = 0;
            if (cbModelID.Items.Count < 1)
            {
                cbHowToModelID.SelectedIndex = 1;
            }
            SetHowTo(cbHowToModelID.SelectedIndex);
            ThisSh = iData.ActiveSh;
            FilePath = iData.BookPath;
            SettingFile = iData.SettingFile;
        }

        private void SetHowTo(int idx)
        {
            switch (idx)
            {
                case 0:
                    tbInputModelID.ReadOnly = true;
                    cbModelID.Enabled = true;
                    break;
                case 1:
                    tbInputModelID.ReadOnly = false;
                    cbModelID.Enabled = false;
                    break;
            }
        }

        private void ListChanged(object sender, EventArgs e)
        {
            SetHowTo(cbHowToModelID.SelectedIndex);
        }

        private void ModelApplied(object sender, EventArgs e)
        {
            btnExec.BackColor = Color.BurlyWood;
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Library.AllCtrlSwInForm(this, false);
            IsDoing = true;

            try
            {
                ModelApplyRequestRaram reqParam = new ModelApplyRequestRaram();
                if (cbHowToModelID.SelectedIndex == 0)
                {
                    if (cbModelID.Items.Count >= 1)
                    {
                        reqParam.ModelID = cbModelID.SelectedItem.ToString();
                    }
                }
                else
                {
                    reqParam.ModelID = tbInputModelID.Text;
                }

                if (String.IsNullOrEmpty(reqParam.ModelID))
                {
                    throw new Exception("モデルIDを選択または入力して下さい。");
                }

                Dictionary<object, object> titleDict = null;
                var selectedRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
                if (selectedRange.ListObject == null)
                {
                    titleDict = XlsOperation.GetTitleDict(ThisSh);
                }

                UploadRequestParam paras = new UploadRequestParam
                {
                    FileFullName = XlsOperation.MakeSelectedRangeTempFile(FilePath, selectedRange, titleDict, ThisSh),
                    Method = "predict",
                    ModelID = reqParam.ModelID
                };
                InputFormData<UploadRequestParam> data = new InputFormData<UploadRequestParam>
                {
                    SettingFile = SettingFile,
                    RequestParam = paras
                };
                var rsltData = UploadCommand.UploadCSV(data);
                if (rsltData.MsgType != 0)
                {
                    return;
                }
                reqParam.DsName = rsltData.DsName;

                InputFormData<ModelApplyRequestRaram> iData = new InputFormData<ModelApplyRequestRaram>
                {
                    SettingFile = SettingFile,
                    RequestParam = reqParam
                };
                ModelApplyResultData resData = ModelApplyCommand.ModelApplied(iData);
                if (resData.MsgType != 0)
                {
                    return;
                }

                MsgBox.MsgBoxShowInfo("モデル適用が完了しました。");
            }
            catch (Exception ex)
            {
                MsgBox.MsgBoxShowErr(ex.Message);
            }
            finally
            {
                Library.AllCtrlSwInForm(this, false);
                Cursor.Current = preCursor;
                btnExec.BackColor = Color.Empty;
                IsDoing = false;
                this.Close();
                this.Dispose();
            }

        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDoing)
            {
                e.Cancel = true;
            }
        }
    }
}
