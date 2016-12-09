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
            this.Payload_Time_Status = new System.Windows.Forms.Label();
            this.Payload_Alt_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Payload_Time_Status
            // 
            this.Payload_Time_Status.AutoSize = true;
            this.Payload_Time_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Payload_Time_Status.Location = new System.Drawing.Point(3, 0);
            this.Payload_Time_Status.Name = "Payload_Time_Status";
            this.Payload_Time_Status.Size = new System.Drawing.Size(106, 20);
            this.Payload_Time_Status.TabIndex = 0;
            this.Payload_Time_Status.Text = "No Drop Time";
            // 
            // Payload_Alt_Status
            // 
            this.Payload_Alt_Status.AutoSize = true;
            this.Payload_Alt_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Payload_Alt_Status.Location = new System.Drawing.Point(3, 20);
            this.Payload_Alt_Status.Name = "Payload_Alt_Status";
            this.Payload_Alt_Status.Size = new System.Drawing.Size(91, 20);
            this.Payload_Alt_Status.TabIndex = 1;
            this.Payload_Alt_Status.Text = "No Drop Alt";
            // 
            // DropStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Payload_Alt_Status);
            this.Controls.Add(this.Payload_Time_Status);
            this.Name = "DropStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Payload_Time_Status;
        private System.Windows.Forms.Label Payload_Alt_Status;
    }
}
