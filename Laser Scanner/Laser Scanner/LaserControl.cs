using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laser_Scanner
{

    internal class LaserControl
    {
        SerialPort serialPort;

        const double StepsPerMM = 200000.0 / 311.15;
        bool laserEnabled = false;

        bool initialized = false;
        bool connected = false;
        public bool LaserEnabled { get => laserEnabled; set => laserEnabled = value; }
        public bool Initialized { get => initialized; set => initialized = value; }
        public bool Connected { get => connected; set => connected = value; }

        public LaserControl()
        {
           
        }
        public void Open(string port)
        { 
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close(); 
                }
                catch { }                 
            }


            serialPort = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.None;
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.WriteTimeout = 5000;
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            try
            {
                serialPort.Open();
            }
            catch
            {
                connected = false;
            }
        }

        public void JogLaser(double amountmm)
        {
            int amount = (int)(amountmm * StepsPerMM);
            SendCommand($"JogLaser({amount})\r\n");
        }
        public void JogCamera(double amountmm)
        {
            int amount = (int)(amountmm * StepsPerMM);
            SendCommand($"JogCamera({amount})\r\n");
        }
        public void SeekLaser(double locationmm)
        {
            int amount = (int)(locationmm * StepsPerMM);
            SendCommand($"SeekLaser({amount})\r\n");
        }
        public void SeekCamera(double locationmm)
        {
            int amount = (int)(locationmm * StepsPerMM);
            SendCommand($"SeekCamera({amount})\r\n");
        }

        public void HomeLaser()
        {
            SendCommand("HomeLaser()\r\n");
        }
        public void HomeCamera()
        {
            SendCommand("HomeCamera()\r\n");
        }
        public void SetCameraSpeed(double speed)
        {
            SendCommand($"SetCameraSpeed({speed})\r\n");
        }
        public void SetLaserSpeed(double speed)
        {
            SendCommand($"SetLaserSpeed({speed})\r\n");
        }

        public void SetLaserPower(double power)
        {
            SendCommand($"SetLaserPower({power})\r\n");
            if( power > 0 )
            { 
                laserEnabled = true;
            }
        }
        public void UpdateLocation()
        {
            SendCommand("ShowPosition()\r\n");
        }
        
        public void SendCommand(string command)
        {
            if (serialPort == null)
                return;

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    connected = false;
                    return;
                }
            }
            try
            {
                serialPort.Write(command);
            }
            catch
            {
                connected = false;
            }
            
        }
        public double LaserPositionMM = 0;
        public double CameraPositionMM = 0;


        private delegate void SetTextDeleg(string text);
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();

                if (data.StartsWith("Loc:"))
                {
                    string[] parts = data.Split(',', ':');
                    if (parts.Length > 2)
                    {
                        LaserPositionMM = Convert.ToDouble(parts[2]) / StepsPerMM;
                        CameraPositionMM = Convert.ToDouble(parts[1]) / StepsPerMM;

                        if (CameraPositionMM > -1 & LaserPositionMM > -1)
                        {
                            initialized = true; 
                        }
                        else
                        {
                            initialized = false;

                        }


                        connected = true;
                    }
                }

                Debug.WriteLine(data);
            }
            catch
            {
                connected = false;
            }
        }
    }
}
