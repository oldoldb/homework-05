using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Server
{
    class Service
    {
        //变量
        #region
        private ListBox listbox;
        private delegate void AddItemDelegate(string str);
        private AddItemDelegate addItemDelegate;
        #endregion

        public Service(ListBox listbox)
        {
            this.listbox = listbox;
            addItemDelegate = new AddItemDelegate(addItem);
        }

        public void addItem(string str)
        {
            if (listbox.InvokeRequired)
            {
                listbox.Invoke(addItemDelegate, str);
            }
            else
            {
                listbox.Items.Add(str);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }

        public void sendToOne(User user, string str)
        {
            try
            {
                user.sw.WriteLine(str);
                user.sw.Flush();
                addItem(string.Format("向{0}发送{1} {2}", user.userName, str, DateTime.Now.ToString()));
            }
            catch
            {
                addItem(string.Format("向{0}发送信息失败", user.userName));
            }
        }

        public void sendToAll(List<User> userList, string str)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                sendToOne(userList[i], str);
            }
        }
    }
}
