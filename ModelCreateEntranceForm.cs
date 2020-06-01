using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExcelAddInSample.Com;
using System.IO;
using ExcelAddInSample.Data;

namespace ExcelAddInSample
{
    public partial class ModelCreateEntranceForm : Form
    {
        private readonly List<string> lstPurposeJp = new List<string> { "分類", "回帰" };
        private readonly List<string> lstPurposeEn = new List<string> { "CLF", "REG" };
        public FileInfo SettingFile;
        public string BookPath;
        public bool IsDoing { get; set; } = false;
        public string ModelID { get; set; }
        public FileInfo ModelIdFile;

        public ModelCreateEntranceForm(InputFormData<UploadRequestParam> iData)
        {
            InitializeComponent();
            cbPurpose.SelectedIndex = 0;
            SettingFile = iData.SettingFile;
            BookPath = iData.BookPath;
            ModelID = iData.RequestParam.ModelID;
            ModelIdFile = iData.ModelIdFile;
        }

        private void CollectionStart(object sender, EventArgs e)
        {
            btnCollectionStart.BackColor = Color.BurlyWood;
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Library.AllCtrlSwInForm(this, false);
            IsDoing = true;

            try
            {
                if (String.IsNullOrEmpty(tbModelName.Text) && String.IsNullOrWhiteSpace(tbModelName.Text))
                {
                    throw new Exception("モデル名が未入力です。");
                }
                if (ModelID == null)
                {
                    throw new Exception("DS_Nameが見つかりません。");
                }
                SummaryRequestParam paras = new SummaryRequestParam
                {
                    ModelID = ModelID
                };
                Dictionary<string, string> purposeDict = Library.MakeStringDict(lstPurposeJp, lstPurposeEn);
                string purpose = cbPurpose.SelectedItem.ToString();
                purposeDict.TryGetValue(purpose, out string resPurpose);
                if (resPurpose == null)
                {
                    resPurpose = "CLF";
                }
                paras.Purpose = resPurpose;
                paras.IgnoreCheckY = 1;
                InputFormData<SummaryRequestParam> data = new InputFormData<SummaryRequestParam>
                {
                    SettingFile = SettingFile,
                    RequestParam = paras
                };

                var rsltData = SummaryCommand.Collection(data);
                if (rsltData.MsgType == 0)
                {
                    rsltData.ModelName = tbModelName.Text;
                    InputFormData<SummaryResultData> iData = new InputFormData<SummaryResultData>
                    {
                        SettingFile = SettingFile,
                        RequestParam = rsltData,
                        BookPath = BookPath,
                        ModelIdFile = ModelIdFile
                    };
                    iData.RequestParam.ModelID = ModelID;
                    Form form = new ModelCreateForm(iData);
                    form.Show(this);
                    RibbonMenu.menuForm = form;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MsgBox.MsgBoxShowErr(ex.Message);
                this.Close();
                this.Dispose();
            }
            finally
            {
                Library.AllCtrlSwInForm(this, true);
                Cursor.Current = preCursor;
                btnCollectionStart.BackColor = Color.Empty;
                IsDoing = false;
                if (!this.IsDisposed)
                {
                    this.Hide();
                }
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
