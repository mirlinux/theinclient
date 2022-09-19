using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        string localIP = "";
        public Form1()
        {
            InitializeComponent();
            
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            foreach (IPAddress ip in addr)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (ip.ToString().Contains("192.168.0"))
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string userid = tbUserId.Text;
            string password = tbPassword.Text;

            if (userid == "" || password == "")
            {
                MessageBox.Show("아이디 / 비밀번호를 입력해 주세요.");
                if (userid == "")
                {
                    tbUserId.Focus();
                    return;
                }
                if (password == "")
                {
                    tbPassword.Focus();
                    return;
                }
            }

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();
                string query = "SELECT id FROM member WHERE userid = '"+userid+"' AND password = '"+password+"'";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    MessageBox.Show("로그인 되었습니다.");
                    Form3 form = new Form3();
                    form.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("로그인에 실패하였습니다.\n아이디/비밀번호를 확인해주세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
