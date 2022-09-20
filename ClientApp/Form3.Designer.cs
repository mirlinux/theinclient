namespace ClientApp
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.deviceBox = new System.Windows.Forms.ListBox();
            this.gbDevice = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMem = new System.Windows.Forms.Label();
            this.lbCpu = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 277);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // deviceBox
            // 
            this.deviceBox.FormattingEnabled = true;
            this.deviceBox.ItemHeight = 15;
            this.deviceBox.Location = new System.Drawing.Point(12, 32);
            this.deviceBox.Name = "deviceBox";
            this.deviceBox.Size = new System.Drawing.Size(323, 229);
            this.deviceBox.TabIndex = 1;
            this.deviceBox.DoubleClick += new System.EventHandler(this.deviceBox_DoubleClick);
            // 
            // gbDevice
            // 
            this.gbDevice.Controls.Add(this.label3);
            this.gbDevice.Controls.Add(this.lbMem);
            this.gbDevice.Controls.Add(this.lbCpu);
            this.gbDevice.Controls.Add(this.progressBar2);
            this.gbDevice.Controls.Add(this.progressBar1);
            this.gbDevice.Controls.Add(this.label2);
            this.gbDevice.Controls.Add(this.label1);
            this.gbDevice.Location = new System.Drawing.Point(341, 32);
            this.gbDevice.Name = "gbDevice";
            this.gbDevice.Size = new System.Drawing.Size(447, 136);
            this.gbDevice.TabIndex = 3;
            this.gbDevice.TabStop = false;
            this.gbDevice.Text = "Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "0.0.0.0";
            // 
            // lbMem
            // 
            this.lbMem.AutoSize = true;
            this.lbMem.Location = new System.Drawing.Point(226, 71);
            this.lbMem.Name = "lbMem";
            this.lbMem.Size = new System.Drawing.Size(85, 15);
            this.lbMem.TabIndex = 5;
            this.lbMem.Text = "0 MB ( 0 MB )";
            // 
            // lbCpu
            // 
            this.lbCpu.AutoSize = true;
            this.lbCpu.Location = new System.Drawing.Point(226, 36);
            this.lbCpu.Name = "lbCpu";
            this.lbCpu.Size = new System.Drawing.Size(28, 15);
            this.lbCpu.TabIndex = 4;
            this.lbCpu.Text = "0 %";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(116, 66);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(100, 23);
            this.progressBar2.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(116, 34);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mem 사용량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU 사용량";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(342, 174);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(446, 87);
            this.rtbLog.TabIndex = 4;
            this.rtbLog.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.gbDevice);
            this.Controls.Add(this.deviceBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "메인화면";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbDevice.ResumeLayout(false);
            this.gbDevice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private ListBox deviceBox;
        private GroupBox gbDevice;
        private Label label3;
        private Label lbMem;
        private Label lbCpu;
        private ProgressBar progressBar2;
        private ProgressBar progressBar1;
        private Label label2;
        private Label label1;
        private RichTextBox rtbLog;
    }
}