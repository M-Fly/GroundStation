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
            this.graphGPS1 = new GroundStation.Panels.GraphGPS();
            this.instruments1 = new GroundStation.Panels.Instruments();
            this.dropStatusPanel = new GroundStation.Panels.DropStatus();
            this.altitudePlotPanel = new GroundStation.Panels.AltitudePlot();
            this.grpAltitudePlot.SuspendLayout();
            this.grpPayloadDropStatus.SuspendLayout();
            this.grpInstrumentPanel.SuspendLayout();
            this.GraphGPSDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAltitudePlot
            // 
            this.grpAltitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAltitudePlot.Controls.Add(this.altitudePlotPanel);
            this.grpAltitudePlot.Location = new System.Drawing.Point(9, 364);
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
            this.groupBox2.Location = new System.Drawing.Point(13, 100);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(439, 260);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera";
            // 
            // grpDropPredictionStatus
            // 
            this.grpDropPredictionStatus.AutoSize = true;
            this.grpDropPredictionStatus.Location = new System.Drawing.Point(223, 10);
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
            this.grpPayloadDropStatus.Location = new System.Drawing.Point(839, 13);
            this.grpPayloadDropStatus.Name = "grpPayloadDropStatus";
            this.grpPayloadDropStatus.Size = new System.Drawing.Size(255, 82);
            this.grpPayloadDropStatus.TabIndex = 3;
            this.grpPayloadDropStatus.TabStop = false;
            this.grpPayloadDropStatus.Text = "Payload Drop Status";
            // 
            // grpInstrumentPanel
            // 
            this.grpInstrumentPanel.Controls.Add(this.instruments1);
            this.grpInstrumentPanel.Location = new System.Drawing.Point(12, 10);
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
            this.GraphGPSDisplay.Location = new System.Drawing.Point(457, 100);
            this.GraphGPSDisplay.Name = "GraphGPSDisplay";
            this.GraphGPSDisplay.Size = new System.Drawing.Size(638, 260);
            this.GraphGPSDisplay.TabIndex = 5;
            this.GraphGPSDisplay.TabStop = false;
            this.GraphGPSDisplay.Text = "GraphGPSDisplay";
            // 
            // tmrTestData
            // 
            this.tmrTestData.Enabled = true;
            this.tmrTestData.Interval = 500;
            this.tmrTestData.Tick += new System.EventHandler(this.tmrTestData_Tick);
            // 
            // graphGPS1
            // 
            this.graphGPS1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphGPS1.Location = new System.Drawing.Point(6, 19);
            this.graphGPS1.Name = "graphGPS1";
            this.graphGPS1.Size = new System.Drawing.Size(625, 235);
            this.graphGPS1.TabIndex = 0;
            // 
            // instruments1
            // 
            this.instruments1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instruments1.Location = new System.Drawing.Point(0, 22);
            this.instruments1.Margin = new System.Windows.Forms.Padding(2);
            this.instruments1.Name = "instruments1";
            this.instruments1.Size = new System.Drawing.Size(196, 58);
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
            this.ClientSize = new System.Drawing.Size(1106, 648);
            this.Controls.Add(this.grpDropPredictionStatus);
            this.Controls.Add(this.GraphGPSDisplay);
            this.Controls.Add(this.grpInstrumentPanel);
            this.Controls.Add(this.grpPayloadDropStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpAltitudePlot);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "M-Fly Ground Station";
            this.grpAltitudePlot.ResumeLayout(false);
            this.grpPayloadDropStatus.ResumeLayout(false);
            this.grpInstrumentPanel.ResumeLayout(false);
            this.GraphGPSDisplay.ResumeLayout(false);
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
    }
}

