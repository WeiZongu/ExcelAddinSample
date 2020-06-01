namespace ExcelAddInSample
{
    partial class ModelApplyForm
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
            this.grSelect = new System.Windows.Forms.GroupBox();
            this.cbHowToModelID = new System.Windows.Forms.ComboBox();
            this.cbModelID = new System.Windows.Forms.ComboBox();
            this.tbInputModelID = new System.Windows.Forms.TextBox();
            this.btnExec = new System.Windows.Forms.Button();
            this.grSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grSelect
            // 
            this.grSelect.Controls.Add(this.cbHowToModelID);
            this.grSelect.Controls.Add(this.cbModelID);
            this.grSelect.Controls.Add(this.tbInputModelID);
            this.grSelect.Location = new System.Drawing.Point(22, 21);
            this.grSelect.Name = "grSelect";
            this.grSelect.Size = new System.Drawing.Size(765, 139);
            this.grSelect.TabIndex = 1;
            this.grSelect.TabStop = false;
            this.grSelect.Text = "モデルID";
            // 
            // cbHowToModelID
            // 
            this.cbHowToModelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHowToModelID.FormattingEnabled = true;
            this.cbHowToModelID.Items.AddRange(new object[] {
            "モデルID選択",
            "モデルID手入力"});
            this.cbHowToModelID.Location = new System.Drawing.Point(14, 41);
            this.cbHowToModelID.Name = "cbHowToModelID";
            this.cbHowToModelID.Size = new System.Drawing.Size(190, 26);
            this.cbHowToModelID.TabIndex = 6;
            this.cbHowToModelID.SelectedValueChanged += new System.EventHandler(this.ListChanged);
            // 
            // cbModelID
            // 
            this.cbModelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelID.FormattingEnabled = true;
            this.cbModelID.Location = new System.Drawing.Point(224, 41);
            this.cbModelID.Name = "cbModelID";
            this.cbModelID.Size = new System.Drawing.Size(523, 26);
            this.cbModelID.TabIndex = 5;
            // 
            // tbInputModelID
            // 
            this.tbInputModelID.Location = new System.Drawing.Point(224, 94);
            this.tbInputModelID.Name = "tbInputModelID";
            this.tbInputModelID.Size = new System.Drawing.Size(523, 25);
            this.tbInputModelID.TabIndex = 0;
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(618, 213);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(169, 42);
            this.btnExec.TabIndex = 8;
            this.btnExec.Text = "モデル適用";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.ModelApplied);
            // 
            // ModelApplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 277);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.grSelect);
            this.Name = "ModelApplyForm";
            this.Text = "モデル適用";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.grSelect.ResumeLayout(false);
            this.grSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grSelect;
        private System.Windows.Forms.TextBox tbInputModelID;
        private System.Windows.Forms.ComboBox cbModelID;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.ComboBox cbHowToModelID;
    }
}