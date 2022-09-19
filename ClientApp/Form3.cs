using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();

                string query = "SELECT ";
                query += "date_format(time, '%Y-%m-%d %H:%i:%s') as '일시',  ";
                query += "machine_id as '장비', ";
                query += "cpu as 'CPU 사용량', ";
                query += "mem as '메모리 사용량(MB)', ";
                query += "mem_usage as '메모리 사용량 (%)', ";
                query += "ip as '장비 IP' ";
                query += "FROM log ";
                query += "ORDER BY time desc ";

                Debug.WriteLine(query);

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {

            } finally
            {
                if (conn != null) conn.Close();
            }
        }
    }


}
