using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class User
    {
        public double number;//提交的答案
        public double number2;
        public double abs;//每轮与Gnum的差值,方便排序
        public int pos;//发送顺序,方便答案相同时计算排名
        public int rank;//每轮的排名,方便显示
        public int grade;//截至到每轮的总得分
        public bool hasSend;//是否发出答案,方便计算得分
        public string userName;//用户名
        public TcpClient client
        {
            get;
            private set;
        }
        public StreamReader sr
        {
            get;
            private set;
        }
        public StreamWriter sw
        {
            get;
            private set;
        }
        public User(TcpClient client)
        {
            this.client = client;
            this.userName = "";
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, System.Text.Encoding.UTF8);
            sw = new StreamWriter(netStream, System.Text.Encoding.UTF8);
        }
    }
}
