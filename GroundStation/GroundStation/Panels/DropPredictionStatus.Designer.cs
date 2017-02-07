namespace GroundStation.Panels
{
    partial class DropPredictionStatus
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
            this.Drop_Predict_GPS = new System.Windows.Forms.Label();
            this.Drop_Plane_GPS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Drop_Predict_GPS
            // 
            this.Drop_Predict_GPS.AutoSize = true;
            this.Drop_Predict_GPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drop_Predict_GPS.Location = new System.Drawing.Point(3, 0);
            this.Drop_Predict_GPS.Name = "Drop_Predict_GPS";
            this.Drop_Predict_GPS.Size = new System.Drawing.Size(47, 13);
            this.Drop_Predict_GPS.TabIndex = 0;
            this.Drop_Predict_GPS.Text = "No Drop";
            // 
            // Drop_Plane_GPS
            // 
            this.Drop_Plane_GPS.AutoSize = true;
            this.Drop_Plane_GPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drop_Plane_GPS.Location = new System.Drawing.Point(3, 20);
            this.Drop_Plane_GPS.Name = "Drop_Plane_GPS";
            this.Drop_Plane_GPS.Size = new System.Drawing.Size(47, 13);
            this.Drop_Plane_GPS.TabIndex = 1;
            this.Drop_Plane_GPS.Text = "No Drop";
            // 
            // DropPredictionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Drop_Plane_GPS);
            this.Controls.Add(this.Drop_Predict_GPS);
            this.Name = "DropPredictionStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Drop_Predict_GPS;
        private System.Windows.Forms.Label Drop_Plane_GPS;
    }
}
