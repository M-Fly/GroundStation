namespace GroundStation.Panels
{
    partial class WindParameters
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
            this.WindParameters_Speed = new System.Windows.Forms.Label();
            this.WindParameters_Direction = new System.Windows.Forms.Label();
            this.WindParameters_SpeedInput = new System.Windows.Forms.TextBox();
            this.WindParameters_DirectionInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WindParameters_Speed
            // 
            this.WindParameters_Speed.AutoSize = true;
            this.WindParameters_Speed.Location = new System.Drawing.Point(0, 0);
            this.WindParameters_Speed.Name = "WindParameters_Speed";
            this.WindParameters_Speed.Size = new System.Drawing.Size(183, 25);
            this.WindParameters_Speed.TabIndex = 0;
            this.WindParameters_Speed.Text = "Wind Speed (m/s)";
            // 
            // WindParameters_Direction
            // 
            this.WindParameters_Direction.AutoSize = true;
            this.WindParameters_Direction.Location = new System.Drawing.Point(0, 62);
            this.WindParameters_Direction.Name = "WindParameters_Direction";
            this.WindParameters_Direction.Size = new System.Drawing.Size(253, 25);
            this.WindParameters_Direction.TabIndex = 1;
            this.WindParameters_Direction.Text = "Wind Direction (Degrees)";
            // 
            // WindParameters_SpeedInput
            // 
            this.WindParameters_SpeedInput.Location = new System.Drawing.Point(46, 28);
            this.WindParameters_SpeedInput.Name = "WindParameters_SpeedInput";
            this.WindParameters_SpeedInput.Size = new System.Drawing.Size(100, 31);
            this.WindParameters_SpeedInput.TabIndex = 2;
            // 
            // WindParameters_DirectionInput
            // 
            this.WindParameters_DirectionInput.Location = new System.Drawing.Point(46, 90);
            this.WindParameters_DirectionInput.Name = "WindParameters_DirectionInput";
            this.WindParameters_DirectionInput.Size = new System.Drawing.Size(100, 31);
            this.WindParameters_DirectionInput.TabIndex = 3;
            // 
            // WindParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WindParameters_DirectionInput);
            this.Controls.Add(this.WindParameters_SpeedInput);
            this.Controls.Add(this.WindParameters_Direction);
            this.Controls.Add(this.WindParameters_Speed);
            this.Name = "WindParameters";
            this.Size = new System.Drawing.Size(282, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WindParameters_Speed;
        private System.Windows.Forms.Label WindParameters_Direction;
        private System.Windows.Forms.TextBox WindParameters_SpeedInput;
        private System.Windows.Forms.TextBox WindParameters_DirectionInput;
    }
}
