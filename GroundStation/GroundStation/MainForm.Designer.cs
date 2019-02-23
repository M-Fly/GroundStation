﻿namespace GroundStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpPayloadDropStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDropStatus_CDA = new GroundStation.Panels.DropStatus();
            this.panelDropStatus_water = new GroundStation.Panels.DropStatus();
            this.panelDropStatus_ballz = new GroundStation.Panels.DropStatus();
            this.grpInstrumentPanel = new System.Windows.Forms.GroupBox();
            this.panelInstruments = new GroundStation.Panels.Instruments();
            this.grpGPS = new System.Windows.Forms.GroupBox();
            this.panelGPSPlot = new GroundStation.Panels.GraphGPS();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.jump10sBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSerialConnection = new System.Windows.Forms.GroupBox();
            this.closePort = new System.Windows.Forms.Button();
            this.openPort = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblConnStatusLabel = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.xbeeSerial = new System.IO.Ports.SerialPort(this.components);
            this.parseTimer = new System.Windows.Forms.Timer(this.components);
            this.grpWindInput = new System.Windows.Forms.GroupBox();
            this.panelWindInput = new GroundStation.Panels.WindParameters();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpAltitudePlot = new System.Windows.Forms.GroupBox();
            this.panelAltitudePlot = new GroundStation.Panels.AltitudePlot();
            this.grpPayloadDropStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpInstrumentPanel.SuspendLayout();
            this.grpGPS.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpSerialConnection.SuspendLayout();
            this.grpWindInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpAltitudePlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPayloadDropStatus
            // 
            this.grpPayloadDropStatus.Controls.Add(this.tableLayoutPanel1);
            this.grpPayloadDropStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPayloadDropStatus.Location = new System.Drawing.Point(0, 0);
            this.grpPayloadDropStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPayloadDropStatus.Name = "grpPayloadDropStatus";
            this.grpPayloadDropStatus.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPayloadDropStatus.Size = new System.Drawing.Size(747, 446);
            this.grpPayloadDropStatus.TabIndex = 3;
            this.grpPayloadDropStatus.TabStop = false;
            this.grpPayloadDropStatus.Text = "Payload Drop Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panelDropStatus_CDA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDropStatus_water, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDropStatus_ballz, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 417);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDropStatus_CDA
            // 
            this.panelDropStatus_CDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDropStatus_CDA.Location = new System.Drawing.Point(6, 8);
            this.panelDropStatus_CDA.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panelDropStatus_CDA.Name = "panelDropStatus_CDA";
            this.panelDropStatus_CDA.PayloadType = "Glider";
            this.panelDropStatus_CDA.Size = new System.Drawing.Size(746, 123);
            this.panelDropStatus_CDA.TabIndex = 3;
            // 
            // panelDropStatus_water
            // 
            this.panelDropStatus_water.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDropStatus_water.Location = new System.Drawing.Point(6, 147);
            this.panelDropStatus_water.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panelDropStatus_water.Name = "panelDropStatus_water";
            this.panelDropStatus_water.PayloadType = "Bottles";
            this.panelDropStatus_water.Size = new System.Drawing.Size(746, 123);
            this.panelDropStatus_water.TabIndex = 3;
            // 
            // panelDropStatus_ballz
            // 
            this.panelDropStatus_ballz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDropStatus_ballz.Location = new System.Drawing.Point(6, 286);
            this.panelDropStatus_ballz.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panelDropStatus_ballz.Name = "panelDropStatus_ballz";
            this.panelDropStatus_ballz.PayloadType = "Ballz";
            this.panelDropStatus_ballz.Size = new System.Drawing.Size(746, 123);
            this.panelDropStatus_ballz.TabIndex = 3;
            // 
            // grpInstrumentPanel
            // 
            this.grpInstrumentPanel.Controls.Add(this.panelInstruments);
            this.grpInstrumentPanel.Location = new System.Drawing.Point(342, 42);
            this.grpInstrumentPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInstrumentPanel.Name = "grpInstrumentPanel";
            this.grpInstrumentPanel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInstrumentPanel.Size = new System.Drawing.Size(309, 131);
            this.grpInstrumentPanel.TabIndex = 4;
            this.grpInstrumentPanel.TabStop = false;
            this.grpInstrumentPanel.Text = "Instrument Panel";
            // 
            // panelInstruments
            // 
            this.panelInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInstruments.Location = new System.Drawing.Point(8, 34);
            this.panelInstruments.Name = "panelInstruments";
            this.panelInstruments.Size = new System.Drawing.Size(286, 89);
            this.panelInstruments.TabIndex = 0;
            this.panelInstruments.Load += new System.EventHandler(this.panelInstruments_Load);
            // 
            // grpGPS
            // 
            this.grpGPS.Controls.Add(this.panelGPSPlot);
            this.grpGPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGPS.Location = new System.Drawing.Point(0, 0);
            this.grpGPS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGPS.Name = "grpGPS";
            this.grpGPS.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGPS.Size = new System.Drawing.Size(870, 446);
            this.grpGPS.TabIndex = 5;
            this.grpGPS.TabStop = false;
            this.grpGPS.Text = "GPS";
            // 
            // panelGPSPlot
            // 
            this.panelGPSPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGPSPlot.Location = new System.Drawing.Point(9, 29);
            this.panelGPSPlot.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panelGPSPlot.Name = "panelGPSPlot";
            this.panelGPSPlot.Size = new System.Drawing.Size(850, 408);
            this.panelGPSPlot.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playbackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1659, 35);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.speedsToolStripMenuItem,
            this.jump10sBeforeToolStripMenuItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.playbackToolStripMenuItem.Text = "Playback";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // speedsToolStripMenuItem
            // 
            this.speedsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2,
            this.xToolStripMenuItem3});
            this.speedsToolStripMenuItem.Name = "speedsToolStripMenuItem";
            this.speedsToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.speedsToolStripMenuItem.Text = "Speeds";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(114, 30);
            this.xToolStripMenuItem.Text = "1x";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(114, 30);
            this.xToolStripMenuItem1.Text = "2x";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Size = new System.Drawing.Size(114, 30);
            this.xToolStripMenuItem2.Text = "4x";
            this.xToolStripMenuItem2.Click += new System.EventHandler(this.xToolStripMenuItem2_Click);
            // 
            // xToolStripMenuItem3
            // 
            this.xToolStripMenuItem3.Name = "xToolStripMenuItem3";
            this.xToolStripMenuItem3.Size = new System.Drawing.Size(114, 30);
            this.xToolStripMenuItem3.Text = "8x";
            this.xToolStripMenuItem3.Click += new System.EventHandler(this.xToolStripMenuItem3_Click);
            // 
            // jump10sBeforeToolStripMenuItem
            // 
            this.jump10sBeforeToolStripMenuItem.Name = "jump10sBeforeToolStripMenuItem";
            this.jump10sBeforeToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.jump10sBeforeToolStripMenuItem.Text = "Jump 10s Before Drop";
            this.jump10sBeforeToolStripMenuItem.Click += new System.EventHandler(this.jump10sBeforeToolStripMenuItem_Click);
            // 
            // grpSerialConnection
            // 
            this.grpSerialConnection.Controls.Add(this.closePort);
            this.grpSerialConnection.Controls.Add(this.openPort);
            this.grpSerialConnection.Controls.Add(this.lblConnectionStatus);
            this.grpSerialConnection.Controls.Add(this.lblConnStatusLabel);
            this.grpSerialConnection.Controls.Add(this.cmbSerialPort);
            this.grpSerialConnection.Controls.Add(this.lblSerial);
            this.grpSerialConnection.Location = new System.Drawing.Point(18, 42);
            this.grpSerialConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSerialConnection.Name = "grpSerialConnection";
            this.grpSerialConnection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSerialConnection.Size = new System.Drawing.Size(315, 131);
            this.grpSerialConnection.TabIndex = 7;
            this.grpSerialConnection.TabStop = false;
            this.grpSerialConnection.Text = "Serial Connection";
            // 
            // closePort
            // 
            this.closePort.Location = new System.Drawing.Point(194, 66);
            this.closePort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.closePort.Name = "closePort";
            this.closePort.Size = new System.Drawing.Size(112, 35);
            this.closePort.TabIndex = 5;
            this.closePort.Text = "Close";
            this.closePort.UseVisualStyleBackColor = true;
            this.closePort.Click += new System.EventHandler(this.closePort_Click);
            // 
            // openPort
            // 
            this.openPort.Location = new System.Drawing.Point(42, 66);
            this.openPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openPort.Name = "openPort";
            this.openPort.Size = new System.Drawing.Size(112, 35);
            this.openPort.TabIndex = 4;
            this.openPort.Text = "Open Port";
            this.openPort.UseVisualStyleBackColor = true;
            this.openPort.Click += new System.EventHandler(this.openPort_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(164, 103);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(116, 20);
            this.lblConnectionStatus.TabIndex = 3;
            this.lblConnectionStatus.Text = "Not Connected";
            // 
            // lblConnStatusLabel
            // 
            this.lblConnStatusLabel.AutoSize = true;
            this.lblConnStatusLabel.Location = new System.Drawing.Point(9, 103);
            this.lblConnStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnStatusLabel.Name = "lblConnStatusLabel";
            this.lblConnStatusLabel.Size = new System.Drawing.Size(145, 20);
            this.lblConnStatusLabel.TabIndex = 2;
            this.lblConnStatusLabel.Text = "Connection Status:";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(74, 25);
            this.cmbSerialPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(230, 28);
            this.cmbSerialPort.TabIndex = 1;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(10, 29);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(53, 20);
            this.lblSerial.TabIndex = 0;
            this.lblSerial.Text = "Serial:";
            // 
            // xbeeSerial
            // 
            this.xbeeSerial.BaudRate = 38400;
            this.xbeeSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // parseTimer
            // 
            this.parseTimer.Enabled = true;
            this.parseTimer.Tick += new System.EventHandler(this.parseTimer_Tick);
            // 
            // grpWindInput
            // 
            this.grpWindInput.Controls.Add(this.panelWindInput);
            this.grpWindInput.Location = new System.Drawing.Point(662, 43);
            this.grpWindInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWindInput.Name = "grpWindInput";
            this.grpWindInput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWindInput.Size = new System.Drawing.Size(272, 129);
            this.grpWindInput.TabIndex = 8;
            this.grpWindInput.TabStop = false;
            this.grpWindInput.Text = "Wind Input";
            // 
            // panelWindInput
            // 
            this.panelWindInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWindInput.Location = new System.Drawing.Point(8, 23);
            this.panelWindInput.Name = "panelWindInput";
            this.panelWindInput.Size = new System.Drawing.Size(256, 98);
            this.panelWindInput.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpPayloadDropStatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpGPS);
            this.splitContainer1.Size = new System.Drawing.Size(1623, 446);
            this.splitContainer1.SplitterDistance = 747;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(18, 182);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grpAltitudePlot);
            this.splitContainer2.Size = new System.Drawing.Size(1623, 892);
            this.splitContainer2.SplitterDistance = 446;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 10;
            // 
            // grpAltitudePlot
            // 
            this.grpAltitudePlot.Controls.Add(this.panelAltitudePlot);
            this.grpAltitudePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAltitudePlot.Location = new System.Drawing.Point(0, 0);
            this.grpAltitudePlot.Name = "grpAltitudePlot";
            this.grpAltitudePlot.Size = new System.Drawing.Size(1623, 440);
            this.grpAltitudePlot.TabIndex = 1;
            this.grpAltitudePlot.TabStop = false;
            this.grpAltitudePlot.Text = "Altitude Graph";
            // 
            // panelAltitudePlot
            // 
            this.panelAltitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAltitudePlot.Location = new System.Drawing.Point(6, 26);
            this.panelAltitudePlot.Name = "panelAltitudePlot";
            this.panelAltitudePlot.Size = new System.Drawing.Size(1611, 406);
            this.panelAltitudePlot.TabIndex = 0;
            this.panelAltitudePlot.Load += new System.EventHandler(this.panelAltitudePlot_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1659, 1092);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.grpWindInput);
            this.Controls.Add(this.grpSerialConnection);
            this.Controls.Add(this.grpInstrumentPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "M-Fly Ground Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpPayloadDropStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpInstrumentPanel.ResumeLayout(false);
            this.grpGPS.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpSerialConnection.ResumeLayout(false);
            this.grpSerialConnection.PerformLayout();
            this.grpWindInput.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpAltitudePlot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panels.DropStatus panelDropStatus_CDA;
        private System.Windows.Forms.GroupBox grpPayloadDropStatus;
        private System.Windows.Forms.GroupBox grpInstrumentPanel;
        private System.Windows.Forms.GroupBox grpGPS;
        private Panels.GraphGPS panelGPSPlot;
        private Panels.Instruments panelInstruments;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox grpSerialConnection;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblConnStatusLabel;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Button closePort;
        private System.Windows.Forms.Button openPort;
        private System.IO.Ports.SerialPort xbeeSerial;
        private System.Windows.Forms.Timer parseTimer;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem jump10sBeforeToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpWindInput;
        private Panels.WindParameters panelWindInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Panels.DropStatus panelDropStatus_water;
        private Panels.DropStatus panelDropStatus_ballz;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpAltitudePlot;
        private Panels.AltitudePlot panelAltitudePlot;
    }
}

