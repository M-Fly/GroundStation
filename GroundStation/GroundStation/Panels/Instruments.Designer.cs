namespace GroundStation.Panels
{
    partial class Instruments
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
            this.Instruments_Airspeed = new System.Windows.Forms.Label();
            this.Instruments_Alt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Instruments_Airspeed
            // 
            this.Instruments_Airspeed.AutoSize = true;
            this.Instruments_Airspeed.Location = new System.Drawing.Point(4, 4);
            this.Instruments_Airspeed.Name = "Instruments_Airspeed";
            this.Instruments_Airspeed.Size = new System.Drawing.Size(64, 13);
            this.Instruments_Airspeed.TabIndex = 0;
            this.Instruments_Airspeed.Text = "No airspeed";
            // 
            // Instruments_Alt
            // 
            this.Instruments_Alt.AutoSize = true;
            this.Instruments_Alt.Location = new System.Drawing.Point(3, 35);
            this.Instruments_Alt.Name = "Instruments_Alt";
            this.Instruments_Alt.Size = new System.Drawing.Size(59, 13);
            this.Instruments_Alt.TabIndex = 1;
            this.Instruments_Alt.Text = "No Altitude";
            // 
            // Instruments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Instruments_Alt);
            this.Controls.Add(this.Instruments_Airspeed);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Instruments";
            this.Size = new System.Drawing.Size(112, 122);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Instruments_Airspeed;
        private System.Windows.Forms.Label Instruments_Alt;
    }
}
