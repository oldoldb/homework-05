using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Cilent
{
    public partial class FormClient : Form
    {
        //变量
        #region
        private int maxUser;
        private TcpClient client = null;
        private StreamReader sr;
        private StreamWriter sw;
        private Service service;
        private bool normalExit = false;
        private double sendNumber;
        private double sendNumber2;
        private int mode = 0;
        private bool isRandom = false;//随机模式是否开启
        #endregion

        public FormClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//允许跨线程操作控件
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            textBoxName.Text = "Player" + rd.Next(1, 100);
            maxUser = 0;
            textBoxLocal.ReadOnly = true;
            textBoxServer.ReadOnly = true;
            textBoxNumber.Enabled = false;
            buttonSend.Enabled = false;
            checkBoxRandom.Enabled = true;
            checkBoxRandom.Checked = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //仅作本机测试，实际使用时要将Dns.GetHostName()改为服务器域名
            //    client = new TcpClient(Dns.GetHostName(), 51888);
                client = new TcpClient(AddressFamily.InterNetwork);
                client.Connect("192.168.114.43", 51888);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBoxLocal.Text = client.Client.LocalEndPoint.ToString();
            textBoxServer.Text = client.Client.RemoteEndPoint.ToString();
            if (checkBoxRandom.Checked)
            {
                isRandom = true;
            }
            buttonLogin.Enabled = false;
            radioButtonMode1.Enabled = false;
            radioButtonMode2.Enabled = false;
            checkBoxRandom.Enabled = false;
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, System.Text.Encoding.UTF8);
            sw = new StreamWriter(netStream, System.Text.Encoding.UTF8);
            service = new Service(listBoxInfo, sw);
            service.sendToServer("login," + textBoxName.Text.Trim());
            textBoxNumber.Enabled = true;
            Thread threadReceive = new Thread(new ThreadStart(receiveData));
            threadReceive.Start();
        }
        
        private void receiveData()
        {
            bool isExist = true;
            while (isExist)
            {
                string receiveString = null;
                try
                {
                    receiveString = sr.ReadLine();
                }
                catch
                {
                    service.addItemToListBox("接收数据失败");
                }
                if (receiveString == null)
                {
                    if (normalExit == false)
                    {
                        MessageBox.Show("与服务器失去联系,游戏无法继续");
                    }
                    normalExit = true;
                    break;
                }
                service.addItemToListBox("收到: " + receiveString);
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                if (!(command[0] >= 'a' && command[0] <= 'z'))
                {
                    command = command.Substring(1);
                }
                switch (command)
                {
                    case "sorry":
                        MessageBox.Show("连接成功,但游戏人数已满或者用户名已存在,无法进入.");
                        isExist = false;
                        break;
                    case "pause":
                        buttonSend.Enabled = false;
                        break;
                    case "start":
                        service.addItemToListBox("收到: " + receiveString);
                        if (isRandom)
                        {
                            randomSend();
                        }
                        else
                        {
                            buttonSend.Enabled = true;
                        }
                        break;
                    case "success":
                        service.addItemToListBox("本轮向服务器提交答案成功,等待下一轮游戏开始");
                        buttonSend.Enabled = false;
                        break;
                    case "result":
                        service.addItemToListBox(string.Format("上一轮游戏结果:　Gnum is {0}, winner is {1}.", splitString[1], splitString[2]));
                        break;
                    case "mode":
                        if (splitString[1] == "0")
                        {
                            mode = 0;
                            radioButtonMode1.Checked = true;
                            radioButtonMode2.Checked = false;
                            radioButtonMode1.Enabled = false;
                            radioButtonMode2.Enabled = false;
                            textBoxNumber2.Enabled = false;
                            service.addItemToListBox(string.Format("本轮游戏模式为: 每个客户程序必须提交一个有理数"));
                        }
                        else
                        {
                            mode = 1;
                            radioButtonMode1.Checked = false;
                            radioButtonMode2.Checked = true;
                            radioButtonMode1.Enabled = false;
                            radioButtonMode2.Enabled = false;
                            textBoxNumber2.Enabled = true;
                            service.addItemToListBox(string.Format("本轮游戏模式为: 每个客户程序必须提交两个有理数(任何一个数字最接近G-number 则此客户程序就是优胜.)"));
                        }
                        break;
                    default: break;
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text == null)
            {
                MessageBox.Show("请输入你的答案");
                return;
            }
            if (double.TryParse(textBoxNumber.Text, out sendNumber) == false)
            {
                MessageBox.Show("请输入合法的有理数");
                return;
            }
            if (sendNumber <= 0 || sendNumber >= 100)
            {
                MessageBox.Show("输入的数字在0-100之间(开区间)!");
                return;
            }
            if (mode == 1)
            {
                if (double.TryParse(textBoxNumber.Text, out sendNumber2) == false)
                {
                    MessageBox.Show("请输入合法的有理数");
                    return;
                }
                if (sendNumber2 <= 0 || sendNumber2 >= 100)
                {
                    MessageBox.Show("输入的数字在0-100之间(开区间)!");
                    return;
                }
            }
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, System.Text.Encoding.UTF8);
            sw = new StreamWriter(netStream, System.Text.Encoding.UTF8);
            service = new Service(listBoxInfo, sw);
            if (mode == 0)
            {
                service.sendToServer(string.Format("send,{0}", sendNumber));
            }
            else
            {
                service.sendToServer(string.Format("send,{0},{1}", sendNumber, sendNumber2));
            }
        }

        private void randomSend()
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            sendNumber = rd.Next(1, 100);
            if (mode == 1)
            {
                sendNumber2 = rd.Next(1, 100);
            }
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, System.Text.Encoding.UTF8);
            sw = new StreamWriter(netStream, System.Text.Encoding.UTF8);
            service = new Service(listBoxInfo, sw);
            if (mode == 0)
            {
                service.sendToServer(string.Format("send,{0}", sendNumber));
                service.addItemToListBox(string.Format("send,{0}", sendNumber));
            }
            else
            {
                service.sendToServer(string.Format("send,{0},{1}", sendNumber, sendNumber2));
                service.addItemToListBox(string.Format("send,{0},{1}", sendNumber, sendNumber2));
            }
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                if (normalExit == false)
                {
                    normalExit = true;
                    service.sendToServer("logout");
                }
                client.Close();
            }
        }
    }
}
