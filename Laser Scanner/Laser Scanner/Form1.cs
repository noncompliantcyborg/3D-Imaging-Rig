using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Laser_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LaserControl laser = new LaserControl();

        public double jogSpeed = 150000.0;
        private void Form1_Load(object sender, EventArgs e)
        {
            comPortCombo.Text = Properties.Settings.Default.ComPort;
            if (Properties.Settings.Default.ComPort != "None")
            {
                laser.Open(Properties.Settings.Default.ComPort);
            }
            SoundPlayer snd = new SoundPlayer(Properties.Resources.sharks);
            snd.Play();
            for (int i = 0;i < 10; i++)
            {
                CaptureSpeedCombo.Items.Add(i.ToString());
            }
        }

        private void HomeAll_Click(object sender, EventArgs e)
        {
            laser.HomeCamera();
            laser.HomeLaser();
        }

        private void CamBack_Click(object sender, EventArgs e)
        {
            laser.SetCameraSpeed(jogSpeed);
            laser.JogCamera(CameraJogSpeed.Value * -.1);
        }

        private void CamForward_Click(object sender, EventArgs e)
        {
            laser.SetCameraSpeed(jogSpeed);
            laser.JogCamera(CameraJogSpeed.Value * .1 );
        }

        private void CameraJogSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            laser.UpdateLocation();
            cameraLocation.Text = RoundFormat(laser.CameraPositionMM);
            laserLocation.Text = RoundFormat(laser.LaserPositionMM);

            if (Capturing)
            {
                if (laser.CameraPositionMM == targetCamera && laser.LaserPositionMM == targetLaser)
                {
                    Capturing = false;
                    laser.SetLaserPower(LasereEabled.Checked ? 1 : 0);
                }
            }

            if (!laser.Connected )
            {
                status.BackColor = Color.Red;
            }
            else
            {
                if (laser.Initialized)
                {
                    status.BackColor = Color.Green;
                }
                else
                {
                    status.BackColor = Color.Yellow;
                }
            }
        }

        private void LaserBack_Click(object sender, EventArgs e)
        {
            laser.SetLaserSpeed(jogSpeed);
            laser.JogLaser(LaserJogSpeed.Value * -.1);
        }

        private void LaserForward_Click(object sender, EventArgs e)
        {
            laser.SetLaserSpeed(jogSpeed);
            laser.JogLaser(LaserJogSpeed.Value * .1);
        }

        int nextStationId = 1;
        private void AddStop_Click(object sender, EventArgs e)
        {
            LaserStation station = new LaserStation();
            station.Name = $"Station {nextStationId++}";
            station.CameraPosition = laser.CameraPositionMM;
            station.LaserPosition = laser.LaserPositionMM;

            AddStation(station);
           

        }

        private void AddStation(LaserStation station)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = station.Name;
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, RoundFormat(station.CameraPosition)));
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, RoundFormat(station.LaserPosition)));
            StationList.Items.Add(lvi);
            lvi.Tag = station;
        }

        private void StationContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (StationList.SelectedItems.Count != 1)
            { 
                e.Cancel = true;
            }
        }

        private void SetAsStartMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SetAsEndMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MoveToMenuItem_Click(object sender, EventArgs e)
        {
            if (StationList.SelectedItems.Count == 1)
            {
                LaserStation station = StationList.SelectedItems[0].Tag as LaserStation;
                laser.SetCameraSpeed(jogSpeed);
                laser.SetLaserSpeed(jogSpeed);
                laser.SeekCamera(station.CameraPosition);
                laser.SeekLaser(station.LaserPosition);
            }
        }

        private string RoundFormat(double value)
        {
            return (value + .05).ToString("0.0 mm");
        }

        private void RemoveStop_Click(object sender, EventArgs e)
        {
            if (StationList.SelectedItems.Count == 1)
            {
                StationList.Items.RemoveAt(StationList.SelectedIndices[0]);
            }
        }

        private void Capture_Click(object sender, EventArgs e)
        {
            if (StationList.Items.Count != 2)
            {
                return;
            }

            double camSpeedMMperSecond = 5;
            bool sucess = double.TryParse(CaptureSpeedCombo.Text, out camSpeedMMperSecond);
            if (!sucess)
            {
                MessageBox.Show("Could not parse capture speed. Defaulting to 5mm/sec");
            }

            double cameraFreq = 15000.0 * camSpeedMMperSecond;

            // Calculate speed differntial
            LaserStation start = StationList.Items[0].Tag as LaserStation;
            LaserStation end = StationList.Items[1].Tag as LaserStation;

            double camDist = end.CameraPosition - start.CameraPosition;
            double lasDist = end.LaserPosition - start.LaserPosition;

            double speedRatio = (lasDist/camDist);
            int freqLaser = (int)(cameraFreq * speedRatio);
            laser.SetCameraSpeed(cameraFreq);
            laser.SetLaserSpeed(freqLaser);
            laser.SetLaserPower(1);
            laser.SeekCamera(end.CameraPosition);
            laser.SeekLaser(end.LaserPosition);
            targetCamera = end.CameraPosition;
            targetLaser = end.LaserPosition;
            Capturing = true;
        }
        bool Capturing = false;
        double targetLaser = -1;
        double targetCamera = -1;
        private void LaserEnabled_CheckedChanged(object sender, EventArgs e)
        {
            laser.SetLaserPower(LasereEabled.Checked ? 1 : 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CaptureSpeedCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comPortCombo_DropDown(object sender, EventArgs e)
        {
            LoadComPorts();
        }
        private void LoadComPorts()
        {
            string target = Properties.Settings.Default.ComPort;
            comPortCombo.Items.Clear();
            int index = -1;


            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                index++;
                if(port == target)
                {
                    break;
                }

            }
            comPortCombo.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comPortCombo.SelectedIndex = index;
            }
        }

        private void comPortCombo_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ComPort = comPortCombo.Text;
            laser.Open(Properties.Settings.Default.ComPort);
        }

        private void comPortCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
