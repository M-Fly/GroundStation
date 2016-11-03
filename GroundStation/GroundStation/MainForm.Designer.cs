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
            this.grpAltitudePlot = new System.Windows.Forms.GroupBox();
            this.panelAltitudePlot = new GroundStation.Panels.AltitudePlot();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.grpDropPredictionStatus = new System.Windows.Forms.GroupBox();
            this.grpPayloadDropStatus = new System.Windows.Forms.GroupBox();
            this.panelDropStatus = new GroundStation.Panels.DropStatus();
            this.grpInstrumentPanel = new System.Windows.Forms.GroupBox();
            this.panelInstruments = new GroundStation.Panels.Instruments();
            this.grpAltitudePlot.SuspendLayout();
            this.grpPayloadDropStatus.SuspendLayout();
            this.grpInstrumentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAltitudePlot
            // 
            this.grpAltitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAltitudePlot.Controls.Add(this.panelAltitudePlot);
            this.grpAltitudePlot.Location = new System.Drawing.Point(9, 364);
            this.grpAltitudePlot.Margin = new System.Windows.Forms.Padding(2);
            this.grpAltitudePlot.Name = "grpAltitudePlot";
            this.grpAltitudePlot.Padding = new System.Windows.Forms.Padding(2);
            this.grpAltitudePlot.Size = new System.Drawing.Size(1086, 275);
            this.grpAltitudePlot.TabIndex = 0;
            this.grpAltitudePlot.TabStop = false;
            this.grpAltitudePlot.Text = "Altitude Graph";
            // 
            // panelAltitudePlot
            // 
            this.panelAltitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAltitudePlot.Location = new System.Drawing.Point(4, 17);
            this.panelAltitudePlot.Margin = new System.Windows.Forms.Padding(2);
            this.panelAltitudePlot.Name = "panelAltitudePlot";
            this.panelAltitudePlot.Size = new System.Drawing.Size(1078, 253);
            this.panelAltitudePlot.TabIndex = 0;
            // 
            // grpCamera
            // 
            this.grpCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCamera.AutoSize = true;
            this.grpCamera.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.grpCamera.Location = new System.Drawing.Point(220, 10);
            this.grpCamera.Margin = new System.Windows.Forms.Padding(2);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Padding = new System.Windows.Forms.Padding(2);
            this.grpCamera.Size = new System.Drawing.Size(697, 350);
            this.grpCamera.TabIndex = 1;
            this.grpCamera.TabStop = false;
            this.grpCamera.Text = "Camera";
            // 
            // grpDropPredictionStatus
            // 
            this.grpDropPredictionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDropPredictionStatus.AutoSize = true;
            this.grpDropPredictionStatus.Location = new System.Drawing.Point(9, 208);
            this.grpDropPredictionStatus.Margin = new System.Windows.Forms.Padding(2);
            this.grpDropPredictionStatus.Name = "grpDropPredictionStatus";
            this.grpDropPredictionStatus.Padding = new System.Windows.Forms.Padding(2);
            this.grpDropPredictionStatus.Size = new System.Drawing.Size(207, 152);
            this.grpDropPredictionStatus.TabIndex = 2;
            this.grpDropPredictionStatus.TabStop = false;
            this.grpDropPredictionStatus.Text = "Drop Prediction Status";
            // 
            // grpPayloadDropStatus
            // 
            this.grpPayloadDropStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPayloadDropStatus.Controls.Add(this.panelDropStatus);
            this.grpPayloadDropStatus.Location = new System.Drawing.Point(923, 13);
            this.grpPayloadDropStatus.Name = "grpPayloadDropStatus";
            this.grpPayloadDropStatus.Size = new System.Drawing.Size(171, 347);
            this.grpPayloadDropStatus.TabIndex = 3;
            this.grpPayloadDropStatus.TabStop = false;
            this.grpPayloadDropStatus.Text = "Payload Drop Status";
            // 
            // panelDropStatus
            // 
            this.panelDropStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDropStatus.Location = new System.Drawing.Point(6, 19);
            this.panelDropStatus.Name = "panelDropStatus";
            this.panelDropStatus.Size = new System.Drawing.Size(159, 322);
            this.panelDropStatus.TabIndex = 3;
            // 
            // grpInstrumentPanel
            // 
            this.grpInstrumentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpInstrumentPanel.Controls.Add(this.panelInstruments);
            this.grpInstrumentPanel.Location = new System.Drawing.Point(9, 10);
            this.grpInstrumentPanel.Name = "grpInstrumentPanel";
            this.grpInstrumentPanel.Size = new System.Drawing.Size(207, 193);
            this.grpInstrumentPanel.TabIndex = 4;
            this.grpInstrumentPanel.TabStop = false;
            this.grpInstrumentPanel.Text = "Instrument Panel";
            // 
            // panelInstruments
            // 
            this.panelInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInstruments.Location = new System.Drawing.Point(5, 18);
            this.panelInstruments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelInstruments.Name = "panelInstruments";
            this.panelInstruments.Size = new System.Drawing.Size(197, 170);
            this.panelInstruments.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 648);
            this.Controls.Add(this.grpInstrumentPanel);
            this.Controls.Add(this.grpPayloadDropStatus);
            this.Controls.Add(this.grpDropPredictionStatus);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.grpAltitudePlot);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "M-Fly Ground Station";
            this.grpAltitudePlot.ResumeLayout(false);
            this.grpPayloadDropStatus.ResumeLayout(false);
            this.grpInstrumentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAltitudePlot;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.GroupBox grpDropPredictionStatus;
        private Panels.AltitudePlot panelAltitudePlot;
        private Panels.DropStatus panelDropStatus;
        private System.Windows.Forms.GroupBox grpPayloadDropStatus;
        private System.Windows.Forms.GroupBox grpInstrumentPanel;
        private Panels.Instruments panelInstruments;
    }
}

