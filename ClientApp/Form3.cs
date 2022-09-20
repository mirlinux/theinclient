using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
            GetDeviceList();
        }


        private void GetLogData()
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

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 150;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void GetDeviceList()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Config.DB_DATASOURSE);
                conn.Open();

                string query = "SELECT * FROM machine";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    string ip = reader["ip"].ToString();
                    string name = reader["name"].ToString();
                    deviceBox.Items.Add(ip+"|["+name+"]");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            GetLogData();
        }

        private void deviceBox_DoubleClick(object sender, EventArgs e)
        {
            string strItem = ((ListBox)sender).SelectedItem.ToString();
            string[] itemArray = strItem.Split("|");
            string ip = itemArray[0];
            Debug.WriteLine("Target IP ["+ip+"]");
            lbIp.Text = ip;
            gbDevice.Text = itemArray[1];
            Thread runner = new Thread(new ParameterizedThreadStart(connectDevice));
            runner.IsBackground = true;
            runner.Start(ip);
        }

        TcpClient client;
        StreamWriter senderStream;
        private void connectDevice(object ip)
        {
            try
            {
                client = new TcpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip.ToString()), 9000);
                client.Connect(endPoint);

                StreamReader receiver = new StreamReader(client.GetStream());
                senderStream = new StreamWriter(client.GetStream());
                senderStream.AutoFlush = true;

                while (client.Connected)
                {
                    string data = receiver.ReadLine();
                    DebugTextBox("RECV ["+data+"]");
                    // "CONNECT:LOCALHOSTNAME;192.168.0.8"
                    string[] dataArray = data.Split(":");
                    string command = dataArray[0];
                    string body = dataArray[1];
                    switch (command)
                    {
                        case "CONNECT":
                            string[] paramList = body.Split(";");
                            Debug.WriteLine("Name [" + paramList[0] + "] IP [" + paramList[1] + "]");
                            
                            break;
                        case "STATUS":
                            string[] status = body.Split(";");
                            UpdateStatusControl(status);
                            break;
                        default:
                            break;
                    }
                    Debug.WriteLine(data);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStatusControl(string[] status)
        {
            double cpu = double.Parse(status[0]);
            int totalMem = int.Parse(status[1]);
            int usageMem = int.Parse(status[2]);
            int memPercent = int.Parse(status[3]);
            lbCpu.Invoke((MethodInvoker)delegate { lbCpu.Text = cpu + " %"; });
            lbMem.Invoke((MethodInvoker)delegate { lbMem.Text = usageMem + " MB ( "+totalMem+" MB )"; });
            pbCpu.Invoke((MethodInvoker)delegate { pbCpu.Value = (int)cpu; });
            pbMem.Invoke((MethodInvoker)delegate { pbMem.Value = memPercent; });
        }

        private void DebugTextBox(string message)
        {   
            rtbLog.Invoke((MethodInvoker)delegate { rtbLog.AppendText(message + "\r\n"); });
            rtbLog.Invoke((MethodInvoker)delegate { rtbLog.ScrollToCaret(); });
            rtbLog.Invoke((MethodInvoker)delegate { DebugTextColor("SEND", Color.Red); });
            rtbLog.Invoke((MethodInvoker)delegate { DebugTextColor("RECV", Color.Blue); });
        }

        private void DebugTextColor(string target, Color color)
        {
            Regex regex = new Regex(target);
            MatchCollection mc = regex.Matches(rtbLog.Text);
            int iCursorPosition = rtbLog.SelectionStart;

            foreach (Match m in mc)
            {
                int iStartIdx = m.Index;
                int iStopIdx = m.Length;

                rtbLog.Select(iStartIdx, iStopIdx);
                rtbLog.SelectionColor = color;
                rtbLog.SelectionStart = iCursorPosition;
                rtbLog.SelectionColor = Color.Black;
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                string sendData = "GET_STATUS:";
                DebugTextBox("SEND [" + sendData + "]");
                senderStream.WriteLine(sendData);
            } else
            {
                string sendData = "STOP_STATUS:";
                DebugTextBox("SEND [" + sendData + "]");
                senderStream.WriteLine(sendData);
            }
        }
    }



}
