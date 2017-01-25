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

namespace Client
{
    public partial class Login : Form
    {
        public CoCMainForm main { get; set; }

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //로그인 내용 넣어야합니다.
            try
            {
                main.client.Connect(IPAddress.Parse("127.0.0.1"), 3500);
                MessageBox.Show("로그인 성공");
                //접속한 사람들과 동기화 필요
                
            }
            catch
            {
                MessageBox.Show("로그인 실패");
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
