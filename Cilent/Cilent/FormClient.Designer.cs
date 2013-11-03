namespace Cilent
{
    partial class FormClient
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxNumber2 = new System.Windows.Forms.TextBox();
            this.radioButtonMode1 = new System.Windows.Forms.RadioButton();
            this.radioButtonMode2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxRandom = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(202, 143);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "登录";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(471, 143);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "提交";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "本机 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "服务器 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "你的答案 : ";
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 12;
            this.listBoxInfo.Location = new System.Drawing.Point(8, 201);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(764, 340);
            this.listBoxInfo.TabIndex = 6;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(202, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 7;
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(202, 60);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(100, 21);
            this.textBoxLocal.TabIndex = 8;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(202, 101);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(100, 21);
            this.textBoxServer.TabIndex = 9;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(446, 60);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 21);
            this.textBoxNumber.TabIndex = 10;
            // 
            // textBoxNumber2
            // 
            this.textBoxNumber2.Location = new System.Drawing.Point(446, 100);
            this.textBoxNumber2.Name = "textBoxNumber2";
            this.textBoxNumber2.Size = new System.Drawing.Size(100, 21);
            this.textBoxNumber2.TabIndex = 13;
            // 
            // radioButtonMode1
            // 
            this.radioButtonMode1.AutoSize = true;
            this.radioButtonMode1.Location = new System.Drawing.Point(446, 19);
            this.radioButtonMode1.Name = "radioButtonMode1";
            this.radioButtonMode1.Size = new System.Drawing.Size(203, 16);
            this.radioButtonMode1.TabIndex = 14;
            this.radioButtonMode1.TabStop = true;
            this.radioButtonMode1.Text = "每个客户程序必须提交一个有理数";
            this.radioButtonMode1.UseVisualStyleBackColor = true;
            // 
            // radioButtonMode2
            // 
            this.radioButtonMode2.AutoSize = true;
            this.radioButtonMode2.Location = new System.Drawing.Point(446, 41);
            this.radioButtonMode2.Name = "radioButtonMode2";
            this.radioButtonMode2.Size = new System.Drawing.Size(203, 16);
            this.radioButtonMode2.TabIndex = 15;
            this.radioButtonMode2.TabStop = true;
            this.radioButtonMode2.Text = "每个客户程序必须提交两个有理数";
            this.radioButtonMode2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "游戏模式 : ";
            // 
            // checkBoxRandom
            // 
            this.checkBoxRandom.AutoSize = true;
            this.checkBoxRandom.Location = new System.Drawing.Point(362, 147);
            this.checkBoxRandom.Name = "checkBoxRandom";
            this.checkBoxRandom.Size = new System.Drawing.Size(96, 16);
            this.checkBoxRandom.TabIndex = 17;
            this.checkBoxRandom.Text = "自动随机提交";
            this.checkBoxRandom.UseVisualStyleBackColor = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.checkBoxRandom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButtonMode2);
            this.Controls.Add(this.radioButtonMode1);
            this.Controls.Add(this.textBoxNumber2);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonLogin);
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxNumber2;
        private System.Windows.Forms.RadioButton radioButtonMode1;
        private System.Windows.Forms.RadioButton radioButtonMode2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxRandom;
    }
}

