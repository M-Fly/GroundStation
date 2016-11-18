namespace GroundStation
{
    partial class MainForm
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
            this.grpAltitudePlot = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpDropPredictionStatus = new System.Windows.Forms.GroupBox();
            this.grpPayloadDropStatus = new System.Windows.Forms.GroupBox();
            this.grpInstrumentPanel = new System.Windows.Forms.GroupBox();
            this.GraphGPSDisplay = new System.Windows.Forms.GroupBox();
            this.tmrTestData = new System.Windows.Forms.Timer(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grpSerialConnection = new System.Windows.Forms.GroupBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblConnStatusLabel = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.serialTimer = new System.Windows.Forms.Timer(this.components);
            this.openPort = new System.Windows.Forms.Button();
            this.closePort = new System.Windows.Forms.Button();
            this.xbeeSerial = new System.IO.Ports.SerialPort(this.components);
            this.SerialOutput = new System.Windows.Forms.TextBox();
            this.graphGPS1 = new GroundStation.Panels.GraphGPS();
            this.instruments1 = new GroundStation.Panels.Instruments();
            this.dropStatusPanel = new GroundStation.Panels.DropStatus();
            this.altitudePlotPanel = new GroundStation.Panels.AltitudePlot();
            this.grpAltitudePlot.SuspendLayout();
            this.grpPayloadDropStatus.SuspendLayout();
            this.grpInstrumentPanel.SuspendLayout();
            this.GraphGPSDisplay.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpSerialConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAltitudePlot
            // 
            this.grpAltitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAltitudePlot.Controls.Add(this.altitudePlotPanel);
            this.grpAltitudePlot.Location = new System.Drawing.Point(9, 426);
            this.grpAltitudePlot.Margin = new System.Windows.Forms.Padding(2);
            this.grpAltitudePlot.Name = "grpAltitudePlot";
            this.grpAltitudePlot.Padding = new System.Windows.Forms.Padding(2);
            this.grpAltitudePlot.Size = new System.Drawing.Size(1086, 275);
            this.grpAltitudePlot.TabIndex = 0;
            this.grpAltitudePlot.TabStop = false;
            this.grpAltitudePlot.Text = "Altitude Graph";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Location = new System.Drawing.Point(13, 117);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(439, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera";
            // 
            // grpDropPredictionStatus
            // 
            this.grpDropPredictionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDropPredictionStatus.AutoSize = true;
            this.grpDropPredictionStatus.Location = new System.Drawing.Point(627, 27);
            this.grpDropPredictionStatus.Margin = new System.Windows.Forms.Padding(2);
            this.grpDropPredictionStatus.Name = "grpDropPredictionStatus";
            this.grpDropPredictionStatus.Padding = new System.Windows.Forms.Padding(2);
            this.grpDropPredictionStatus.Size = new System.Drawing.Size(207, 85);
            this.grpDropPredictionStatus.TabIndex = 2;
            this.grpDropPredictionStatus.TabStop = false;
            this.grpDropPredictionStatus.Text = "Drop Prediction Status";
            // 
            // grpPayloadDropStatus
            // 
            this.grpPayloadDropStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPayloadDropStatus.Controls.Add(this.dropStatusPanel);
            this.grpPayloadDropStatus.Location = new System.Drawing.Point(839, 27);
            this.grpPayloadDropStatus.Name = "grpPayloadDropStatus";
            this.grpPayloadDropStatus.Size = new System.Drawing.Size(255, 82);
            this.grpPayloadDropStatus.TabIndex = 3;
            this.grpPayloadDropStatus.TabStop = false;
            this.grpPayloadDropStatus.Text = "Payload Drop Status";
            // 
            // grpInstrumentPanel
            // 
            this.grpInstrumentPanel.Controls.Add(this.instruments1);
            this.grpInstrumentPanel.Location = new System.Drawing.Point(228, 27);
            this.grpInstrumentPanel.Name = "grpInstrumentPanel";
            this.grpInstrumentPanel.Size = new System.Drawing.Size(206, 85);
            this.grpInstrumentPanel.TabIndex = 4;
            this.grpInstrumentPanel.TabStop = false;
            this.grpInstrumentPanel.Text = "Instrument Panel";
            // 
            // GraphGPSDisplay
            // 
            this.GraphGPSDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphGPSDisplay.Controls.Add(this.graphGPS1);
            this.GraphGPSDisplay.Location = new System.Drawing.Point(457, 117);
            this.GraphGPSDisplay.Name = "GraphGPSDisplay";
            this.GraphGPSDisplay.Size = new System.Drawing.Size(638, 305);
            this.GraphGPSDisplay.TabIndex = 5;
            this.GraphGPSDisplay.TabStop = false;
            this.GraphGPSDisplay.Text = "GraphGPSDisplay";
            // 
            // tmrTestData
            // 
            this.tmrTestData.Enabled = true;
            this.tmrTestData.Interval = 10;
            this.tmrTestData.Tick += new System.EventHandler(this.tmrTestData_Tick);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1106, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grpSerialConnection
            // 
            this.grpSerialConnection.Controls.Add(this.closePort);
            this.grpSerialConnection.Controls.Add(this.openPort);
            this.grpSerialConnection.Controls.Add(this.lblConnectionStatus);
            this.grpSerialConnection.Controls.Add(this.lblConnStatusLabel);
            this.grpSerialConnection.Controls.Add(this.cmbSerialPort);
            this.grpSerialConnection.Controls.Add(this.lblSerial);
            this.grpSerialConnection.Location = new System.Drawing.Point(12, 27);
            this.grpSerialConnection.Name = "grpSerialConnection";
            this.grpSerialConnection.Size = new System.Drawing.Size(210, 85);
            this.grpSerialConnection.TabIndex = 7;
            this.grpSerialConnection.TabStop = false;
            this.grpSerialConnection.Text = "Serial Connection";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(109, 67);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(79, 13);
            this.lblConnectionStatus.TabIndex = 3;
            this.lblConnectionStatus.Text = "Not Connected";
            // 
            // lblConnStatusLabel
            // 
            this.lblConnStatusLabel.AutoSize = true;
            this.lblConnStatusLabel.Location = new System.Drawing.Point(6, 67);
            this.lblConnStatusLabel.Name = "lblConnStatusLabel";
            this.lblConnStatusLabel.Size = new System.Drawing.Size(97, 13);
            this.lblConnStatusLabel.TabIndex = 2;
            this.lblConnStatusLabel.Text = "Connection Status:";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(49, 16);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(155, 21);
            this.cmbSerialPort.TabIndex = 1;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(7, 19);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(36, 13);
            this.lblSerial.TabIndex = 0;
            this.lblSerial.Text = "Serial:";
            // 
            // serialTimer
            // 
            this.serialTimer.Enabled = true;
            this.serialTimer.Tick += new System.EventHandler(this.serialTimer_Tick);
            // 
            // openPort
            // 
            this.openPort.Location = new System.Drawing.Point(28, 43);
            this.openPort.Name = "openPort";
            this.openPort.Size = new System.Drawing.Size(75, 23);
            this.openPort.TabIndex = 4;
            this.openPort.Text = "Open Port";
            this.openPort.UseVisualStyleBackColor = true;
            this.openPort.Click += new System.EventHandler(this.openPort_Click);
            // 
            // closePort
            // 
            this.closePort.Location = new System.Drawing.Point(129, 43);
            this.closePort.Name = "closePort";
            this.closePort.Size = new System.Drawing.Size(75, 23);
            this.closePort.TabIndex = 5;
            this.closePort.Text = "Close";
            this.closePort.UseVisualStyleBackColor = true;
            this.closePort.Click += new System.EventHandler(this.closePort_Click);
            // 
            // xbeeSerial
            // 
            this.xbeeSerial.BaudRate = 38400;
            this.xbeeSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // SerialOutput
            // 
            this.SerialOutput.Location = new System.Drawing.Point(440, 43);
            this.SerialOutput.Multiline = true;
            this.SerialOutput.Name = "SerialOutput";
            this.SerialOutput.ReadOnly = true;
            this.SerialOutput.Size = new System.Drawing.Size(182, 50);
            this.SerialOutput.TabIndex = 8;
            // 
            // graphGPS1
            // 
            this.graphGPS1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphGPS1.Location = new System.Drawing.Point(6, 19);
            this.graphGPS1.Name = "graphGPS1";
            this.graphGPS1.Size = new System.Drawing.Size(625, 280);
            this.graphGPS1.TabIndex = 0;
            // 
            // instruments1
            // 
            this.instruments1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instruments1.Location = new System.Drawing.Point(5, 22);
            this.instruments1.Margin = new System.Windows.Forms.Padding(2);
            this.instruments1.Name = "instruments1";
            this.instruments1.Size = new System.Drawing.Size(191, 58);
            this.instruments1.TabIndex = 0;
            // 
            // dropStatusPanel
            // 
            this.dropStatusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropStatusPanel.Location = new System.Drawing.Point(6, 19);
            this.dropStatusPanel.Name = "dropStatusPanel";
            this.dropStatusPanel.Size = new System.Drawing.Size(243, 57);
            this.dropStatusPanel.TabIndex = 3;
            // 
            // altitudePlotPanel
            // 
            this.altitudePlotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.altitudePlotPanel.Location = new System.Drawing.Point(4, 17);
            this.altitudePlotPanel.Margin = new System.Windows.Forms.Padding(2);
            this.altitudePlotPanel.Name = "altitudePlotPanel";
            this.altitudePlotPanel.Size = new System.Drawing.Size(1078, 253);
            this.altitudePlotPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 710);
            this.Controls.Add(this.SerialOutput);
            this.Controls.Add(this.grpSerialConnection);
            this.Controls.Add(this.grpDropPredictionStatus);
            this.Controls.Add(this.GraphGPSDisplay);
            this.Controls.Add(this.grpInstrumentPanel);
            this.Controls.Add(this.grpPayloadDropStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpAltitudePlot);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "M-Fly Ground Station";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpAltitudePlot.ResumeLayout(false);
            this.grpPayloadDropStatus.ResumeLayout(false);
            this.grpInstrumentPanel.ResumeLayout(false);
            this.GraphGPSDisplay.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpSerialConnection.ResumeLayout(false);
            this.grpSerialConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAltitudePlot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpDropPredictionStatus;
        private Panels.AltitudePlot altitudePlotPanel;
        private Panels.DropStatus dropStatusPanel;
        private System.Windows.Forms.GroupBox grpPayloadDropStatus;
        private System.Windows.Forms.GroupBox grpInstrumentPanel;
        private System.Windows.Forms.GroupBox GraphGPSDisplay;
        private Panels.GraphGPS graphGPS1;
        private Panels.Instruments instruments1;
        private System.Windows.Forms.Timer tmrTestData;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox grpSerialConnection;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblConnStatusLabel;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Timer serialTimer;
        private System.Windows.Forms.Button closePort;
        private System.Windows.Forms.Button openPort;
        private System.IO.Ports.SerialPort xbeeSerial;
        private System.Windows.Forms.TextBox SerialOutput;
    }
}

