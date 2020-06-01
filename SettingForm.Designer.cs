namespace ExcelAddInSample
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.lblURL = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.tbApiSecret = new System.Windows.Forms.TextBox();
            this.lblApiSecret = new System.Windows.Forms.Label();
            this.tbTimeOut = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(83, 45);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(41, 18);
            this.lblURL.TabIndex = 0;
            this.lblURL.Text = "URL";
            this.lblURL.Visible = false;
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(136, 42);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(590, 25);
            this.tbURL.TabIndex = 1;
            this.tbURL.Visible = false;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(63, 45);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(61, 18);
            this.lblApiKey.TabIndex = 2;
            this.lblApiKey.Text = "ApiKey";
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(136, 42);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(590, 25);
            this.tbApiKey.TabIndex = 3;
            // 
            // tbApiSecret
            // 
            this.tbApiSecret.Location = new System.Drawing.Point(136, 97);
            this.tbApiSecret.Name = "tbApiSecret";
            this.tbApiSecret.Size = new System.Drawing.Size(590, 25);
            this.tbApiSecret.TabIndex = 5;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(42, 100);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(82, 18);
            this.lblApiSecret.TabIndex = 4;
            this.lblApiSecret.Text = "ApiSecret";
            // 
            // tbTimeOut
            // 
            this.tbTimeOut.Location = new System.Drawing.Point(136, 206);
            this.tbTimeOut.Name = "tbTimeOut";
            this.tbTimeOut.Size = new System.Drawing.Size(98, 25);
            this.tbTimeOut.TabIndex = 7;
            this.tbTimeOut.Visible = false;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(42, 209);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(91, 18);
            this.lblTimeOut.TabIndex = 6;
            this.lblTimeOut.Text = "TimeOut値";
            this.lblTimeOut.Visible = false;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(240, 213);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(34, 18);
            this.lblSec.TabIndex = 8;
            this.lblSec.Text = "sec";
            this.lblSec.Visible = false;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(530, 158);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 37);
            this.btnSetting.TabIndex = 9;
            this.btnSetting.Text = "OK";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.OnSetting);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(615, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 37);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 232);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.tbTimeOut);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.tbApiSecret);
            this.Controls.Add(this.lblApiSecret);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.lblURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "アカウント設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.TextBox tbApiSecret;
        private System.Windows.Forms.Label lblApiSecret;
        private System.Windows.Forms.TextBox tbTimeOut;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnCancel;
    }
}