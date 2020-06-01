namespace ExcelAddInSample
{
    partial class ModelCreateEntranceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbModelName = new System.Windows.Forms.ComboBox();
            this.btnCollectionStart = new System.Windows.Forms.Button();
            this.cbPurpose = new System.Windows.Forms.ComboBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbModelName
            // 
            this.cbModelName.FormattingEnabled = true;
            this.cbModelName.Items.AddRange(new object[] {
            "CLF",
            "REG"});
            this.cbModelName.Location = new System.Drawing.Point(127, 58);
            this.cbModelName.Name = "cbModelName";
            this.cbModelName.Size = new System.Drawing.Size(392, 26);
            this.cbModelName.TabIndex = 14;
            this.cbModelName.Visible = false;
            // 
            // btnCollectionStart
            // 
            this.btnCollectionStart.Location = new System.Drawing.Point(411, 156);
            this.btnCollectionStart.Name = "btnCollectionStart";
            this.btnCollectionStart.Size = new System.Drawing.Size(108, 42);
            this.btnCollectionStart.TabIndex = 13;
            this.btnCollectionStart.Text = "次へ";
            this.btnCollectionStart.UseVisualStyleBackColor = true;
            this.btnCollectionStart.Click += new System.EventHandler(this.CollectionStart);
            // 
            // cbPurpose
            // 
            this.cbPurpose.AutoCompleteCustomSource.AddRange(new string[] {
            "分類",
            "回帰"});
            this.cbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPurpose.FormattingEnabled = true;
            this.cbPurpose.Items.AddRange(new object[] {
            "分類",
            "回帰"});
            this.cbPurpose.Location = new System.Drawing.Point(127, 106);
            this.cbPurpose.Name = "cbPurpose";
            this.cbPurpose.Size = new System.Drawing.Size(121, 26);
            this.cbPurpose.TabIndex = 12;
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Location = new System.Drawing.Point(51, 109);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(44, 18);
            this.lblPurpose.TabIndex = 11;
            this.lblPurpose.Text = "目的";
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(51, 61);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(70, 18);
            this.lblModelName.TabIndex = 10;
            this.lblModelName.Text = "モデル名";
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(127, 58);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.Size = new System.Drawing.Size(392, 25);
            this.tbModelName.TabIndex = 15;
            // 
            // ModelCreateEntranceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 238);
            this.Controls.Add(this.tbModelName);
            this.Controls.Add(this.cbModelName);
            this.Controls.Add(this.btnCollectionStart);
            this.Controls.Add(this.cbPurpose);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.lblModelName);
            this.Name = "ModelCreateEntranceForm";
            this.Text = "モデル作成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbModelName;
        private System.Windows.Forms.Button btnCollectionStart;
        private System.Windows.Forms.ComboBox cbPurpose;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox tbModelName;
    }
}