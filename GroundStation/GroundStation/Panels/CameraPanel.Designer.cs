namespace GroundStation.Panels
{
    partial class CameraPanel
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
            this.lblWaiting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWaiting
            // 
            this.lblWaiting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblWaiting.Location = new System.Drawing.Point(0, 0);
            this.lblWaiting.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(235, 193);
            this.lblWaiting.TabIndex = 0;
            this.lblWaiting.Text = "Waiting for Camera Connection\r\nEnable Camera in Menubar";
            this.lblWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWaiting);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "CameraPanel";
            this.Size = new System.Drawing.Size(235, 193);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWaiting;
    }
}
