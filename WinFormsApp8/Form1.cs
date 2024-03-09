using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        private SerialPort[] serialPorts;

        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }
            
        private void Form1_Load()
        {
            // Get the names of all available serial ports
            string[] portNames = SerialPort.GetPortNames();

            // Initialize an array to hold instances of SerialPort
            serialPorts = new SerialPort[portNames.Length];

            // Create SerialPort instances for each port
            for (int i = 0; i < portNames.Length; i++)
            {
                serialPorts[i] = new SerialPort(portNames[i]);
            }
        }

        private void EnableSerialPorts()
        {
            // Enable all serial ports
            foreach (SerialPort port in serialPorts)
            {
                try
                {
                    port.Open();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, such as port already open or inaccessible
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisableSerialPorts()
        {
            // Disable all serial ports
            foreach (SerialPort port in serialPorts)
            {
                try
                {
                    port.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, such as port already closed or inaccessible
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableSerialPorts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisableSerialPorts();
        }
    }
}
