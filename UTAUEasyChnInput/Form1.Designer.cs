﻿namespace UTAUEasyChnInput
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
            this.nPinyinR = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SaveBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.textBoxTone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxWord
            // 
            this.listBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWord.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.listBoxWord.FormattingEnabled = true;
            this.listBoxWord.ItemHeight = 20;
            this.listBoxWord.Location = new System.Drawing.Point(13, 9);
            this.listBoxWord.Name = "listBoxWord";
            this.listBoxWord.Size = new System.Drawing.Size(123, 144);
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
            this.textBoxLyrics.Size = new System.Drawing.Size(379, 144);
            this.textBoxLyrics.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.buttonSave.Location = new System.Drawing.Point(12, 159);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(124, 28);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "应用";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.buttonOK.Location = new System.Drawing.Point(526, 159);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(122, 28);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // listBoxTone
            // 
            this.listBoxTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTone.Enabled = false;
            this.listBoxTone.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.listBoxTone.FormattingEnabled = true;
            this.listBoxTone.ItemHeight = 20;
            this.listBoxTone.Location = new System.Drawing.Point(528, 29);
            this.listBoxTone.Name = "listBoxTone";
            this.listBoxTone.Size = new System.Drawing.Size(120, 124);
            this.listBoxTone.TabIndex = 4;
            this.listBoxTone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxTone_MouseDoubleClick);
            // 
            // nPinyinR
            // 
            this.nPinyinR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nPinyinR.AutoSize = true;
            this.nPinyinR.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.nPinyinR.Location = new System.Drawing.Point(142, 161);
            this.nPinyinR.Name = "nPinyinR";
            this.nPinyinR.Size = new System.Drawing.Size(85, 24);
            this.nPinyinR.TabIndex = 5;
            this.nPinyinR.TabStop = true;
            this.nPinyinR.Text = "NPinyin";
            this.nPinyinR.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.radioButton1.Location = new System.Drawing.Point(405, 161);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(116, 24);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "MSIntPinyin";
            this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // SaveBackgroundWorker
            // 
            this.SaveBackgroundWorker.WorkerReportsProgress = true;
            this.SaveBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SaveBackgroundWorker_DoWork);
            this.SaveBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SaveBackgroundWorker_RunWorkerCompleted);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 198);
            this.Controls.Add(this.textBoxTone);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.nPinyinR);
            this.Controls.Add(this.listBoxTone);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLyrics);
            this.Controls.Add(this.listBoxWord);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.RadioButton nPinyinR;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.ComponentModel.BackgroundWorker SaveBackgroundWorker;
        private System.Windows.Forms.TextBox textBoxTone;
    }
}

