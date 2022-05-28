using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using ZedGraph;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string DataReceive;        
        //ReceiveData
        float[] count = new float[600];
        int[] pos = new int[600];
        float[] count1 = new float[600];
        int[] pos1 = new int[600];
        float[] count2 = new float[600];
        float[] spd = new float[600];       

        byte[] bP = new byte[2];
        byte[] bSP = new byte[2];
        bool GET = false;
        bool GET1 = false;

        int i = 0;
        bool Request = false;
        bool Draw = false;
        bool DrawPos = false;
        bool DrawSpeed = false;

        byte[] bSTX = { 0x02 };
        byte[] bKp = new byte[2];
        byte[] bKi = new byte[4];  
        byte[] bKd = new byte[4];
        double dKi, dKp, dKd, P, SP;

        byte[] bSPID = { 0x53, 0x50, 0x49, 0x44 };
        byte[] bGPID = { 0x47, 0x50, 0x49, 0x44 };
        byte[] bCTUN = { 0x43, 0x54, 0x55, 0x4E };
        byte[] bCRUN = { 0x43, 0x52, 0x55, 0x4E };
        byte[] bCSET = { 0x43, 0x53, 0x45, 0x54 };
        byte[] bGRMS = { 0x47, 0x52, 0x4D, 0x53 };
        byte[] bSTOP = { 0x53, 0x54, 0x4F, 0x50 };
        byte[] bROTN = { 0x52, 0x4F, 0x54, 0x4E };
        //OPT
        byte[] bOPT = { 0x0,0x0,0x00 };

        //DATA
        byte[] bDATA = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] bDATA1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] bDATA2 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] bDATA3 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] bCW = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] bCCW = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        //SYN/ACK
        byte[] bSYNC = { 0x16 };
        byte[] bACK = { 0x06 };

        //ETX
        byte[] bETX = { 0x03 };
        string newLine = Environment.NewLine;
        public Form1()
        {
            InitializeComponent();
            btnOpen.Enabled = true;
            btnCAL.Enabled = false;
            Initplotgraph();
            button2.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cBoxHandshake_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxPort.Items.AddRange(ports);
            checkBoxAddtoOldData.Checked = true;
            checkBoxAlwaysUpdate.Checked = false;   
        }
        private void tbnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOpen.Text == "Open")
                {
                    serialPort1.PortName = cBoxPort.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cBoxBaudrate.Text);
                    serialPort1.Parity = (Parity)Enum.Parse((typeof(Parity)), cBoxParity.Text);
                    serialPort1.Open();
                    btnOpen.Text = "Close";
                    progressBar.Value = 100;
                    statusLabel.Text = cBoxPort.Text + " open succesfully";
                    PortStatusLabel.Text = "ON";
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }
                else if (btnOpen.Text == "Close")
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                        btnOpen.Text = "Open";
                        PortStatusLabel.Text = "OFF";
                        statusLabel.Text = cBoxPort.Text + " has closed";
                        cBoxPort.Text = "";
                        progressBar.Value = 0;
                    }
            }   
            catch(Exception err)
            {
                MessageBox.Show(err.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAlwaysUpdate.Checked)
            {
                txBoxReceiveData.Text = "";
                checkBoxAlwaysUpdate.Checked = true;
                checkBoxAddtoOldData.Checked = false;
            }    
        }

        private void txBoxReceiveData_TextChanged(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort1.IsOpen) return;
            if (serialPort1.BytesToRead < 2) return;
            else
            {
                int bytes = 2;
                byte[] buffer = new byte[bytes];
                string DataReceiveRaw;
                serialPort1.Read(buffer, 0, bytes);
                if (buffer.Length == bytes)
                {
                    //Data PIDTuning Receive.
                    if (Request)
                    {
                        Draw = true;
                        count[i] = (float)i/100;
                        pos[i] = (buffer[1]<<8) + buffer[0];
                        i++;
                        if (i == 600)
                        {
                            i=0;
                            Request = false;
                            Draw = false;
                        }
                    }
                    //Data Position Receive
                    if (GET)
                    {
                        DrawPos = true;
                        count1[i] = (float)i/100;
                        pos1[i] = (buffer[1]<<8) + buffer[0];
                        i++;
                        if (i == 600)
                        {
                            i=0;
                            GET = false;
                            DrawPos = false;
                            
                        }
                    }

                    if (GET1)
                    {
                        DrawSpeed = true;
                        count2[i] = (float)i/100;
                        spd[i] = (float)((buffer[1]<<8) + buffer[0])/100;
                        i++;
                        if (i == 600)
                        {
                            i=0;
                            GET1 = false;
                            DrawSpeed = false;

                        }
                    }
                    DataReceiveRaw = BitConverter.ToString(buffer);
                    DataReceive = string.Join(" ", DataReceiveRaw.Split('-'));
                    this.Invoke(new EventHandler(ShowData));
                    if (Draw)
                    {
                        DrawPIDGraph(i);
                    }
                    if (DrawPos)
                    {
                        DrawPosCurve(i);
                    }
                    if (DrawSpeed)
                    {
                        DrawSpeedGraph(i);
                    }    
                }
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            if(checkBoxAddtoOldData.Checked)
            {
                txBoxReceiveData.Text += DataReceive + newLine;
                txBoxReceiveData.SelectionStart = txBoxReceiveData.Text.Length;
                if ((i%10)==0)
                {
                    txBoxReceiveData.Text = "";
                }
                txBoxReceiveData.ScrollToCaret();
            }    
            else if (checkBoxAlwaysUpdate.Checked)
            {
                txBoxReceiveData.Text  = DataReceive;
            }    
        }

        private void checkBoxAddtoOldData_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddtoOldData.Checked)
            {
                txBoxReceiveData.Text = "";
                checkBoxAlwaysUpdate.Checked = false;
                checkBoxAddtoOldData.Checked = true;
            }
        }

        private void btnClearDataIn_Click(object sender, EventArgs e)
        {
            if(txBoxReceiveData.Text !="")
            {
                txBoxReceiveData.Text = "";
            }    
        }

        void FloatToByte(double dNumber, byte [] bOut )
        {
            int nCountTithes = 0;
            bOut[0] = (byte)dNumber;
            float nTithes = (float)(dNumber - bOut[0]);
            do
            {
                nTithes *= 10;
                if (nCountTithes++ > 3) break;
            } while (nTithes < 1);
            bOut[1] = (byte)nTithes;
        }    

        private void PIDGraph_Load(object sender, EventArgs e)
        {

        }
        private void Initplotgraph()
        {
            GraphPane GraphPID = PIDGraph.GraphPane;
            GraphPane GraphSystem = PositionGraph.GraphPane;
            GraphPane Speed = SpeedGraph.GraphPane;


            this.PositionGraph.IsEnableZoom = true;
            this.PositionGraph.IsShowCursorValues = true;
            this.PositionGraph.IsShowPointValues = true;
            GraphPID.Title.Text = "PID Tuning";
            GraphPID.YAxis.Title.Text = "Pulse";
            GraphPID.XAxis.Title.Text = "Time (s)";

            GraphSystem.Title.Text = "System response";
            GraphSystem.YAxis.Title.Text = "Angle °";
            GraphSystem.XAxis.Title.Text = "Time (s)";

            Speed.Title.Text = "Speed response";
            Speed.YAxis.Title.Text = "RPM";
            Speed.XAxis.Title.Text = "Time (s)";

            GraphPID.XAxis.Scale.Min = 0;
            GraphPID.XAxis.Scale.Max = 5.99;
            GraphPID.YAxis.Scale.Min = 0;
            GraphPID.YAxis.Scale.Max =3000;

            GraphSystem.XAxis.Scale.Min = 0;
            GraphSystem.XAxis.Scale.Max = 6;
            GraphSystem.YAxis.Scale.Min = 0;
            GraphSystem.YAxis.Scale.Max = 400;

            Speed.XAxis.Scale.Min = 0;
            Speed.XAxis.Scale.Max = 6;
            Speed.YAxis.Scale.Min = 0;
            Speed.YAxis.Scale.Max = 50;

            PIDGraph.AxisChange();
            PositionGraph.GraphPane.AxisChange();
            SpeedGraph.AxisChange();
        }
        private void DrawPIDGraph(int i)
        {
            GraphPane GraphPID = PIDGraph.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            
            GraphPID.CurveList.Clear();

            for (int j = 0; j < i; j++)
            {
                list1.Add((float)j/100, pos[j]);
                list2.Add((float)j/100, 2175);
            }
            LineItem dapungthucte = GraphPID.AddCurve("Output", list1, Color.Red, SymbolType.None);
            LineItem dapunghethong = GraphPID.AddCurve("Input", list2, Color.Blue, SymbolType.None);            
            dapungthucte.Line.Width = 2.0f;
            dapunghethong.Line.Width = 2.0f;           
            PIDGraph.AxisChange();
            PIDGraph.Invalidate();
        }      
        private void DrawPosCurve(int i)
        {
            GraphPane posplot = PositionGraph.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            posplot.CurveList.Clear();           

            for (int j = 0; j < i; j++)
            {
                list1.Add((float)j/100, P);
                list2.Add((float)j/100, pos1[j]);
            }

            LineItem dapungthucte = posplot.AddCurve("Output", list2, Color.Red, SymbolType.None);
            LineItem ngovao = posplot.AddCurve("Input", list1, Color.Blue, SymbolType.None);
            dapungthucte.Line.Width = 2.0f;
            ngovao.Line.Width = 2.0f;
            PositionGraph.AxisChange();
            PositionGraph.Invalidate();
        }

        private void DrawSpeedGraph(int i)
        {
            GraphPane Speed = SpeedGraph.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            Speed.CurveList.Clear();

            for (int j = 0; j < i; j++)
            {
                list1.Add((float)j/100, spd[j]);
                list2.Add((float)j/100, SP);
            }
            LineItem dapungthucte = Speed.AddCurve("Output", list1, Color.Red, SymbolType.None);
            LineItem dapunghethong = Speed.AddCurve("Input", list2, Color.Blue, SymbolType.None);
            dapungthucte.Line.Width = 2.0f;
            dapunghethong.Line.Width = 2.0f;
            SpeedGraph.AxisChange();
            SpeedGraph.Invalidate();
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        void DoubleToByte(double dNumber, byte[] bOut)
        {
            bOut[0] = Convert.ToByte(Math.Floor(dNumber/256));
            bOut[1] = Convert.ToByte(dNumber%256);
        }

        private void btnCAL_Click_1(object sender, EventArgs e)
        {
            int MAX = 0;
            int index = 0;
            float POT, txl = 0;
            GraphPane POSGraph = PositionGraph.GraphPane;

            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int iCount = 0; iCount < 599; iCount++)
            {
                if (MAX < pos1[iCount])
                {
                    MAX = pos1[iCount];
                    index = iCount;
                }
            }
            list1.Add((float)index/100, MAX);
            if (MAX > pos1[598])
            {
                POT = (float)(MAX-pos1[598])*100/pos1[598];
                LineItem myCurve = POSGraph.AddCurve("Peak", list1, Color.Black, SymbolType.Circle);
                myCurve.Line.IsVisible = false;
                myCurve.Symbol.Border.IsVisible = false;
                myCurve.Symbol.Fill = new Fill(Color.Black);
                myCurve.Symbol.Size = 6.0f;
                PositionGraph.AxisChange();
                PositionGraph.Invalidate();
            }
            else
                POT = 0;
            for (int iCount = 598; iCount > 0; iCount--)
            {
                if (cBoxStandard.Text == "2%")
                {
                    if ((pos1[iCount] < (float)pos1[598]*98/100) || (pos1[iCount] > (float)pos1[598]*102/100))
                    {
                        txl = (float)iCount/100;
                        list2.Add((float)iCount/100, pos1[iCount]);
                        LineItem myCurve2 = POSGraph.AddCurve("Settling Time", list2, Color.Black, SymbolType.Circle);
                        myCurve2.Line.IsVisible = false;
                        myCurve2.Symbol.Border.IsVisible = false;
                        myCurve2.Symbol.Fill = new Fill(Color.Green);
                        myCurve2.Symbol.Size = 6.0f;
                        PositionGraph.AxisChange();
                        PositionGraph.Invalidate();
                        break;
                    }
                }
                else
                {
                    if ((pos1[iCount] < (float)pos1[598]*95/100) || (pos1[iCount] > (float)pos1[598]*105/100))
                    {
                        txl = (float)iCount/100;
                        list2.Add((float)iCount/100, pos1[iCount]);
                        LineItem myCurve2 = POSGraph.AddCurve("Settling Time", list2, Color.Black, SymbolType.Circle);
                        myCurve2.Line.IsVisible = false;
                        myCurve2.Symbol.Border.IsVisible = false;
                        myCurve2.Symbol.Fill = new Fill(Color.Green);
                        myCurve2.Symbol.Size = 6.0f;
                        PositionGraph.AxisChange();
                        PositionGraph.Invalidate();
                        break;
                    }
                }

            }
            txBoxPOT.Text = String.Format("{0:0.00}", POT);
            txBoxSettingTime.Text = String.Format("{0:0.00}", txl);
            txBoxError.Text = String.Format("{0:0}", Math.Abs(pos1[598]-P));
            btnCAL.Enabled = false;
            cBoxStandard.Enabled = false;
        }

        private void btnSendSetting_Click_1(object sender, EventArgs e)
        {
            P = double.Parse(txBoxDesireAngel.Text);

            DoubleToByte(P, bP);
            bDATA2[6] = bP[0];
            bDATA2[7] = bP[1];



            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bCSET, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA2, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);
            statusLabel.Text = string.Format("{0:00}", 18) + " byte received";
            DrawPos = false;
            btnCAL.Enabled = false;

            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bCRUN, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);
            statusLabel.Text = string.Format("{0:00}", 18) + " byte received";

            i=0;          
            GET = true;
            btnCAL.Enabled = true;
            cBoxStandard.Enabled = true;
        }

        private void PositionGraph_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bSTOP, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);
            button2.Enabled = false;
            button1.Enabled = false;
            Thread.Sleep(2000);
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cBoxRotationDirection.Text == "Clockwise(-)")
            {
                serialPort1.Write(bSTX, 0, 1);
                serialPort1.Write(bROTN, 0, 4);
                serialPort1.Write(bOPT, 0, 3);
                serialPort1.Write(bCW, 0, 8);
                serialPort1.Write(bSYNC, 0, 1);
                serialPort1.Write(bETX, 0, 1);
            }
            else
            {
                serialPort1.Write(bSTX, 0, 1);
                serialPort1.Write(bROTN, 0, 4);
                serialPort1.Write(bOPT, 0, 3);
                serialPort1.Write(bCCW, 0, 8);
                serialPort1.Write(bSYNC, 0, 1);
                serialPort1.Write(bETX, 0, 1);
            }
            SP = double.Parse(TxBoxDesireSpeed.Text);

            DoubleToByte(SP, bSP);
            bDATA3[6] = bSP[0];
            bDATA3[7] = bSP[1];

            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bGPID, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA3, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);
            button2.Enabled = true;
            i = 0;
            GET1 = true;
        }

        void FloatToByteWithNipes(double fNumber, byte[] bOut)
        {
            int nCountTithes = 5;
            bOut[0] = (byte)fNumber;
            double nTithes = (float)(fNumber - bOut[0]);
            nTithes = nTithes*Math.Pow(10,nCountTithes);  
            while (nTithes > 255)
            {
                nTithes /= 10;
                nCountTithes--;
            }    
            bOut[1] = (byte)nTithes;
            bOut[2] = (byte)nCountTithes;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            txBoxReceiveData.Text = "";
            GraphPane GraphPID = PIDGraph.GraphPane;

            GraphPID.CurveList.Clear();

            PIDGraph.Refresh();
            PIDGraph.AxisChange();
            PIDGraph.Invalidate();

            dKp = double.Parse(txBoxKp.Text);
            dKi = double.Parse(txBoxKi.Text);
            dKd = double.Parse(txBoxKd.Text);           

            FloatToByte(dKp, bKp);
            bDATA1[0] = bKp[0];
            bDATA1[1] = bKp[1];

            FloatToByteWithNipes(dKi, bKi);
            bDATA1[2] = bKi[0];
            bDATA1[3] = bKi[1];
            bDATA1[4] = bKi[2];

            FloatToByteWithNipes(dKd, bKd);
            
            bDATA1[5] = bKd[0];
            bDATA1[6] = bKd[1];
            bDATA1[7] = bKd[2];

            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bSPID, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA1, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);

            Draw = false;

            serialPort1.Write(bSTX, 0, 1);
            serialPort1.Write(bCTUN, 0, 4);
            serialPort1.Write(bOPT, 0, 3);
            serialPort1.Write(bDATA, 0, 8);
            serialPort1.Write(bSYNC, 0, 1);
            serialPort1.Write(bETX, 0, 1);

            i = 0;          
            Request = true;
        }

    }
}
