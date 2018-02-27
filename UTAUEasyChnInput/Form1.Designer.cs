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
            this.listBoxWord = new System.Windows.Forms.ListBox();
            this.textBoxLyrics = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.listBoxTone = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxWord
            // 
            this.listBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWord.FormattingEnabled = true;
            this.listBoxWord.ItemHeight = 15;
            this.listBoxWord.Location = new System.Drawing.Point(13, 13);
            this.listBoxWord.Name = "listBoxWord";
            this.listBoxWord.Size = new System.Drawing.Size(123, 139);
            this.listBoxWord.TabIndex = 0;
            this.listBoxWord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseDoubleClick);
            // 
            // textBoxLyrics
            // 
            this.textBoxLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLyrics.Location = new System.Drawing.Point(142, 13);
            this.textBoxLyrics.Multiline = true;
            this.textBoxLyrics.Name = "textBoxLyrics";
            this.textBoxLyrics.Size = new System.Drawing.Size(379, 139);
            this.textBoxLyrics.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(12, 163);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(124, 26);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(527, 163);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(122, 26);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // listBoxTone
            // 
            this.listBoxTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTone.FormattingEnabled = true;
            this.listBoxTone.ItemHeight = 15;
            this.listBoxTone.Location = new System.Drawing.Point(528, 13);
            this.listBoxTone.Name = "listBoxTone";
            this.listBoxTone.Size = new System.Drawing.Size(120, 139);
            this.listBoxTone.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 198);
            this.Controls.Add(this.listBoxTone);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLyrics);
            this.Controls.Add(this.listBoxWord);
            this.Name = "Form1";
            this.Text = "UTAUEasyChnInput";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxWord;
        private System.Windows.Forms.TextBox textBoxLyrics;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListBox listBoxTone;
    }
}

