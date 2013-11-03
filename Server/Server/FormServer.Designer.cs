namespace Server
{
    partial class FormServer
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
            this.buttonInit = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxMaxUsers = new System.Windows.Forms.TextBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.radioButtonMode1 = new System.Windows.Forms.RadioButton();
            this.radioButtonMode2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(261, 502);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(75, 23);
            this.buttonInit.TabIndex = 0;
            this.buttonInit.Text = "启动服务";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(261, 540);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "开始游戏";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(261, 582);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "停止游戏";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "允许同时参加游戏的最多人数 (1-60) : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "游戏轮数 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "每轮游戏时间(ms) : ";
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(291, 420);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(45, 21);
            this.textBoxPeriod.TabIndex = 6;
            this.textBoxPeriod.Text = "5000";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(291, 378);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(45, 21);
            this.textBoxCount.TabIndex = 7;
            this.textBoxCount.Text = "10";
            // 
            // textBoxMaxUsers
            // 
            this.textBoxMaxUsers.Location = new System.Drawing.Point(291, 340);
            this.textBoxMaxUsers.Name = "textBoxMaxUsers";
            this.textBoxMaxUsers.Size = new System.Drawing.Size(45, 21);
            this.textBoxMaxUsers.TabIndex = 8;
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 12;
            this.listBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(324, 316);
            this.listBoxInfo.TabIndex = 9;
            // 
            // radioButtonMode1
            // 
            this.radioButtonMode1.AutoSize = true;
            this.radioButtonMode1.Checked = true;
            this.radioButtonMode1.Location = new System.Drawing.Point(133, 458);
            this.radioButtonMode1.Name = "radioButtonMode1";
            this.radioButtonMode1.Size = new System.Drawing.Size(203, 16);
            this.radioButtonMode1.TabIndex = 10;
            this.radioButtonMode1.TabStop = true;
            this.radioButtonMode1.Text = "每个客户程序必须提交一个有理数";
            this.radioButtonMode1.UseVisualStyleBackColor = true;
            // 
            // radioButtonMode2
            // 
            this.radioButtonMode2.AutoSize = true;
            this.radioButtonMode2.Location = new System.Drawing.Point(133, 480);
            this.radioButtonMode2.Name = "radioButtonMode2";
            this.radioButtonMode2.Size = new System.Drawing.Size(203, 16);
            this.radioButtonMode2.TabIndex = 11;
            this.radioButtonMode2.Text = "每个客户程序必须提交两个有理数";
            this.radioButtonMode2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "游戏规则 : ";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(362, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(610, 687);
            this.webBrowser1.TabIndex = 13;
            this.webBrowser1.Url = new System.Uri("D:\\coding\\现代程序设计\\现代程序设计作业5\\Server\\Server\\showImage.html", System.UriKind.Absolute);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonMode2);
            this.Controls.Add(this.radioButtonMode1);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.textBoxMaxUsers);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxPeriod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonInit);
            this.Name = "FormServer";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxMaxUsers;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.RadioButton radioButtonMode1;
        private System.Windows.Forms.RadioButton radioButtonMode2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

