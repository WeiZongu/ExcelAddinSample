namespace ExcelAddInSample
{
    partial class RibbonMenu : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMenu()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabTab = this.Factory.CreateRibbonTab();
            this.grModel = this.Factory.CreateRibbonGroup();
            this.btnCreateForm = this.Factory.CreateRibbonButton();
            this.btnApplyForm = this.Factory.CreateRibbonButton();
            this.grSetting = this.Factory.CreateRibbonGroup();
            this.btnSetting = this.Factory.CreateRibbonButton();
            this.grOther = this.Factory.CreateRibbonGroup();
            this.btnOpenWebPage = this.Factory.CreateRibbonButton();
            this.tabTab.SuspendLayout();
            this.grModel.SuspendLayout();
            this.grSetting.SuspendLayout();
            this.grOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTab
            // 
            this.tabTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabTab.Groups.Add(this.grModel);
            this.tabTab.Groups.Add(this.grSetting);
            this.tabTab.Groups.Add(this.grOther);
            this.tabTab.Label = "Tab";
            this.tabTab.Name = "tabTab";
            // 
            // grModel
            // 
            this.grModel.Items.Add(this.btnCreateForm);
            this.grModel.Items.Add(this.btnApplyForm);
            this.grModel.Label = "モデル";
            this.grModel.Name = "grModel";
            // 
            // btnCreateForm
            // 
            this.btnCreateForm.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCreateForm.Label = "モデル作成";
            this.btnCreateForm.Name = "btnCreateForm";
            this.btnCreateForm.ShowImage = true;
            this.btnCreateForm.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OpenCreateForm);
            // 
            // btnApplyForm
            // 
            this.btnApplyForm.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnApplyForm.Label = "モデル適用";
            this.btnApplyForm.Name = "btnApplyForm";
            this.btnApplyForm.ShowImage = true;
            this.btnApplyForm.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OpenApplyForm);
            // 
            // grSetting
            // 
            this.grSetting.Items.Add(this.btnSetting);
            this.grSetting.Label = "設定";
            this.grSetting.Name = "grSetting";
            // 
            // btnSetting
            // 
            this.btnSetting.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSetting.Label = "設定";
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.OfficeImageId = "InAppDiagnosticsSupport";
            this.btnSetting.ShowImage = true;
            this.btnSetting.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnSetting);
            // 
            // grOther
            // 
            this.grOther.Items.Add(this.btnOpenWebPage);
            this.grOther.Label = "その他";
            this.grOther.Name = "grOther";
            // 
            // btnOpenWebPage
            // 
            this.btnOpenWebPage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOpenWebPage.Label = "Web";
            this.btnOpenWebPage.Name = "btnOpenWebPage";
            this.btnOpenWebPage.OfficeImageId = "InBrowserGallery";
            this.btnOpenWebPage.ShowImage = true;
            this.btnOpenWebPage.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnOpenWebPage);
            // 
            // RibbonMenu
            // 
            this.Name = "RibbonMenu";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.OnLoad);
            this.tabTab.ResumeLayout(false);
            this.tabTab.PerformLayout();
            this.grModel.ResumeLayout(false);
            this.grModel.PerformLayout();
            this.grSetting.ResumeLayout(false);
            this.grSetting.PerformLayout();
            this.grOther.ResumeLayout(false);
            this.grOther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grModel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCreateForm;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnApplyForm;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpenWebPage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grOther;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMenu RibbonMenu
        {
            get { return this.GetRibbon<RibbonMenu>(); }
        }
    }
}
