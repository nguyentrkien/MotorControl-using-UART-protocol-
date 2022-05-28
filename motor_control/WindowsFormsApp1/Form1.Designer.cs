namespace WindowsFormsApp1
{
    partial class Form1
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
            this.progressiveBar = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PortStatusLabel = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cBoxMode = new System.Windows.Forms.ComboBox();
            this.cBoxHandshake = new System.Windows.Forms.ComboBox();
            this.cBoxParity = new System.Windows.Forms.ComboBox();
            this.cBoxDatasize = new System.Windows.Forms.ComboBox();
            this.cBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.cBoxPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxAddtoOldData = new System.Windows.Forms.CheckBox();
            this.checkBoxAlwaysUpdate = new System.Windows.Forms.CheckBox();
            this.btnClearDataIn = new System.Windows.Forms.Button();
            this.txBoxReceiveData = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.PIDGraph = new ZedGraph.ZedGraphControl();
            this.btnSend = new System.Windows.Forms.Button();
            this.txBoxKi = new System.Windows.Forms.TextBox();
            this.txBoxKd = new System.Windows.Forms.TextBox();
            this.txBoxKp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cBoxStandard = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PositionGraph = new ZedGraph.ZedGraphControl();
            this.btnSendSetting = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txBoxDesireAngel = new System.Windows.Forms.TextBox();
            this.btnCAL = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txBoxError = new System.Windows.Forms.TextBox();
            this.txBoxSettingTime = new System.Windows.Forms.TextBox();
            this.txBoxPOT = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TxBoxDesireSpeed = new System.Windows.Forms.TextBox();
            this.SpeedGraph = new ZedGraph.ZedGraphControl();
            this.cBoxRotationDirection = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.progressiveBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressiveBar
            // 
            this.progressiveBar.Controls.Add(this.groupBox1);
            this.progressiveBar.Controls.Add(this.cBoxMode);
            this.progressiveBar.Controls.Add(this.cBoxHandshake);
            this.progressiveBar.Controls.Add(this.cBoxParity);
            this.progressiveBar.Controls.Add(this.cBoxDatasize);
            this.progressiveBar.Controls.Add(this.cBoxBaudrate);
            this.progressiveBar.Controls.Add(this.cBoxPort);
            this.progressiveBar.Controls.Add(this.label6);
            this.progressiveBar.Controls.Add(this.label5);
            this.progressiveBar.Controls.Add(this.label4);
            this.progressiveBar.Controls.Add(this.label3);
            this.progressiveBar.Controls.Add(this.label2);
            this.progressiveBar.Controls.Add(this.label1);
            this.progressiveBar.Location = new System.Drawing.Point(652, 12);
            this.progressiveBar.Name = "progressiveBar";
            this.progressiveBar.Size = new System.Drawing.Size(625, 113);
            this.progressiveBar.TabIndex = 0;
            this.progressiveBar.TabStop = false;
            this.progressiveBar.Text = "Serial";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PortStatusLabel);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Location = new System.Drawing.Point(435, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 98);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM PORT Status";
            // 
            // PortStatusLabel
            // 
            this.PortStatusLabel.AutoSize = true;
            this.PortStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortStatusLabel.Location = new System.Drawing.Point(111, 27);
            this.PortStatusLabel.Name = "PortStatusLabel";
            this.PortStatusLabel.Size = new System.Drawing.Size(44, 20);
            this.PortStatusLabel.TabIndex = 16;
            this.PortStatusLabel.Text = "OFF";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(16, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 39);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.tbnOpen_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 65);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(158, 23);
            this.progressBar.TabIndex = 15;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // cBoxMode
            // 
            this.cBoxMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxMode.FormattingEnabled = true;
            this.cBoxMode.Location = new System.Drawing.Point(332, 73);
            this.cBoxMode.Name = "cBoxMode";
            this.cBoxMode.Size = new System.Drawing.Size(97, 24);
            this.cBoxMode.TabIndex = 11;
            this.cBoxMode.Text = "Data";
            // 
            // cBoxHandshake
            // 
            this.cBoxHandshake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxHandshake.FormattingEnabled = true;
            this.cBoxHandshake.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cBoxHandshake.Location = new System.Drawing.Point(332, 43);
            this.cBoxHandshake.Name = "cBoxHandshake";
            this.cBoxHandshake.Size = new System.Drawing.Size(97, 24);
            this.cBoxHandshake.TabIndex = 10;
            this.cBoxHandshake.Text = "Off";
            this.cBoxHandshake.SelectedIndexChanged += new System.EventHandler(this.cBoxHandshake_SelectedIndexChanged);
            // 
            // cBoxParity
            // 
            this.cBoxParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxParity.FormattingEnabled = true;
            this.cBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParity.Location = new System.Drawing.Point(332, 13);
            this.cBoxParity.Name = "cBoxParity";
            this.cBoxParity.Size = new System.Drawing.Size(97, 24);
            this.cBoxParity.TabIndex = 9;
            this.cBoxParity.Text = "None";
            // 
            // cBoxDatasize
            // 
            this.cBoxDatasize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxDatasize.FormattingEnabled = true;
            this.cBoxDatasize.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cBoxDatasize.Location = new System.Drawing.Point(117, 73);
            this.cBoxDatasize.Name = "cBoxDatasize";
            this.cBoxDatasize.Size = new System.Drawing.Size(97, 24);
            this.cBoxDatasize.TabIndex = 8;
            this.cBoxDatasize.Text = "8";
            // 
            // cBoxBaudrate
            // 
            this.cBoxBaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxBaudrate.FormattingEnabled = true;
            this.cBoxBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "115200"});
            this.cBoxBaudrate.Location = new System.Drawing.Point(117, 43);
            this.cBoxBaudrate.Name = "cBoxBaudrate";
            this.cBoxBaudrate.Size = new System.Drawing.Size(97, 24);
            this.cBoxBaudrate.TabIndex = 7;
            this.cBoxBaudrate.Text = "115200";
            // 
            // cBoxPort
            // 
            this.cBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxPort.FormattingEnabled = true;
            this.cBoxPort.Location = new System.Drawing.Point(117, 13);
            this.cBoxPort.Name = "cBoxPort";
            this.cBoxPort.Size = new System.Drawing.Size(97, 24);
            this.cBoxPort.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(238, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Handshake";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mode";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datasize";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(238, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnClearDataIn);
            this.groupBox2.Controls.Add(this.txBoxReceiveData);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receive Data";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxAddtoOldData);
            this.groupBox5.Controls.Add(this.checkBoxAlwaysUpdate);
            this.groupBox5.Location = new System.Drawing.Point(489, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 51);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // checkBoxAddtoOldData
            // 
            this.checkBoxAddtoOldData.AutoSize = true;
            this.checkBoxAddtoOldData.Location = new System.Drawing.Point(6, 32);
            this.checkBoxAddtoOldData.Name = "checkBoxAddtoOldData";
            this.checkBoxAddtoOldData.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAddtoOldData.TabIndex = 3;
            this.checkBoxAddtoOldData.Text = "Add to Old Data";
            this.checkBoxAddtoOldData.UseVisualStyleBackColor = true;
            this.checkBoxAddtoOldData.CheckedChanged += new System.EventHandler(this.checkBoxAddtoOldData_CheckedChanged);
            // 
            // checkBoxAlwaysUpdate
            // 
            this.checkBoxAlwaysUpdate.AutoSize = true;
            this.checkBoxAlwaysUpdate.Location = new System.Drawing.Point(6, 15);
            this.checkBoxAlwaysUpdate.Name = "checkBoxAlwaysUpdate";
            this.checkBoxAlwaysUpdate.Size = new System.Drawing.Size(97, 17);
            this.checkBoxAlwaysUpdate.TabIndex = 2;
            this.checkBoxAlwaysUpdate.Text = "Always Update";
            this.checkBoxAlwaysUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAlwaysUpdate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnClearDataIn
            // 
            this.btnClearDataIn.Location = new System.Drawing.Point(523, 15);
            this.btnClearDataIn.Name = "btnClearDataIn";
            this.btnClearDataIn.Size = new System.Drawing.Size(86, 35);
            this.btnClearDataIn.TabIndex = 1;
            this.btnClearDataIn.Text = "Clear Data Receive";
            this.btnClearDataIn.UseVisualStyleBackColor = true;
            this.btnClearDataIn.Click += new System.EventHandler(this.btnClearDataIn_Click);
            // 
            // txBoxReceiveData
            // 
            this.txBoxReceiveData.Location = new System.Drawing.Point(6, 19);
            this.txBoxReceiveData.Multiline = true;
            this.txBoxReceiveData.Name = "txBoxReceiveData";
            this.txBoxReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBoxReceiveData.Size = new System.Drawing.Size(477, 89);
            this.txBoxReceiveData.TabIndex = 0;
            this.txBoxReceiveData.TextChanged += new System.EventHandler(this.txBoxReceiveData_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.txBoxKi);
            this.groupBox3.Controls.Add(this.txBoxKd);
            this.groupBox3.Controls.Add(this.txBoxKp);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 437);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PID Tuning";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.PIDGraph);
            this.groupBox6.Location = new System.Drawing.Point(6, 101);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(438, 325);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            // 
            // PIDGraph
            // 
            this.PIDGraph.Location = new System.Drawing.Point(6, 19);
            this.PIDGraph.Name = "PIDGraph";
            this.PIDGraph.ScrollGrace = 0D;
            this.PIDGraph.ScrollMaxX = 0D;
            this.PIDGraph.ScrollMaxY = 0D;
            this.PIDGraph.ScrollMaxY2 = 0D;
            this.PIDGraph.ScrollMinX = 0D;
            this.PIDGraph.ScrollMinY = 0D;
            this.PIDGraph.ScrollMinY2 = 0D;
            this.PIDGraph.Size = new System.Drawing.Size(426, 300);
            this.PIDGraph.TabIndex = 0;
            this.PIDGraph.Load += new System.EventHandler(this.PIDGraph_Load);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(145, 31);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(72, 48);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "TUNING";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txBoxKi
            // 
            this.txBoxKi.Location = new System.Drawing.Point(44, 41);
            this.txBoxKi.Multiline = true;
            this.txBoxKi.Name = "txBoxKi";
            this.txBoxKi.Size = new System.Drawing.Size(61, 27);
            this.txBoxKi.TabIndex = 5;
            // 
            // txBoxKd
            // 
            this.txBoxKd.Location = new System.Drawing.Point(44, 68);
            this.txBoxKd.Multiline = true;
            this.txBoxKd.Name = "txBoxKd";
            this.txBoxKd.Size = new System.Drawing.Size(61, 27);
            this.txBoxKd.TabIndex = 4;
            // 
            // txBoxKp
            // 
            this.txBoxKp.Location = new System.Drawing.Point(44, 14);
            this.txBoxKp.Multiline = true;
            this.txBoxKp.Name = "txBoxKp";
            this.txBoxKp.Size = new System.Drawing.Size(61, 27);
            this.txBoxKp.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Kd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ki";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kp";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 566);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(10, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = " ";
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(468, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 432);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cBoxStandard);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.PositionGraph);
            this.tabPage1.Controls.Add(this.btnSendSetting);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txBoxDesireAngel);
            this.tabPage1.Controls.Add(this.btnCAL);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.txBoxError);
            this.tabPage1.Controls.Add(this.txBoxSettingTime);
            this.tabPage1.Controls.Add(this.txBoxPOT);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(801, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Position";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cBoxStandard
            // 
            this.cBoxStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxStandard.FormattingEnabled = true;
            this.cBoxStandard.Items.AddRange(new object[] {
            "2%",
            "5%"});
            this.cBoxStandard.Location = new System.Drawing.Point(652, 347);
            this.cBoxStandard.Name = "cBoxStandard";
            this.cBoxStandard.Size = new System.Drawing.Size(90, 24);
            this.cBoxStandard.TabIndex = 54;
            this.cBoxStandard.Text = "2%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(550, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Standard";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(748, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "degree";
            // 
            // PositionGraph
            // 
            this.PositionGraph.Location = new System.Drawing.Point(0, 0);
            this.PositionGraph.Name = "PositionGraph";
            this.PositionGraph.ScrollGrace = 0D;
            this.PositionGraph.ScrollMaxX = 0D;
            this.PositionGraph.ScrollMaxY = 0D;
            this.PositionGraph.ScrollMaxY2 = 0D;
            this.PositionGraph.ScrollMinX = 0D;
            this.PositionGraph.ScrollMinY = 0D;
            this.PositionGraph.ScrollMinY2 = 0D;
            this.PositionGraph.Size = new System.Drawing.Size(543, 406);
            this.PositionGraph.TabIndex = 28;
            this.PositionGraph.Load += new System.EventHandler(this.PositionGraph_Load);
            // 
            // btnSendSetting
            // 
            this.btnSendSetting.Location = new System.Drawing.Point(650, 57);
            this.btnSendSetting.Name = "btnSendSetting";
            this.btnSendSetting.Size = new System.Drawing.Size(92, 48);
            this.btnSendSetting.TabIndex = 49;
            this.btnSendSetting.Text = "SEND";
            this.btnSendSetting.UseVisualStyleBackColor = true;
            this.btnSendSetting.Click += new System.EventHandler(this.btnSendSetting_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "DESIRE ANGLE";
            // 
            // txBoxDesireAngel
            // 
            this.txBoxDesireAngel.Location = new System.Drawing.Point(650, 17);
            this.txBoxDesireAngel.Multiline = true;
            this.txBoxDesireAngel.Name = "txBoxDesireAngel";
            this.txBoxDesireAngel.Size = new System.Drawing.Size(92, 33);
            this.txBoxDesireAngel.TabIndex = 47;
            // 
            // btnCAL
            // 
            this.btnCAL.Location = new System.Drawing.Point(650, 147);
            this.btnCAL.Name = "btnCAL";
            this.btnCAL.Size = new System.Drawing.Size(92, 24);
            this.btnCAL.TabIndex = 46;
            this.btnCAL.Text = "CAL";
            this.btnCAL.UseVisualStyleBackColor = true;
            this.btnCAL.Click += new System.EventHandler(this.btnCAL_Click_1);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(750, 292);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 15);
            this.label21.TabIndex = 45;
            this.label21.Text = "degree";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(751, 248);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 15);
            this.label20.TabIndex = 44;
            this.label20.Text = "s";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(750, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 20);
            this.label19.TabIndex = 43;
            this.label19.Text = "%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(550, 249);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Settling Time";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(550, 205);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Overshoot (POT)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(550, 293);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Steady-State Error";
            // 
            // txBoxError
            // 
            this.txBoxError.Location = new System.Drawing.Point(652, 286);
            this.txBoxError.Multiline = true;
            this.txBoxError.Name = "txBoxError";
            this.txBoxError.Size = new System.Drawing.Size(92, 27);
            this.txBoxError.TabIndex = 39;
            this.txBoxError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txBoxSettingTime
            // 
            this.txBoxSettingTime.Location = new System.Drawing.Point(652, 242);
            this.txBoxSettingTime.Multiline = true;
            this.txBoxSettingTime.Name = "txBoxSettingTime";
            this.txBoxSettingTime.Size = new System.Drawing.Size(92, 27);
            this.txBoxSettingTime.TabIndex = 38;
            this.txBoxSettingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txBoxPOT
            // 
            this.txBoxPOT.Location = new System.Drawing.Point(652, 198);
            this.txBoxPOT.Multiline = true;
            this.txBoxPOT.Name = "txBoxPOT";
            this.txBoxPOT.Size = new System.Drawing.Size(92, 27);
            this.txBoxPOT.TabIndex = 37;
            this.txBoxPOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cBoxRotationDirection);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.TxBoxDesireSpeed);
            this.tabPage2.Controls.Add(this.SpeedGraph);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(801, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(702, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 51);
            this.button2.TabIndex = 57;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(615, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 51);
            this.button1.TabIndex = 56;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(747, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "RPM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(549, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "DESIRE SPEED:";
            // 
            // TxBoxDesireSpeed
            // 
            this.TxBoxDesireSpeed.Location = new System.Drawing.Point(649, 74);
            this.TxBoxDesireSpeed.Multiline = true;
            this.TxBoxDesireSpeed.Name = "TxBoxDesireSpeed";
            this.TxBoxDesireSpeed.Size = new System.Drawing.Size(92, 33);
            this.TxBoxDesireSpeed.TabIndex = 53;
            // 
            // SpeedGraph
            // 
            this.SpeedGraph.Location = new System.Drawing.Point(0, 0);
            this.SpeedGraph.Name = "SpeedGraph";
            this.SpeedGraph.ScrollGrace = 0D;
            this.SpeedGraph.ScrollMaxX = 0D;
            this.SpeedGraph.ScrollMaxY = 0D;
            this.SpeedGraph.ScrollMaxY2 = 0D;
            this.SpeedGraph.ScrollMinX = 0D;
            this.SpeedGraph.ScrollMinY = 0D;
            this.SpeedGraph.ScrollMinY2 = 0D;
            this.SpeedGraph.Size = new System.Drawing.Size(543, 406);
            this.SpeedGraph.TabIndex = 29;
            // 
            // cBoxRotationDirection
            // 
            this.cBoxRotationDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxRotationDirection.FormattingEnabled = true;
            this.cBoxRotationDirection.Items.AddRange(new object[] {
            "Counter-Clockwise(+)",
            "Clockwise(-)"});
            this.cBoxRotationDirection.Location = new System.Drawing.Point(602, 321);
            this.cBoxRotationDirection.Name = "cBoxRotationDirection";
            this.cBoxRotationDirection.Size = new System.Drawing.Size(168, 24);
            this.cBoxRotationDirection.TabIndex = 58;
            this.cBoxRotationDirection.Text = "Counter-Clockwise (+)";
            this.cBoxRotationDirection.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(640, 305);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 59;
            this.label15.Text = "Rotation direction:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 574);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressiveBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.progressiveBar.ResumeLayout(false);
            this.progressiveBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox progressiveBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cBoxMode;
        private System.Windows.Forms.ComboBox cBoxHandshake;
        private System.Windows.Forms.ComboBox cBoxParity;
        private System.Windows.Forms.ComboBox cBoxDatasize;
        private System.Windows.Forms.ComboBox cBoxBaudrate;
        private System.Windows.Forms.ComboBox cBoxPort;
        private System.Windows.Forms.TextBox txBoxReceiveData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label PortStatusLabel;
        private System.Windows.Forms.CheckBox checkBoxAddtoOldData;
        private System.Windows.Forms.CheckBox checkBoxAlwaysUpdate;
        private System.Windows.Forms.Button btnClearDataIn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txBoxKi;
        private System.Windows.Forms.TextBox txBoxKd;
        private System.Windows.Forms.TextBox txBoxKp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ZedGraph.ZedGraphControl PIDGraph;
        private ZedGraph.ZedGraphControl PositionGraph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cBoxStandard;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSendSetting;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txBoxDesireAngel;
        private System.Windows.Forms.Button btnCAL;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txBoxError;
        private System.Windows.Forms.TextBox txBoxSettingTime;
        private System.Windows.Forms.TextBox txBoxPOT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxBoxDesireSpeed;
        private ZedGraph.ZedGraphControl SpeedGraph;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cBoxRotationDirection;
        private System.Windows.Forms.Label label15;
    }
}

