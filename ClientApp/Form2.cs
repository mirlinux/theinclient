using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                tbName.Focus();
                MessageBox.Show("이름을 입력해주세요.");
                return;
            }
            if (tbUserId.Text == "")
            {
                tbUserId.Focus();
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }
            if (tbPass1.Text == "")
            {
                tbPass1.Focus();
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            if (tbPass1.Text != tbPass2.Text)
            {
                tbPass2.Focus();
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();

                string query = "INSERT INTO member (userid, password, name) ";
                query += "VALUES ('" + tbUserId.Text + "','" + tbPass1.Text + "','" + tbName.Text + "')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteReader();

                MessageBox.Show("회원가입이 완료되었습니다.");
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                if (conn != null) conn.Close();
            }

            

        }
    }
}
