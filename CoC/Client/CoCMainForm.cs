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
using CoCNet;

namespace Client
{
    public partial class CoCMainForm : Form
    {
        public Socket client;

        public byte[] buffer;

        public CoCMainForm()
        {
            InitializeComponent();
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Blocking = false;
            buffer = new byte[GlobalVariable.iDEFAULT_SO_RCVBUF_SIZE];
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.main = this;
            loginForm.ShowDialog();
        }

        private void CoCMainForm_Load(object sender, EventArgs e)
        {

        }

        private void CoCMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.Connected)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (client.Connected)
            {
                try
                {
                    int recv = client.Receive(buffer);
                    textBox1.AppendText(BitConverter.ToString(buffer, 0, recv) + "\r\n");
                }
                catch
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(client.Connected && textBox2.TextLength != 0)
            {
                string text = textBox2.Text;

                client.Send(Encoding.UTF8.GetBytes(text));

                textBox1.AppendText(text + "\r\n");
                textBox2.Clear();
            }
        }
    }
}
