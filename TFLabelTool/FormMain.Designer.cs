﻿namespace TFLabelTool
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonOpenImageFolder = new System.Windows.Forms.Button();
            this.buttonAddObj = new System.Windows.Forms.Button();
            this.textBoxAddObj = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.textBoxImport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.listBoxLableIndex = new System.Windows.Forms.ListBox();
            this.listBoxLable = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelVideo = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownZoomWidth = new System.Windows.Forms.NumericUpDown();
            this.labelCount = new System.Windows.Forms.Label();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.textBoxPreName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImportDownload = new System.Windows.Forms.Button();
            this.progressBarDownloadImage = new System.Windows.Forms.ProgressBar();
            this.buttonClearDownloadFolder = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonOpenDownloadPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDownlaodImage = new System.Windows.Forms.Button();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownImportHeight = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoomWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImportHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1192, 549);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.numericUpDownImportHeight);
            this.tabPage1.Controls.Add(this.buttonOpenImageFolder);
            this.tabPage1.Controls.Add(this.buttonAddObj);
            this.tabPage1.Controls.Add(this.textBoxAddObj);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonImport);
            this.tabPage1.Controls.Add(this.textBoxImport);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.buttonClear);
            this.tabPage1.Controls.Add(this.listBoxLableIndex);
            this.tabPage1.Controls.Add(this.listBoxLable);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.listBoxFiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1184, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "标注";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonOpenImageFolder
            // 
            this.buttonOpenImageFolder.Location = new System.Drawing.Point(114, 22);
            this.buttonOpenImageFolder.Name = "buttonOpenImageFolder";
            this.buttonOpenImageFolder.Size = new System.Drawing.Size(110, 19);
            this.buttonOpenImageFolder.TabIndex = 26;
            this.buttonOpenImageFolder.Text = "打开图片文件夹";
            this.buttonOpenImageFolder.UseVisualStyleBackColor = true;
            this.buttonOpenImageFolder.Click += new System.EventHandler(this.buttonOpenImageFolder_Click);
            // 
            // buttonAddObj
            // 
            this.buttonAddObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddObj.Location = new System.Drawing.Point(1127, 27);
            this.buttonAddObj.Name = "buttonAddObj";
            this.buttonAddObj.Size = new System.Drawing.Size(49, 21);
            this.buttonAddObj.TabIndex = 25;
            this.buttonAddObj.Text = "添加";
            this.buttonAddObj.UseVisualStyleBackColor = true;
            this.buttonAddObj.Click += new System.EventHandler(this.buttonAddObj_Click);
            // 
            // textBoxAddObj
            // 
            this.textBoxAddObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddObj.Location = new System.Drawing.Point(1052, 28);
            this.textBoxAddObj.Name = "textBoxAddObj";
            this.textBoxAddObj.Size = new System.Drawing.Size(68, 21);
            this.textBoxAddObj.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1017, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "对象：";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1022, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "标注信息";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(892, 20);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 21);
            this.buttonImport.TabIndex = 21;
            this.buttonImport.Text = "导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // textBoxImport
            // 
            this.textBoxImport.Location = new System.Drawing.Point(306, 22);
            this.textBoxImport.Name = "textBoxImport";
            this.textBoxImport.Size = new System.Drawing.Size(445, 21);
            this.textBoxImport.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "图像文件夹:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(4, 22);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(110, 19);
            this.buttonClear.TabIndex = 18;
            this.buttonClear.Text = "删除无对应txt图片";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // listBoxLableIndex
            // 
            this.listBoxLableIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLableIndex.FormattingEnabled = true;
            this.listBoxLableIndex.ItemHeight = 12;
            this.listBoxLableIndex.Location = new System.Drawing.Point(1020, 49);
            this.listBoxLableIndex.Name = "listBoxLableIndex";
            this.listBoxLableIndex.Size = new System.Drawing.Size(156, 208);
            this.listBoxLableIndex.TabIndex = 8;
            this.listBoxLableIndex.SelectedIndexChanged += new System.EventHandler(this.listBoxLableIndex_SelectedIndexChanged);
            this.listBoxLableIndex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxLableIndex_KeyUp);
            // 
            // listBoxLable
            // 
            this.listBoxLable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLable.FormattingEnabled = true;
            this.listBoxLable.HorizontalScrollbar = true;
            this.listBoxLable.ItemHeight = 12;
            this.listBoxLable.Location = new System.Drawing.Point(1022, 279);
            this.listBoxLable.Name = "listBoxLable";
            this.listBoxLable.Size = new System.Drawing.Size(156, 232);
            this.listBoxLable.TabIndex = 5;
            this.listBoxLable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxLable_MouseClick);
            this.listBoxLable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxLable_KeyUp);
            this.listBoxLable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxLable_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.linkLabelVideo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(230, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 459);
            this.panel1.TabIndex = 3;
            // 
            // linkLabelVideo
            // 
            this.linkLabelVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelVideo.AutoSize = true;
            this.linkLabelVideo.Location = new System.Drawing.Point(715, 15);
            this.linkLabelVideo.Name = "linkLabelVideo";
            this.linkLabelVideo.Size = new System.Drawing.Size(53, 12);
            this.linkLabelVideo.TabIndex = 2;
            this.linkLabelVideo.TabStop = true;
            this.linkLabelVideo.Text = "视频教程";
            this.linkLabelVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelVideo_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(15, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(164, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(502, 163);
            this.label7.TabIndex = 1;
            this.label7.Text = "使用说明\r\n1、使用导入图像功能，将jpg文件导入到程序执行目录的output/image目录下\r\n2、添加自己的对象\r\n3、选择一张图像，左键拖动选框，右键图像" +
    "生成标注文件，并跳到下一张\r\n4、每个列表都可以按delete键，删除选中项\r\n5、qq群 227118288";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.ItemHeight = 12;
            this.listBoxFiles.Location = new System.Drawing.Point(8, 49);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(216, 460);
            this.listBoxFiles.TabIndex = 2;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            this.listBoxFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxFiles_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1184, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下载";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDownZoomWidth);
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Controls.Add(this.richTextBoxInfo);
            this.groupBox1.Controls.Add(this.textBoxPreName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonImportDownload);
            this.groupBox1.Controls.Add(this.progressBarDownloadImage);
            this.groupBox1.Controls.Add(this.buttonClearDownloadFolder);
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.buttonOpenDownloadPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonDownlaodImage);
            this.groupBox1.Controls.Add(this.numericUpDownCount);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 487);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "下载图片";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "缩放宽高：";
            // 
            // numericUpDownZoomWidth
            // 
            this.numericUpDownZoomWidth.Location = new System.Drawing.Point(125, 141);
            this.numericUpDownZoomWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownZoomWidth.Name = "numericUpDownZoomWidth";
            this.numericUpDownZoomWidth.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownZoomWidth.TabIndex = 14;
            this.numericUpDownZoomWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(484, 214);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(41, 12);
            this.labelCount.TabIndex = 12;
            this.labelCount.Text = "label8";
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BackColor = System.Drawing.SystemColors.MenuText;
            this.richTextBoxInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxInfo.Location = new System.Drawing.Point(27, 366);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(862, 117);
            this.richTextBoxInfo.TabIndex = 11;
            this.richTextBoxInfo.Text = "";
            // 
            // textBoxPreName
            // 
            this.textBoxPreName.Location = new System.Drawing.Point(123, 107);
            this.textBoxPreName.Name = "textBoxPreName";
            this.textBoxPreName.Size = new System.Drawing.Size(142, 21);
            this.textBoxPreName.TabIndex = 10;
            this.textBoxPreName.Text = "car";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "文件前缀";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "图片关键字";
            // 
            // buttonImportDownload
            // 
            this.buttonImportDownload.Location = new System.Drawing.Point(271, 322);
            this.buttonImportDownload.Name = "buttonImportDownload";
            this.buttonImportDownload.Size = new System.Drawing.Size(99, 21);
            this.buttonImportDownload.TabIndex = 8;
            this.buttonImportDownload.Text = "导入到标注文件夹";
            this.buttonImportDownload.UseVisualStyleBackColor = true;
            this.buttonImportDownload.Click += new System.EventHandler(this.buttonImportDownload_Click);
            // 
            // progressBarDownloadImage
            // 
            this.progressBarDownloadImage.Location = new System.Drawing.Point(53, 206);
            this.progressBarDownloadImage.Name = "progressBarDownloadImage";
            this.progressBarDownloadImage.Size = new System.Drawing.Size(408, 21);
            this.progressBarDownloadImage.TabIndex = 0;
            // 
            // buttonClearDownloadFolder
            // 
            this.buttonClearDownloadFolder.Location = new System.Drawing.Point(155, 322);
            this.buttonClearDownloadFolder.Name = "buttonClearDownloadFolder";
            this.buttonClearDownloadFolder.Size = new System.Drawing.Size(88, 21);
            this.buttonClearDownloadFolder.TabIndex = 7;
            this.buttonClearDownloadFolder.Text = "清空文件夹";
            this.buttonClearDownloadFolder.UseVisualStyleBackColor = true;
            this.buttonClearDownloadFolder.Click += new System.EventHandler(this.buttonClearDownloadFolder_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(123, 24);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(192, 21);
            this.textBoxKey.TabIndex = 2;
            // 
            // buttonOpenDownloadPath
            // 
            this.buttonOpenDownloadPath.Location = new System.Drawing.Point(53, 322);
            this.buttonOpenDownloadPath.Name = "buttonOpenDownloadPath";
            this.buttonOpenDownloadPath.Size = new System.Drawing.Size(88, 21);
            this.buttonOpenDownloadPath.TabIndex = 6;
            this.buttonOpenDownloadPath.Text = "打开文件夹";
            this.buttonOpenDownloadPath.UseVisualStyleBackColor = true;
            this.buttonOpenDownloadPath.Click += new System.EventHandler(this.buttonOpenDownloadPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "抓取张数";
            // 
            // buttonDownlaodImage
            // 
            this.buttonDownlaodImage.Location = new System.Drawing.Point(53, 244);
            this.buttonDownlaodImage.Name = "buttonDownlaodImage";
            this.buttonDownlaodImage.Size = new System.Drawing.Size(212, 50);
            this.buttonDownlaodImage.TabIndex = 5;
            this.buttonDownlaodImage.Text = "启动";
            this.buttonDownlaodImage.UseVisualStyleBackColor = true;
            this.buttonDownlaodImage.Click += new System.EventHandler(this.buttonDownlaodImage_Click);
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(123, 65);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownCount.TabIndex = 4;
            this.numericUpDownCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(755, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "缩放宽高：";
            // 
            // numericUpDownImportHeight
            // 
            this.numericUpDownImportHeight.Location = new System.Drawing.Point(825, 19);
            this.numericUpDownImportHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownImportHeight.Name = "numericUpDownImportHeight";
            this.numericUpDownImportHeight.Size = new System.Drawing.Size(45, 21);
            this.numericUpDownImportHeight.TabIndex = 28;
            this.numericUpDownImportHeight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 549);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "tensorflow 对象检测接口图片标注工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoomWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImportHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxLableIndex;
        private System.Windows.Forms.ListBox listBoxLable;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddObj;
        private System.Windows.Forms.TextBox textBoxAddObj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TextBox textBoxImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonImportDownload;
        private System.Windows.Forms.ProgressBar progressBarDownloadImage;
        private System.Windows.Forms.Button buttonClearDownloadFolder;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonOpenDownloadPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDownlaodImage;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.TextBox textBoxPreName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownZoomWidth;
        private System.Windows.Forms.Button buttonOpenImageFolder;
        private System.Windows.Forms.LinkLabel linkLabelVideo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownImportHeight;
    }
}

