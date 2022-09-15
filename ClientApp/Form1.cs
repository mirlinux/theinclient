using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                    if (password == "") tbPassword.Focus();
                    return;
                }

                MySqlConnection conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();
                string query = "SELECT id FROM member WHERE userid = '"+userid+"' AND password = '"+password+"'";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}