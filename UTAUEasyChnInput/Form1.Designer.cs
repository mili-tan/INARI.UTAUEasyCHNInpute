namespace UTAUEasyChnInput
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.listBoxWord = new System.Windows.Forms.ListBox();
            this.textBoxLyrics = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.listBoxTone = new System.Windows.Forms.ListBox();
            this.nPinyinRBox = new System.Windows.Forms.RadioButton();
            this.msIntPinyinRBox = new System.Windows.Forms.RadioButton();
            this.textBoxTone = new System.Windows.Forms.TextBox();
            this.checkBoxDisV = new System.Windows.Forms.CheckBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveBackgroundWorker
            // 
            this.SaveBackgroundWorker.WorkerReportsProgress = true;
            this.SaveBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SaveBackgroundWorker_DoWork);
            this.SaveBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SaveBackgroundWorker_RunWorkerCompleted);
            // 
            // listBoxWord
            // 
            this.listBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxWord.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.listBoxWord.FormattingEnabled = true;
            this.listBoxWord.ItemHeight = 20;
            this.listBoxWord.Location = new System.Drawing.Point(13, 29);
            this.listBoxWord.Name = "listBoxWord";
            this.listBoxWord.Size = new System.Drawing.Size(123, 122);
            this.listBoxWord.TabIndex = 0;
            this.listBoxWord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxWord_MouseDoubleClick);
            // 
            // textBoxLyrics
            // 
            this.textBoxLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLyrics.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLyrics.Location = new System.Drawing.Point(142, 9);
            this.textBoxLyrics.Multiline = true;
            this.textBoxLyrics.Name = "textBoxLyrics";
            this.textBoxLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLyrics.Size = new System.Drawing.Size(379, 142);
            this.textBoxLyrics.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.buttonSave.Location = new System.Drawing.Point(12, 159);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(124, 28);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "应用";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.buttonOK.Location = new System.Drawing.Point(526, 159);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(122, 28);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // listBoxTone
            // 
            this.listBoxTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxTone.Enabled = false;
            this.listBoxTone.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.listBoxTone.FormattingEnabled = true;
            this.listBoxTone.ItemHeight = 20;
            this.listBoxTone.Location = new System.Drawing.Point(528, 29);
            this.listBoxTone.Name = "listBoxTone";
            this.listBoxTone.Size = new System.Drawing.Size(120, 122);
            this.listBoxTone.TabIndex = 4;
            this.listBoxTone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxTone_MouseDoubleClick);
            // 
            // nPinyinRBox
            // 
            this.nPinyinRBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nPinyinRBox.AutoSize = true;
            this.nPinyinRBox.BackColor = System.Drawing.Color.Transparent;
            this.nPinyinRBox.Checked = true;
            this.nPinyinRBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.nPinyinRBox.Location = new System.Drawing.Point(142, 161);
            this.nPinyinRBox.Name = "nPinyinRBox";
            this.nPinyinRBox.Size = new System.Drawing.Size(85, 24);
            this.nPinyinRBox.TabIndex = 5;
            this.nPinyinRBox.TabStop = true;
            this.nPinyinRBox.Text = "NPinyin";
            this.nPinyinRBox.UseVisualStyleBackColor = false;
            // 
            // msIntPinyinRBox
            // 
            this.msIntPinyinRBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.msIntPinyinRBox.AutoSize = true;
            this.msIntPinyinRBox.BackColor = System.Drawing.Color.Transparent;
            this.msIntPinyinRBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msIntPinyinRBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.msIntPinyinRBox.Location = new System.Drawing.Point(405, 161);
            this.msIntPinyinRBox.Name = "msIntPinyinRBox";
            this.msIntPinyinRBox.Size = new System.Drawing.Size(116, 24);
            this.msIntPinyinRBox.TabIndex = 6;
            this.msIntPinyinRBox.Text = "MSIntPinyin";
            this.msIntPinyinRBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.msIntPinyinRBox.UseVisualStyleBackColor = false;
            // 
            // textBoxTone
            // 
            this.textBoxTone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTone.Enabled = false;
            this.textBoxTone.Font = new System.Drawing.Font("Microsoft YaHei UI", 7F);
            this.textBoxTone.Location = new System.Drawing.Point(528, 9);
            this.textBoxTone.Name = "textBoxTone";
            this.textBoxTone.Size = new System.Drawing.Size(120, 22);
            this.textBoxTone.TabIndex = 7;
            this.textBoxTone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxTone_KeyDown);
            // 
            // checkBoxDisV
            // 
            this.checkBoxDisV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDisV.AutoSize = true;
            this.checkBoxDisV.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDisV.Checked = true;
            this.checkBoxDisV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisV.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.checkBoxDisV.Location = new System.Drawing.Point(233, 162);
            this.checkBoxDisV.Name = "checkBoxDisV";
            this.checkBoxDisV.Size = new System.Drawing.Size(106, 24);
            this.checkBoxDisV.TabIndex = 8;
            this.checkBoxDisV.Text = "多音字决策";
            this.checkBoxDisV.UseVisualStyleBackColor = false;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCount.Enabled = false;
            this.textBoxCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 7F);
            this.textBoxCount.Location = new System.Drawing.Point(13, 9);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(123, 22);
            this.textBoxCount.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(657, 198);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.checkBoxDisV);
            this.Controls.Add(this.textBoxTone);
            this.Controls.Add(this.msIntPinyinRBox);
            this.Controls.Add(this.nPinyinRBox);
            this.Controls.Add(this.listBoxTone);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLyrics);
            this.Controls.Add(this.listBoxWord);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker SaveBackgroundWorker;
        private System.Windows.Forms.ListBox listBoxWord;
        private System.Windows.Forms.TextBox textBoxLyrics;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListBox listBoxTone;
        private System.Windows.Forms.RadioButton nPinyinRBox;
        private System.Windows.Forms.RadioButton msIntPinyinRBox;
        private System.Windows.Forms.TextBox textBoxTone;
        private System.Windows.Forms.CheckBox checkBoxDisV;
        private System.Windows.Forms.TextBox textBoxCount;
    }
}

