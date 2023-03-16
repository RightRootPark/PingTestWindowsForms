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
using System.Net.NetworkInformation;


namespace PingTestWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static bool Pingtest(string ip)
        {
            Ping ping = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            //전송할 데이터를 입력
            string data = "TEST";
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(data);
            int timeout = 120;
            //IP 주소를 입력
            PingReply reply = ping.Send(IPAddress.Parse(ip), timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine(ip + "Ping Succeess");
                return true;
            }
            else
            {
                Console.WriteLine(ip + "Ping Fail");
                return false;
            }
        }

        private void Test_btn_Click(object sender, EventArgs e)
        {
            string a = "fail";
            if (Pingtest(textBox1.Text)) a="succeess";
            toolStripStatusLabel2.Text = a;
        }
    }
  
}
