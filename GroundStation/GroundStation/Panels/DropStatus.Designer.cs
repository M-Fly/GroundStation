namespace GroundStation.Panels
{
    partial class DropStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Payload_Alt_Status = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.payloadType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Payload_Alt_Status
            // 
            this.Payload_Alt_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Payload_Alt_Status.AutoEllipsis = true;
            this.Payload_Alt_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Payload_Alt_Status.Location = new System.Drawing.Point(129, 29);
            this.Payload_Alt_Status.Name = "Payload_Alt_Status";
            this.Payload_Alt_Status.Size = new System.Drawing.Size(410, 111);
            this.Payload_Alt_Status.TabIndex = 1;
            this.Payload_Alt_Status.Text = "--";
            this.Payload_Alt_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.statusPanel.BackColor = System.Drawing.Color.Red;
            this.statusPanel.Location = new System.Drawing.Point(3, 29);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(114, 110);
            this.statusPanel.TabIndex = 2;
            // 
            // payloadType
            // 
            this.payloadType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.payloadType.AutoEllipsis = true;
            this.payloadType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.payloadType.Location = new System.Drawing.Point(123, 0);
            this.payloadType.Name = "payloadType";
            this.payloadType.Size = new System.Drawing.Size(416, 29);
            this.payloadType.TabIndex = 3;
            this.payloadType.Text = "TEST test";
            this.payloadType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DropStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.payloadType);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.Payload_Alt_Status);
            this.Name = "DropStatus";
            this.Size = new System.Drawing.Size(542, 143);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Payload_Alt_Status;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label payloadType;
    }
}
