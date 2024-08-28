namespace Laser_Scanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CamBack = new System.Windows.Forms.Button();
            this.CamForward = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraLocation = new System.Windows.Forms.TextBox();
            this.HomeAll = new System.Windows.Forms.Button();
            this.CameraJogSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.LaserJogSpeed = new System.Windows.Forms.TrackBar();
            this.laserLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LaserForward = new System.Windows.Forms.Button();
            this.LaserBack = new System.Windows.Forms.Button();
            this.StationList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CameraLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LaserLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LaserPowerCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StationContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SetAsStartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetAsEndMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStop = new System.Windows.Forms.Button();
            this.RemoveStop = new System.Windows.Forms.Button();
            this.Capture = new System.Windows.Forms.Button();
            this.LasereEabled = new System.Windows.Forms.CheckBox();
            this.CaptureSpeedCombo = new System.Windows.Forms.ComboBox();
            this.CaptureSpeedLabel = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Button();
            this.comPortCombo = new System.Windows.Forms.ComboBox();
            this.ComPortLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CameraJogSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserJogSpeed)).BeginInit();
            this.StationContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CamBack
            // 
            this.CamBack.Location = new System.Drawing.Point(32, 68);
            this.CamBack.Name = "CamBack";
            this.CamBack.Size = new System.Drawing.Size(75, 23);
            this.CamBack.TabIndex = 0;
            this.CamBack.Text = "<<";
            this.CamBack.UseVisualStyleBackColor = true;
            this.CamBack.Click += new System.EventHandler(this.CamBack_Click);
            // 
            // CamForward
            // 
            this.CamForward.Location = new System.Drawing.Point(113, 68);
            this.CamForward.Name = "CamForward";
            this.CamForward.Size = new System.Drawing.Size(75, 23);
            this.CamForward.TabIndex = 0;
            this.CamForward.Text = ">>";
            this.CamForward.UseVisualStyleBackColor = true;
            this.CamForward.Click += new System.EventHandler(this.CamForward_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera";
            // 
            // cameraLocation
            // 
            this.cameraLocation.Location = new System.Drawing.Point(96, 32);
            this.cameraLocation.Name = "cameraLocation";
            this.cameraLocation.Size = new System.Drawing.Size(75, 20);
            this.cameraLocation.TabIndex = 2;
            // 
            // HomeAll
            // 
            this.HomeAll.Location = new System.Drawing.Point(23, 561);
            this.HomeAll.Name = "HomeAll";
            this.HomeAll.Size = new System.Drawing.Size(75, 23);
            this.HomeAll.TabIndex = 3;
            this.HomeAll.Text = "Home All";
            this.HomeAll.UseVisualStyleBackColor = true;
            this.HomeAll.Click += new System.EventHandler(this.HomeAll_Click);
            // 
            // CameraJogSpeed
            // 
            this.CameraJogSpeed.Location = new System.Drawing.Point(32, 116);
            this.CameraJogSpeed.Maximum = 200;
            this.CameraJogSpeed.Minimum = 1;
            this.CameraJogSpeed.Name = "CameraJogSpeed";
            this.CameraJogSpeed.Size = new System.Drawing.Size(156, 45);
            this.CameraJogSpeed.TabIndex = 4;
            this.CameraJogSpeed.TickFrequency = 20;
            this.CameraJogSpeed.Value = 100;
            this.CameraJogSpeed.Scroll += new System.EventHandler(this.CameraJogSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Camera Jog Dist (mm)";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Laser Jog Dist (mm)";
            // 
            // LaserJogSpeed
            // 
            this.LaserJogSpeed.Location = new System.Drawing.Point(231, 116);
            this.LaserJogSpeed.Maximum = 200;
            this.LaserJogSpeed.Minimum = 1;
            this.LaserJogSpeed.Name = "LaserJogSpeed";
            this.LaserJogSpeed.Size = new System.Drawing.Size(156, 45);
            this.LaserJogSpeed.TabIndex = 10;
            this.LaserJogSpeed.TickFrequency = 20;
            this.LaserJogSpeed.Value = 100;
            // 
            // laserLocation
            // 
            this.laserLocation.Location = new System.Drawing.Point(295, 32);
            this.laserLocation.Name = "laserLocation";
            this.laserLocation.Size = new System.Drawing.Size(75, 20);
            this.laserLocation.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Laser";
            // 
            // LaserForward
            // 
            this.LaserForward.Location = new System.Drawing.Point(312, 68);
            this.LaserForward.Name = "LaserForward";
            this.LaserForward.Size = new System.Drawing.Size(75, 23);
            this.LaserForward.TabIndex = 6;
            this.LaserForward.Text = ">>";
            this.LaserForward.UseVisualStyleBackColor = true;
            this.LaserForward.Click += new System.EventHandler(this.LaserForward_Click);
            // 
            // LaserBack
            // 
            this.LaserBack.Location = new System.Drawing.Point(231, 68);
            this.LaserBack.Name = "LaserBack";
            this.LaserBack.Size = new System.Drawing.Size(75, 23);
            this.LaserBack.TabIndex = 7;
            this.LaserBack.Text = "<<";
            this.LaserBack.UseVisualStyleBackColor = true;
            this.LaserBack.Click += new System.EventHandler(this.LaserBack_Click);
            // 
            // StationList
            // 
            this.StationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.CameraLoc,
            this.LaserLoc,
            this.LaserPowerCol});
            this.StationList.ContextMenuStrip = this.StationContextMenu;
            this.StationList.FullRowSelect = true;
            this.StationList.GridLines = true;
            this.StationList.HideSelection = false;
            this.StationList.Location = new System.Drawing.Point(23, 187);
            this.StationList.Name = "StationList";
            this.StationList.Size = new System.Drawing.Size(374, 283);
            this.StationList.TabIndex = 12;
            this.StationList.UseCompatibleStateImageBehavior = false;
            this.StationList.View = System.Windows.Forms.View.Details;
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 120;
            // 
            // CameraLoc
            // 
            this.CameraLoc.Text = "Camera";
            this.CameraLoc.Width = 80;
            // 
            // LaserLoc
            // 
            this.LaserLoc.Text = "Laser";
            this.LaserLoc.Width = 80;
            // 
            // LaserPowerCol
            // 
            this.LaserPowerCol.Text = "Laser Power";
            this.LaserPowerCol.Width = 80;
            // 
            // StationContextMenu
            // 
            this.StationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetAsStartMenuItem,
            this.SetAsEndMenuItem,
            this.toolStripSeparator1,
            this.MoveToMenuItem});
            this.StationContextMenu.Name = "StationContextMenu";
            this.StationContextMenu.Size = new System.Drawing.Size(169, 76);
            this.StationContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.StationContextMenu_Opening);
            // 
            // SetAsStartMenuItem
            // 
            this.SetAsStartMenuItem.Name = "SetAsStartMenuItem";
            this.SetAsStartMenuItem.Size = new System.Drawing.Size(168, 22);
            this.SetAsStartMenuItem.Text = "Set as Start";
            this.SetAsStartMenuItem.Click += new System.EventHandler(this.SetAsStartMenuItem_Click);
            // 
            // SetAsEndMenuItem
            // 
            this.SetAsEndMenuItem.Name = "SetAsEndMenuItem";
            this.SetAsEndMenuItem.Size = new System.Drawing.Size(168, 22);
            this.SetAsEndMenuItem.Text = "Set as End";
            this.SetAsEndMenuItem.Click += new System.EventHandler(this.SetAsEndMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // MoveToMenuItem
            // 
            this.MoveToMenuItem.Name = "MoveToMenuItem";
            this.MoveToMenuItem.Size = new System.Drawing.Size(168, 22);
            this.MoveToMenuItem.Text = "Move To Location";
            this.MoveToMenuItem.Click += new System.EventHandler(this.MoveToMenuItem_Click);
            // 
            // AddStop
            // 
            this.AddStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStop.Location = new System.Drawing.Point(321, 158);
            this.AddStop.Name = "AddStop";
            this.AddStop.Size = new System.Drawing.Size(28, 23);
            this.AddStop.TabIndex = 13;
            this.AddStop.Text = "+";
            this.AddStop.UseVisualStyleBackColor = true;
            this.AddStop.Click += new System.EventHandler(this.AddStop_Click);
            // 
            // RemoveStop
            // 
            this.RemoveStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveStop.Location = new System.Drawing.Point(355, 158);
            this.RemoveStop.Name = "RemoveStop";
            this.RemoveStop.Size = new System.Drawing.Size(28, 23);
            this.RemoveStop.TabIndex = 14;
            this.RemoveStop.Text = "-";
            this.RemoveStop.UseVisualStyleBackColor = true;
            this.RemoveStop.Click += new System.EventHandler(this.RemoveStop_Click);
            // 
            // Capture
            // 
            this.Capture.Location = new System.Drawing.Point(286, 561);
            this.Capture.Name = "Capture";
            this.Capture.Size = new System.Drawing.Size(111, 23);
            this.Capture.TabIndex = 16;
            this.Capture.Text = "Capture";
            this.Capture.UseVisualStyleBackColor = true;
            this.Capture.Click += new System.EventHandler(this.Capture_Click);
            // 
            // LasereEabled
            // 
            this.LasereEabled.AutoSize = true;
            this.LasereEabled.Location = new System.Drawing.Point(23, 522);
            this.LasereEabled.Name = "LasereEabled";
            this.LasereEabled.Size = new System.Drawing.Size(88, 17);
            this.LasereEabled.TabIndex = 17;
            this.LasereEabled.Text = "Enable Laser";
            this.LasereEabled.UseVisualStyleBackColor = true;
            this.LasereEabled.CheckedChanged += new System.EventHandler(this.LaserEnabled_CheckedChanged);
            // 
            // CaptureSpeedCombo
            // 
            this.CaptureSpeedCombo.FormattingEnabled = true;
            this.CaptureSpeedCombo.Location = new System.Drawing.Point(286, 522);
            this.CaptureSpeedCombo.Name = "CaptureSpeedCombo";
            this.CaptureSpeedCombo.Size = new System.Drawing.Size(111, 21);
            this.CaptureSpeedCombo.TabIndex = 18;
            this.CaptureSpeedCombo.Text = "5";
            this.CaptureSpeedCombo.SelectedIndexChanged += new System.EventHandler(this.CaptureSpeedCombo_SelectedIndexChanged);
            // 
            // CaptureSpeedLabel
            // 
            this.CaptureSpeedLabel.AutoSize = true;
            this.CaptureSpeedLabel.Location = new System.Drawing.Point(286, 503);
            this.CaptureSpeedLabel.Name = "CaptureSpeedLabel";
            this.CaptureSpeedLabel.Size = new System.Drawing.Size(113, 13);
            this.CaptureSpeedLabel.TabIndex = 19;
            this.CaptureSpeedLabel.Text = "Capture Speed (mm/s)";
            this.CaptureSpeedLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(133, 519);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(98, 65);
            this.status.TabIndex = 20;
            this.status.UseVisualStyleBackColor = true;
            // 
            // comPortCombo
            // 
            this.comPortCombo.FormattingEnabled = true;
            this.comPortCombo.Location = new System.Drawing.Point(133, 492);
            this.comPortCombo.Name = "comPortCombo";
            this.comPortCombo.Size = new System.Drawing.Size(98, 21);
            this.comPortCombo.TabIndex = 21;
            this.comPortCombo.DropDown += new System.EventHandler(this.comPortCombo_DropDown);
            this.comPortCombo.SelectedIndexChanged += new System.EventHandler(this.comPortCombo_SelectedIndexChanged);
            this.comPortCombo.TextChanged += new System.EventHandler(this.comPortCombo_TextChanged);
            // 
            // ComPortLabel
            // 
            this.ComPortLabel.AutoSize = true;
            this.ComPortLabel.Location = new System.Drawing.Point(133, 473);
            this.ComPortLabel.Name = "ComPortLabel";
            this.ComPortLabel.Size = new System.Drawing.Size(50, 13);
            this.ComPortLabel.TabIndex = 22;
            this.ComPortLabel.Text = "Com Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 596);
            this.Controls.Add(this.ComPortLabel);
            this.Controls.Add(this.comPortCombo);
            this.Controls.Add(this.status);
            this.Controls.Add(this.CaptureSpeedLabel);
            this.Controls.Add(this.CaptureSpeedCombo);
            this.Controls.Add(this.LasereEabled);
            this.Controls.Add(this.Capture);
            this.Controls.Add(this.RemoveStop);
            this.Controls.Add(this.AddStop);
            this.Controls.Add(this.StationList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LaserJogSpeed);
            this.Controls.Add(this.laserLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LaserForward);
            this.Controls.Add(this.LaserBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CameraJogSpeed);
            this.Controls.Add(this.HomeAll);
            this.Controls.Add(this.cameraLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CamForward);
            this.Controls.Add(this.CamBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sharks wtih Feekin Lasers on their heads!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraJogSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserJogSpeed)).EndInit();
            this.StationContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CamBack;
        private System.Windows.Forms.Button CamForward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cameraLocation;
        private System.Windows.Forms.Button HomeAll;
        private System.Windows.Forms.TrackBar CameraJogSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar LaserJogSpeed;
        private System.Windows.Forms.TextBox laserLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LaserForward;
        private System.Windows.Forms.Button LaserBack;
        private System.Windows.Forms.ListView StationList;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader CameraLoc;
        private System.Windows.Forms.ColumnHeader LaserLoc;
        private System.Windows.Forms.ColumnHeader LaserPowerCol;
        private System.Windows.Forms.Button AddStop;
        private System.Windows.Forms.Button RemoveStop;
        private System.Windows.Forms.ContextMenuStrip StationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SetAsStartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetAsEndMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button Capture;
        private System.Windows.Forms.CheckBox LasereEabled;
        private System.Windows.Forms.ComboBox CaptureSpeedCombo;
        private System.Windows.Forms.Label CaptureSpeedLabel;
        private System.Windows.Forms.Button status;
        private System.Windows.Forms.ComboBox comPortCombo;
        private System.Windows.Forms.Label ComPortLabel;
    }
}

