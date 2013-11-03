using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cilent
{
    class Service
    {
        ListBox listbox;
        StreamWriter sw;
        public Service(ListBox listbox, StreamWriter sw)
        {
            this.listbox = listbox;
            this.sw = sw;
        }

        public void sendToServer(string str)
        {
            try
            {
                sw.WriteLine(str);
                sw.Flush();
            }
            catch
            {
                addItemToListBox("发送数据失败");
            }
        }

        delegate void ListBoxDelegate(string str);

        public void addItemToListBox(string str)
        {
            listbox.Items.Add(str + " " + DateTime.Now.ToString());
            listbox.SelectedIndex = listbox.Items.Count - 1;
            listbox.ClearSelected();
        }
    }
}
