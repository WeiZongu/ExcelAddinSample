using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelAddInSample.Com;
using System.IO;
using ExcelAddInSample.Data;

namespace ExcelAddInSample
{
    public partial class ModelCreateForm : Form
    {
        private readonly List<string> lstXtypeJp = new List<string> { "カテゴリ", "数値", "テキスト" };
        private readonly List<string> lstXtypeEn = new List<string> { "category", "numeric", "text" };
        public SummaryResponseData GridData;
        public string ModelName { get; set; }
        public string Purpose { get; set; }
        public FileInfo SettingFile;
        public string ThisBookPath;
        public bool IsDoing { get; set; } = false;
        public string ModelID { get; set; }
        public FileInfo ModelIdFile;

        public ModelCreateForm(InputFormData<SummaryResultData> iData)
        {
            InitializeComponent();
            GridData = iData.RequestParam.Data;
            ModelName = iData.RequestParam.ModelName;
            Purpose = iData.RequestParam.Purpose;
            tbSelectOutFolder.Text = Path.GetDirectoryName(iData.BookPath);
            LoadGrid();
            SettingFile = iData.SettingFile;
            ThisBookPath = iData.BookPath;
            ModelID = iData.RequestParam.ModelID;
            ModelIdFile = iData.ModelIdFile;
        }

        private void LoadGrid()
        {
            Dictionary<string, string> xTypeDict = Library.MakeStringDict(lstXtypeEn, lstXtypeJp);

        }

        private void UpdateCollectionList(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0))
            {
                return;
            }

            if (dgvCollection[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                MsgBox.MsgBoxShowWarning("選択不可です。");
                return;
            }

            switch (e.ColumnIndex)
            {
                // 予測対象
                case 0:
                    for (int i = 0; i < dgvCollection.Rows.Count; i++)
                    {
                        dgvCollection[e.ColumnIndex, i].Value = false;
                        int.TryParse(dgvCollection[5, i].Value.ToString(), out int val);
                        if (val >= 10)
                        {
                            dgvCollection[0, i].ReadOnly = true;
                        }
                        else
                        {
                            dgvCollection[0, i].ReadOnly = false;
                        }
                        dgvCollection[1, i].ReadOnly = false;
                    }
                    dgvCollection[e.ColumnIndex, e.RowIndex].Value = true;
                    dgvCollection[0, e.RowIndex].ReadOnly = true;
                    dgvCollection[1, e.RowIndex].ReadOnly = true;
                    dgvCollection[1, e.RowIndex].Value = false;
                    break;

                // 分析対象
                case 1:
                    if ((bool)dgvCollection[e.ColumnIndex, e.RowIndex].Value)
                    {
                        dgvCollection[e.ColumnIndex, e.RowIndex].Value = false;
                    }
                    else
                    {
                        dgvCollection[e.ColumnIndex, e.RowIndex].Value = true;
                    }
                    break;
            }
        }

        private void ExecModelCreate(object sender, EventArgs e)
        {
            btnModelCreate.BackColor = Color.BurlyWood;
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Library.AllCtrlSwInForm(this, false);
            IsDoing = true;

            try
            {
                ModelCreateRequestRaram reqParam = new ModelCreateRequestRaram();
                reqParam.ModelName = ModelName;
                reqParam.ModelID = ModelID;

                bool isPredict = false;
                Dictionary<string, string> xTypeDict = Library.MakeStringDict(lstXtypeJp, lstXtypeEn);
                for (int r = 0; r < dgvCollection.Rows.Count; r++)
                {
                    string key = (string)dgvCollection[2, r].Value;
                    xTypeDict.TryGetValue((string)dgvCollection[3, r].Value, out string val);
                    reqParam.ParamDict.Add(key, val);
                    if ((bool)dgvCollection[0, r].Value)
                    {
                        reqParam.Yname = key;
                        isPredict = true;
                    }

                }
                reqParam.Purpose = Purpose;


                InputFormData<ModelCreateRequestRaram> iData = new InputFormData<ModelCreateRequestRaram>
                {
                    SettingFile = SettingFile,
                    RequestParam = reqParam
                };
                ModelCreateResultData data = ModelCreateCommand.ModelCreate(iData);
                if (data.MsgType != 0)
                {
                    return;
                }

                string tempPath = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo tempFile = new FileInfo(Path.Combine(tempPath, "Templates", "ModelCreateReport.xlsx"));
                DataSourceCommand.UpdateFile(ModelIdFile, "a", "b");

                MsgBox.MsgBoxShowInfo(String.Format("モデル結果出力が完了しました。\r\n出力先:{0}", tbSelectOutFolder.Text));

            }
            catch (Exception ex)
            {
                MsgBox.MsgBoxShowErr(ex.Message);
            }
            finally
            {
                Library.AllCtrlSwInForm(this, true);
                Cursor.Current = preCursor;
                btnModelCreate.BackColor = Color.Empty;
                IsDoing = false;
                this.Close();
                this.Dispose();
            }
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Dispose();
        }

        private void SummaryCollection(object sender, EventArgs e)
        {
            btnSummaryCollection.BackColor = Color.BurlyWood;
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Library.AllCtrlSwInForm(this, false);
            IsDoing = true;

            try
            {
                SummaryRequestParam reqParam = new SummaryRequestParam();
                reqParam.ModelID = ModelID;

                bool isPredict = false;
                Dictionary<string, string> xTypeDict = Library.MakeStringDict(lstXtypeJp, lstXtypeEn);
                for (int r = 0; r < dgvCollection.Rows.Count; r++)
                {
                    string key = (string)dgvCollection[2, r].Value;
                    xTypeDict.TryGetValue((string)dgvCollection[3, r].Value, out string val);
                    reqParam.ParamDict.Add(key, val);
                    if ((bool)dgvCollection[0, r].Value)
                    {
                        reqParam.Yname = key;
                        isPredict = true;
                    }
                }
                reqParam.Purpose = Purpose;
                reqParam.IgnoreCheckY = 0;

                InputFormData<SummaryRequestParam> iData = new InputFormData<SummaryRequestParam>
                {
                    SettingFile = SettingFile,
                    RequestParam = reqParam
                };
                SummaryResultData data = SummaryCommand.Collection(iData);
                if (data.MsgType != 0)
                {
                    return;
                }

                string tempPath = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo tempFile = new FileInfo(Path.Combine(tempPath, "Templates", "SummaryReport.xlsx"));

                MsgBox.MsgBoxShowInfo(String.Format("サマリ詳細出力が完了しました。\r\n出力先:{0}", tbSelectOutFolder.Text));

            }
            catch (Exception ex)
            {
                MsgBox.MsgBoxShowErr(ex.Message);
            }
            finally
            {
                Library.AllCtrlSwInForm(this, true);
                Cursor.Current = preCursor;
                btnSummaryCollection.BackColor = Color.Empty;
                IsDoing = false;
            }
        }

        private void SelectedOutFolder(object sender, EventArgs e)
        {
            using (var dir = new FolderBrowserDialog())
            {
                dir.Description = "フォルダを選択して下さい。";
                dir.SelectedPath = tbSelectOutFolder.Text;
                if (dir.ShowDialog() == DialogResult.OK)
                {
                    tbSelectOutFolder.Text = dir.SelectedPath;
                }
            }
        }

        private void ValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0))
            {
                return;
            }

            if (!(bool)dgvCollection[0, e.RowIndex].Value && !(bool)dgvCollection[1, e.RowIndex].Value)
            {
                dgvCollection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            }
            else
            {
                dgvCollection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
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
