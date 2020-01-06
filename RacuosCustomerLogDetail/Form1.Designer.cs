namespace SoftPhoneLogDetail
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.txtReadFolder = new System.Windows.Forms.TextBox();
            this.txtReadFile = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnFolderSelect);
            this.splitContainer1.Panel1.Controls.Add(this.btnFileSelect);
            this.splitContainer1.Panel1.Controls.Add(this.btnDetails);
            this.splitContainer1.Panel1.Controls.Add(this.btnDetail);
            this.splitContainer1.Panel1.Controls.Add(this.txtReadFolder);
            this.splitContainer1.Panel1.Controls.Add(this.txtReadFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(926, 887);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(679, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 59);
            this.button1.TabIndex = 11;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClear.Location = new System.Drawing.Point(598, 26);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 59);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "初期化";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFolderSelect.Location = new System.Drawing.Point(436, 62);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFolderSelect.TabIndex = 8;
            this.btnFolderSelect.Text = "フォルダ選択";
            this.btnFolderSelect.UseVisualStyleBackColor = false;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFileSelect.Location = new System.Drawing.Point(436, 26);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect.TabIndex = 9;
            this.btnFileSelect.Text = "ファイル選択";
            this.btnFileSelect.UseVisualStyleBackColor = false;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.Aqua;
            this.btnDetails.Location = new System.Drawing.Point(517, 62);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "取込";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDetail.Location = new System.Drawing.Point(517, 26);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 7;
            this.btnDetail.Text = "取込";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // txtReadFolder
            // 
            this.txtReadFolder.Location = new System.Drawing.Point(40, 64);
            this.txtReadFolder.Name = "txtReadFolder";
            this.txtReadFolder.Size = new System.Drawing.Size(390, 19);
            this.txtReadFolder.TabIndex = 4;
            this.txtReadFolder.Text = "D:\\workspace\\logs\\";
            // 
            // txtReadFile
            // 
            this.txtReadFile.Location = new System.Drawing.Point(40, 28);
            this.txtReadFile.Name = "txtReadFile";
            this.txtReadFile.Size = new System.Drawing.Size(390, 19);
            this.txtReadFile.TabIndex = 5;
            this.txtReadFile.Text = "D:\\★ 0523\\logs\\customerPerformance.log_30.log";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(926, 776);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "画面ＩＤ";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "画面名";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CL起動数";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ＣＬ処理時間";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "SV呼出数";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ＳＶ処理時間";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ＣＬ平均時間";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ＳＶ平均時間";
            this.Column8.Name = "Column8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 887);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "【会員管理】クライアントログ分析";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.TextBox txtReadFolder;
        private System.Windows.Forms.TextBox txtReadFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

