namespace ExcelAddInSample
{
    partial class ModelCreateForm
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
            this.btnModelCreate = new System.Windows.Forms.Button();
            this.btnSummaryCollection = new System.Windows.Forms.Button();
            this.grCollection = new System.Windows.Forms.GroupBox();
            this.dgvCollection = new System.Windows.Forms.DataGridView();
            this.pnUnder = new System.Windows.Forms.Panel();
            this.tbLoPnMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbSelectOutFolder = new System.Windows.Forms.GroupBox();
            this.btnSelectOutFolder = new System.Windows.Forms.Button();
            this.tbSelectOutFolder = new System.Windows.Forms.TextBox();
            this.colTPredictionTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAnalysisTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDataItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUniqueNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grCollection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollection)).BeginInit();
            this.pnUnder.SuspendLayout();
            this.tbLoPnMain.SuspendLayout();
            this.gbSelectOutFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModelCreate
            // 
            this.btnModelCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnModelCreate.Location = new System.Drawing.Point(673, 0);
            this.btnModelCreate.Name = "btnModelCreate";
            this.btnModelCreate.Size = new System.Drawing.Size(128, 53);
            this.btnModelCreate.TabIndex = 8;
            this.btnModelCreate.Text = "モデルを作成";
            this.btnModelCreate.UseVisualStyleBackColor = true;
            this.btnModelCreate.Click += new System.EventHandler(this.ExecModelCreate);
            // 
            // btnSummaryCollection
            // 
            this.btnSummaryCollection.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSummaryCollection.Location = new System.Drawing.Point(467, 0);
            this.btnSummaryCollection.Name = "btnSummaryCollection";
            this.btnSummaryCollection.Size = new System.Drawing.Size(206, 53);
            this.btnSummaryCollection.TabIndex = 7;
            this.btnSummaryCollection.Text = "全てのサマリを表示";
            this.btnSummaryCollection.UseVisualStyleBackColor = true;
            this.btnSummaryCollection.Click += new System.EventHandler(this.SummaryCollection);
            // 
            // grCollection
            // 
            this.grCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grCollection.Controls.Add(this.dgvCollection);
            this.grCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCollection.Location = new System.Drawing.Point(3, 3);
            this.grCollection.Name = "grCollection";
            this.grCollection.Size = new System.Drawing.Size(795, 415);
            this.grCollection.TabIndex = 5;
            this.grCollection.TabStop = false;
            this.grCollection.Text = "学習データのサマリ";
            // 
            // dgvCollection
            // 
            this.dgvCollection.AllowUserToAddRows = false;
            this.dgvCollection.AllowUserToDeleteRows = false;
            this.dgvCollection.AllowUserToResizeRows = false;
            this.dgvCollection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTPredictionTarget,
            this.colAnalysisTarget,
            this.colDataItem,
            this.colType,
            this.colValue,
            this.colUniqueNum});
            this.dgvCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollection.Location = new System.Drawing.Point(3, 21);
            this.dgvCollection.MultiSelect = false;
            this.dgvCollection.Name = "dgvCollection";
            this.dgvCollection.RowHeadersWidth = 62;
            this.dgvCollection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCollection.RowTemplate.Height = 40;
            this.dgvCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCollection.Size = new System.Drawing.Size(789, 391);
            this.dgvCollection.TabIndex = 4;
            this.dgvCollection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateCollectionList);
            this.dgvCollection.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueChanged);
            // 
            // pnUnder
            // 
            this.pnUnder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnUnder.Controls.Add(this.btnSummaryCollection);
            this.pnUnder.Controls.Add(this.btnModelCreate);
            this.pnUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnUnder.Location = new System.Drawing.Point(0, 496);
            this.pnUnder.Name = "pnUnder";
            this.pnUnder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnUnder.Size = new System.Drawing.Size(801, 53);
            this.pnUnder.TabIndex = 9;
            // 
            // tbLoPnMain
            // 
            this.tbLoPnMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbLoPnMain.ColumnCount = 1;
            this.tbLoPnMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLoPnMain.Controls.Add(this.gbSelectOutFolder, 0, 1);
            this.tbLoPnMain.Controls.Add(this.grCollection, 0, 0);
            this.tbLoPnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLoPnMain.Location = new System.Drawing.Point(0, 0);
            this.tbLoPnMain.Name = "tbLoPnMain";
            this.tbLoPnMain.RowCount = 2;
            this.tbLoPnMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tbLoPnMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tbLoPnMain.Size = new System.Drawing.Size(801, 496);
            this.tbLoPnMain.TabIndex = 10;
            // 
            // gbSelectOutFolder
            // 
            this.gbSelectOutFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSelectOutFolder.Controls.Add(this.btnSelectOutFolder);
            this.gbSelectOutFolder.Controls.Add(this.tbSelectOutFolder);
            this.gbSelectOutFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSelectOutFolder.Location = new System.Drawing.Point(3, 424);
            this.gbSelectOutFolder.Name = "gbSelectOutFolder";
            this.gbSelectOutFolder.Size = new System.Drawing.Size(795, 57);
            this.gbSelectOutFolder.TabIndex = 6;
            this.gbSelectOutFolder.TabStop = false;
            this.gbSelectOutFolder.Text = "出力先選択";
            // 
            // btnSelectOutFolder
            // 
            this.btnSelectOutFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectOutFolder.Location = new System.Drawing.Point(717, 21);
            this.btnSelectOutFolder.Name = "btnSelectOutFolder";
            this.btnSelectOutFolder.Size = new System.Drawing.Size(75, 33);
            this.btnSelectOutFolder.TabIndex = 3;
            this.btnSelectOutFolder.Text = "・・・";
            this.btnSelectOutFolder.UseVisualStyleBackColor = true;
            this.btnSelectOutFolder.Click += new System.EventHandler(this.SelectedOutFolder);
            // 
            // tbSelectOutFolder
            // 
            this.tbSelectOutFolder.Location = new System.Drawing.Point(12, 24);
            this.tbSelectOutFolder.Name = "tbSelectOutFolder";
            this.tbSelectOutFolder.ReadOnly = true;
            this.tbSelectOutFolder.Size = new System.Drawing.Size(699, 25);
            this.tbSelectOutFolder.TabIndex = 2;
            // 
            // colTPredictionTarget
            // 
            this.colTPredictionTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colTPredictionTarget.Frozen = true;
            this.colTPredictionTarget.HeaderText = "a";
            this.colTPredictionTarget.MinimumWidth = 8;
            this.colTPredictionTarget.Name = "colTPredictionTarget";
            this.colTPredictionTarget.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTPredictionTarget.Width = 23;
            // 
            // colAnalysisTarget
            // 
            this.colAnalysisTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colAnalysisTarget.Frozen = true;
            this.colAnalysisTarget.HeaderText = "b";
            this.colAnalysisTarget.MinimumWidth = 8;
            this.colAnalysisTarget.Name = "colAnalysisTarget";
            this.colAnalysisTarget.Width = 23;
            // 
            // colDataItem
            // 
            this.colDataItem.Frozen = true;
            this.colDataItem.HeaderText = "c";
            this.colDataItem.MinimumWidth = 8;
            this.colDataItem.Name = "colDataItem";
            this.colDataItem.ReadOnly = true;
            this.colDataItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDataItem.Width = 23;
            // 
            // colType
            // 
            this.colType.Frozen = true;
            this.colType.HeaderText = "d";
            this.colType.Items.AddRange(new object[] {
            "数値",
            "カテゴリ",
            "テキスト"});
            this.colType.MinimumWidth = 8;
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.Width = 23;
            // 
            // colValue
            // 
            this.colValue.Frozen = true;
            this.colValue.HeaderText = "e";
            this.colValue.MinimumWidth = 8;
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 23;
            // 
            // colUniqueNum
            // 
            this.colUniqueNum.Frozen = true;
            this.colUniqueNum.HeaderText = "f";
            this.colUniqueNum.MinimumWidth = 8;
            this.colUniqueNum.Name = "colUniqueNum";
            this.colUniqueNum.ReadOnly = true;
            this.colUniqueNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUniqueNum.Width = 19;
            // 
            // ModelCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 549);
            this.Controls.Add(this.tbLoPnMain);
            this.Controls.Add(this.pnUnder);
            this.Name = "ModelCreateForm";
            this.Text = "モデル作成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.grCollection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollection)).EndInit();
            this.pnUnder.ResumeLayout(false);
            this.tbLoPnMain.ResumeLayout(false);
            this.gbSelectOutFolder.ResumeLayout(false);
            this.gbSelectOutFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModelCreate;
        private System.Windows.Forms.Button btnSummaryCollection;
        private System.Windows.Forms.GroupBox grCollection;
        private System.Windows.Forms.DataGridView dgvCollection;
        private System.Windows.Forms.Panel pnUnder;
        private System.Windows.Forms.TableLayoutPanel tbLoPnMain;
        private System.Windows.Forms.GroupBox gbSelectOutFolder;
        private System.Windows.Forms.Button btnSelectOutFolder;
        private System.Windows.Forms.TextBox tbSelectOutFolder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTPredictionTarget;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAnalysisTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUniqueNum;
    }
}