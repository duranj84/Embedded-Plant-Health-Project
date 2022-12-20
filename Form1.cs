using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Embedded_Project
{
	public partial class Form1 : Form
	{
        int startflag = 0;
        int flag_sensor;
        string RxString;
        string temp, voice = "0";
        char charb = 'B';

        public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 115200;
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {

                textBox1.ReadOnly = false;
            }
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Serial_stop_Click(object sender, EventArgs e)
		{

		}

		private void Read_In_TS_Click(object sender, EventArgs e)
		{

		}

		private void Current_Data_Click_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{

		}

		private void SerialPort1_DataReceived(object sender,
System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Data Received");
            RxString = serialPort1.ReadExisting();
            if (RxString.Contains(charb))
            {
                startflag = 9;
            }
            else { }
            if (startflag == 9)
            {
                startflag++;
            }
            else if (startflag == 10)
            {
                temp = RxString;
                startflag++;
            }
            else if (startflag == 11)
            {
                voice = RxString;
                startflag++;
            }
            else
            {
                // startflag = 0;
            }
            this.Invoke(new EventHandler(Current_Data_Click_Click));
        }
    }
}

