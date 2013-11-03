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
using System.Drawing.Imaging;
namespace Server
{
    public partial class FormServer : Form
    {
        #region
        private int maxUsers;//最大用户数
        List<User> userList = new List<User>();//用户列表
        IPAddress localAddress;
        private int port = 51888;//端口
        private TcpListener myListener;
        private Service service;
        private double Gnum = 0;
        string winner = null;
        List<string> loser = new List<string>();//Loser列表,因为有并列情况
        List<double> history = new List<double>();//每轮的Gnum
        private int period = 10000;//每轮游戏持续时间ms
        private int count = 10;//游戏轮数
        private int tt = 1;//游戏轮次计数
        private int mode = 0;//模式 0:1个Number 1:2个number
        private int num = 0;
        private System.Timers.Timer timer;//计时器用作定时结束每轮游戏
        string[] format = new string[23];//这次没有用
        #endregion

        public FormServer()
        {
            InitializeComponent();
            service = new Service(listBoxInfo);
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            listBoxInfo.HorizontalScrollbar = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            textBoxCount.Enabled = false;
            textBoxPeriod.Enabled = false;

            IPAddress[] addrIP = Dns.GetHostAddresses(Dns.GetHostName());
            localAddress = addrIP[3];//ipv6,当然没有用到这次

//            MessageBox.Show(Convert.ToString(localAddress));
            period = int.Parse(textBoxPeriod.Text);
            count = int.Parse(textBoxCount.Text);
            timer=new System.Timers.Timer();
            timer.Interval=period;
            timer.Elapsed+=new System.Timers.ElapsedEventHandler(timerElapsed);
            timer.Enabled=false;
            webBrowser1.Url = new Uri(@"file:///D:/coding/现代程序设计/现代程序设计作业5/Server/Server/showImage.html");
         //   initFormat();
        }

        /*------这次没有用------*/
        #region
        private void initFormat()
        {
            format[0] = "$hehe";
            format[1] = "$haha";
            format[2] = "$xixi";
            for (int i = 3; i < 23; i++)
            {
                format[i] = "$" + Convert.ToString((char)(i - 3 + 'a'));
            }
        }
        private string getOnlineUserList()
        {
            string sendString = "";
            for (int i = 0; i < userList.Count; i++)
            {
                sendString += userList[i].userName + ",";
            }
            return sendString;
        }
        private void updateHTML()
        {
            StringBuilder htmltext = new StringBuilder();
            try
            {
                //模板页路径
                using (StreamReader sr = new StreamReader(@"D:\coding\现代程序设计\现代程序设计作业5\Server\Server\GameResult.html"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        htmltext.Append(line);
                    }
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show("读取html错误");
            }

            //---------------------给标记数组赋值------------ 
            string[] replace = new string[23];
            for (int i = 0; i < 23; i++)
            {
                replace[i] = "$";
            }
            replace[0] = Convert.ToString(Gnum);
            replace[1] = winner;
            replace[2] = loser[0];
            for (int i = 0; i < userList.Count; i++)
            {
                replace[i + 3] = userList[i].userName;
            }
            //----------替换htm里的标记为你想加的内容 
            for (int i = 0; i < 23; i++)
            {
                htmltext.Replace(format[i], string.Format("${0}", replace[i]));
                format[i] = string.Format("${0}", replace[i]);
            }

            //----------生成htm文件------------------―― 
            try
            {
                using (StreamWriter sw = new StreamWriter(@"D:\coding\现代程序设计\现代程序设计作业5\Server\Server\GameResult.html", false, System.Text.Encoding.GetEncoding("GB2312"))) //保存地址
                {
                    sw.WriteLine(htmltext);
                    sw.Flush();
                    sw.Close();

                }
            }
            catch
            {
                MessageBox.Show("写入html错误");
            }
            webBrowser1.Url = new Uri(@"D:\coding\现代程序设计\现代程序设计作业5\Server\Server\GameResult.html");
        }
        #endregion

        private void buttonInit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMaxUsers.Text, out maxUsers) == false)
            {
                MessageBox.Show("请输入在规定范围内的正整数！");
                return;
            }
            if (maxUsers < 1 || maxUsers > 60)
            {
                MessageBox.Show("允许人数只能在1-60之间!");
                return;
            }
            startWatch();
            buttonInit.Enabled = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = true;
        }
        /*------监听------*/
        private void startWatch()
        {
            myListener = new TcpListener(IPAddress.Any, port);
            myListener.Start();
            service.addItem(string.Format("开始在{0}:{1}监听客户连接", localAddress, port));
            ThreadStart listenThreadStart = new ThreadStart(listenClientRequest);
            Thread threadListenRequest = new Thread(listenThreadStart);
            threadListenRequest.Start();
        }
        /*------监听用户连接------*/
        private void listenClientRequest()
        {
            while (true)
            {
                TcpClient newClient = null;
                try
                {
                    newClient = myListener.AcceptTcpClient();
                }
                catch
                {
                    break;
                }
                ParameterizedThreadStart threadReceiveRequestStart = new ParameterizedThreadStart(receiveRequest);
                Thread threadReceiveRequest = new Thread(threadReceiveRequestStart);
                User user = new User(newClient);
                threadReceiveRequest.Start(user);
                service.addItem(string.Format(" {0} 尝试进入", newClient.Client.RemoteEndPoint));
                service.addItem(string.Format("当前连接用户数: {0}", userList.Count));
            }
        }
        /*------游戏过程中各种请求------*/
        private void receiveRequest(object obj)
        {
            User user = (User)obj;
            TcpClient client = user.client;
            bool normalExit = false;//正常退出
            bool isExist = true;//用户存在
            while(isExist)
            {
                string receiveString=null;
                try
                {
                    receiveString = user.sr.ReadLine();
                }
                catch
                {
                    service.addItem(string.Format("接收用户 {0} 数据失败!",user.userName));
                }
                if (receiveString == null)
                {
                    if (normalExit == false)
                    {
                        if (client.Connected == true)
                        {
                            service.addItem(string.Format("与 {0} 失去联系,已终止接收该用户信息", user.userName));
                        }
                    }
                    break;
                }
                service.addItem(string.Format("来自{0}:{1}", user.userName, receiveString));
                string[] splitString = receiveString.Split(',');
                string sendString = "";
                string command = splitString[0].ToLower();
                if (!(command[0] >= 'a' && command[0] <= 'z'))//保险一点好了..一开始有问题,现在应该没有了
                {
                    command = command.Substring(1);
                }
                switch (command)
                {
                    case "login":
                        if (userList.Count > maxUsers)
                        {
                            sendString = "sorry";
                            service.sendToOne(user, sendString);
                            service.addItem("人数已满,拒绝" + splitString[1] + "进入游戏");
                            isExist = false ;
                        }
                        else
                        {
                            bool flag = true;
                            for (int i = 0; i < userList.Count; i++)
                            {
                                if (userList[i].userName == splitString[1])
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                sendString = "sorry";
                                service.sendToOne(user, sendString);
                                service.addItem("用户名已存在，拒绝" + splitString[1] + "进入游戏");
                                isExist = false;
                            }
                            else
                            {
                                user.pos = num++;//用户进入先后顺序
                                userList.Add(user);
                                user.userName = splitString[1];
                                sendString = "success";
                                service.sendToOne(user, sendString);
                                service.addItem(string.Format("用户 {0} 加入游戏成功!", user.userName));
                            }
                        }
                        break;
                    case "logout":
                        service.addItem(string.Format("{0}退出游戏", user.userName));
                        normalExit = true;
                        isExist = false;
                        break;
                    case "send":
                        service.addItem(string.Format("{0}提交数据: {1},提交成功", user.userName, splitString[1]));
                        sendString = string.Format("success");
                        service.sendToOne(user, sendString);
                        user.number = double.Parse(splitString[1]);
                        if (splitString.Length == 3)
                        {
                            user.number2 = double.Parse(splitString[2]);
                        }
                        user.hasSend = true;
                        break;
                    default:
                        service.sendToOne(user, "无效指令: " + receiveString);
                        break;
                }
            }
            userList.Remove(user);
            client.Close();
            service.addItem(string.Format("有一个退出,剩余连接用户数:{0}", userList.Count));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButtonMode1.Checked)
            {
                mode = 0;
            }
            else
            {
                mode = 1;
            }
            string sendString=string.Format("mode,{0}",mode);
            service.sendToAll(userList, sendString);
            if (mode == 0)
            {
                service.addItem(string.Format("本轮游戏模式为: 每个客户程序必须提交一个有理数"));
            }
            else
            {
                service.addItem(string.Format("本轮游戏模式为: 每个客户程序必须提交两个有理数(任何一个数字最接近G-number 则此客户程序就是优胜.)"));
            }
            radioButtonMode1.Enabled = false;
            radioButtonMode2.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            sendString = string.Format("start");
            service.addItem(string.Format("Game Start"));
            service.sendToAll(userList, sendString);
            timer.Start();//计时器开始工作
        }
        /*------计时器周期到的时候触发事件------*/
        private void timerElapsed(object sender, EventArgs e)
        {
            timer.Stop();
            if (tt == count + 1)
            {
                timer.Stop();
                showResult();
                return;
            }
            MessageBox.Show(string.Format("第{0}轮比赛结束!", tt++));   
            calResult();
            clearUserSendHistory();
            updateImage();
      //      updateHTML();
            webBrowser1.Navigate(@"D:\coding\现代程序设计\现代程序设计作业5\Server\Server\showImage.html");
            string sendString=string.Format("result,{0},{1} ", Gnum, winner);
            service.addItem(sendString);
            service.sendToAll(userList,sendString);
            sendString=string.Format("pause");
            service.sendToAll(userList,sendString);
            DateTime now = DateTime.Now;
            while (now.AddSeconds(10) > DateTime.Now)
            {
            }
            sendString=string.Format("start");
            service.sendToAll(userList,sendString);
            timer.Start();
        }
        /*------更新黄金点曲线+排名------*/    
        private void updateImage()
        {
            Bitmap bmp = new Bitmap(1300, 1100, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            Font font = new Font("宋体", 9f);
            float lastx = 10;
            float lasty = 1010;
            g.DrawLine(Pens.Yellow, 10, 1010, 1010, 1010);
            g.DrawLine(Pens.Yellow, 10, 10, 10, 1010);
            float unitLength = 1000.0f / count;
            for (int i = 0; i < count; i++)
            {
                g.DrawString(string.Format("{0}", i + 1), font, Brushes.Yellow, unitLength * (i + 1) + 10, 1050);
            }
            g.DrawString(string.Format("Gnum"), font, Brushes.Yellow, 10, 5);
            g.DrawString(string.Format("游戏轮数"), font, Brushes.Yellow, 1030, 1010);
            for (int i = 0; i < history.Count; i++)
            {
                float ratio = (float)(history[i]) / 100;
                float y = 1010 - ratio * 1000;
                float x = unitLength * (i+1);
                g.DrawLine(Pens.Red, lastx, lasty, x, y);
                g.DrawString(Convert.ToString(history[i]), font, Brushes.Yellow, x + 10, y - 5);
                lastx = x;
                lasty = y;
            }

            g.DrawString(string.Format("本轮排名   目前总得分"), font, Brushes.Yellow, 1110, 10);
            for (int i = 0; i < userList.Count; i++)
            {
                g.DrawString(string.Format("Rank {0}   {1}  {2}", i + 1, userList[i].userName,userList[i].grade), new Font("宋体", 9f), Brushes.Yellow, 1100, 50 + 20 * i);
            }
            bmp.Save("image.png");         
            g.Dispose();
            bmp.Dispose();
        }
        /*------最终结果------*/
        private void showResult()
        {
            Bitmap bmp = new Bitmap(1300, 1100, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            Font font = new Font("宋体", 9f);
            float lastx = 10;
            float lasty = 1010;
            g.DrawLine(Pens.Yellow, 10, 1010, 1010, 1010);
            g.DrawLine(Pens.Yellow, 10, 10, 10, 1010);
            float unitLength = 1000.0f / count;
            for (int i = 0; i < count; i++)
            {
                g.DrawString(string.Format("{0}", i + 1), font, Brushes.Yellow, unitLength * (i + 1) + 10, 1050);
            }
            g.DrawString(string.Format("Gnum"), font, Brushes.Yellow, 10, 5);
            g.DrawString(string.Format("游戏轮数"), font, Brushes.Yellow, 1030, 1010);
            for (int i = 0; i < history.Count; i++)
            {
                float ratio = (float)(history[i]) / 100;
                float y = 1010 - ratio * 1000;
                float x = unitLength * (i + 1);
                g.DrawLine(Pens.Red, lastx, lasty, x, y);
                g.DrawString(Convert.ToString(history[i]), font, Brushes.Yellow, x + 10, y - 5);
                lastx = x;
                lasty = y;
            }
            g.DrawString(string.Format("本轮排名  目前总得分"), font, Brushes.Yellow, 1110, 10);
            for (int i = 0; i < userList.Count; i++)
            {
                g.DrawString(string.Format("Rank {0}   {1}  {2}", i + 1, userList[i].userName, userList[i].grade), new Font("宋体", 9f), Brushes.Yellow, 1100, 50 + 20 * i);
            }
            userList = userList.OrderByDescending(i => i.grade).ToList();
            g.DrawString(string.Format("总排名  最终得分"), font, Brushes.Yellow, 500, 10);
            for (int i = 0; i < userList.Count; i++)
            {
                g.DrawString(string.Format("Rank {0}  {1}  {2}", i + 1, userList[i].userName, userList[i].grade), new Font("宋体", 9f), Brushes.Yellow, 500, 50 + 20 * i);
            }
            bmp.Save("image.png");
            g.Dispose();
            bmp.Dispose();
            webBrowser1.Navigate(@"D:\coding\现代程序设计\现代程序设计作业5\Server\Server\showImage.html");
        }
        /*-----计算每轮游戏结果------*/
        private void calResult()
        {
            Gnum = 0;
            if (mode == 0)
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    Gnum += userList[i].number;
                }
                Gnum /= userList.Count;
            }
            else
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    Gnum += userList[i].number + userList[i].number2;
                }
                Gnum /= (userList.Count * 2);
            }
            Gnum *= 0.618;
            history.Add(Gnum);
            for (int i = 0; i < userList.Count; i++)
            {
                if (mode == 0)
                {
                    userList[i].abs = Math.Abs(userList[i].number - Gnum);
                }
                else
                {
                    userList[i].abs = Math.Min(Math.Abs(userList[i].number - Gnum), Math.Abs(userList[i].number2 - Gnum));
                }
            }
            userList = userList.OrderBy(i => i.abs).ToList();
            for (int i = 0; i < userList.Count; i++)
            {
                userList[i].rank = i;
            }
            winner = userList[0].userName;
            int isloser = userList.Count - 1;
            loser.Add(userList[isloser].userName);
            for (int i = userList.Count - 2; i >= 0; i--)
            {
                if (userList[i].abs == userList[isloser].abs)
                {
                    loser.Add(userList[i].userName);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < userList.Count; i++)
            {
                if (!userList[i].hasSend)
                {
                    userList[i].grade -= 5;
                }
                else if (userList[i].userName == winner)
                {
                    userList[i].grade += 10;
                }
                else if(loser.Contains(userList[i].userName))
                {
                    userList[i].grade -= 1;
                }
            }
        }
        /*------清空每轮情况------*/
        private void clearUserSendHistory()
        {
            for (int i = 0; i < userList.Count; i++)
            {
                userList[i].hasSend = false;
                userList[i].number = 0;
                userList[i].number2 = 0;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            if (timer.Enabled == true)
            {
                timer.Stop();
            }
            userList = userList.OrderBy(i => i.grade).ToList();
            for (int i = 0; i < userList.Count; i++)
            {
                userList[i].rank = i;
            }
            string sendString = string.Format("开始停止服务,并依次使用户退出");
            service.addItem(sendString);
            for (int i = 0; i < userList.Count; i++)
            {
                userList[i].client.Close();
            }
            myListener.Stop();
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myListener != null)
            {
                buttonStop_Click(null, null);
            }
        }

    }
}
