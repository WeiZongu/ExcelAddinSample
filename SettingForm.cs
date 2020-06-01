using System;
using System.Windows.Forms;
using ExcelAddInSample.Data;
using System.IO;
using ExcelAddInSample.Com;

namespace ExcelAddInSample
{
    public partial class SettingForm : Form
    {
        public SettingData Data { get; set; }
        FileInfo SettingFile { get; set; }

        public SettingForm(InputFormData<object> iData)
        {
            InitializeComponent();
            SettingFile = iData.SettingFile;
            Data = SettingDataCommand.LoadFile(SettingFile);
            SettingLoad();
        }

        private void OnSetting(object sender, EventArgs e)
        {
            Setting();
            this.Close();
            this.Dispose();
        }

        private void SettingLoad()
        {
            this.tbApiKey.Text = Data.ApiKey;
            this.tbApiSecret.Text = Data.ApiSecret;
        }
        private void Setting()
        {
            Data.ApiKey = this.tbApiKey.Text;
            Data.ApiSecret = this.tbApiSecret.Text;
            SettingDataCommand.UpdateFile(SettingFile, Data);
            MsgBox.MsgBoxShowInfo("設定データを保存しました。");
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (IsChanged())
            {
                if (MessageBox.Show("設定データが変更されています。\r\n設定データを保存しますか？",
                    "SkyFoxExcelAddIn", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Setting();
                }
            }
        }

        private bool IsChanged()
        {
            if (!this.tbApiKey.Text.Equals(Data.ApiKey))
            {
                return true;
            }

            if (!this.tbApiSecret.Text.Equals(Data.ApiSecret))
            {
                return true;
            }
            return false;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
