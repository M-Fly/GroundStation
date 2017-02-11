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
            this.WindParameters_Speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WindParameters_Speed.Name = "WindParameters_Speed";
            this.WindParameters_Speed.Size = new System.Drawing.Size(93, 13);
            this.WindParameters_Speed.TabIndex = 0;
            this.WindParameters_Speed.Text = "Wind Speed (m/s)";
            // 
            // WindParameters_Direction
            // 
            this.WindParameters_Direction.AutoSize = true;
            this.WindParameters_Direction.Location = new System.Drawing.Point(0, 32);
            this.WindParameters_Direction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WindParameters_Direction.Name = "WindParameters_Direction";
            this.WindParameters_Direction.Size = new System.Drawing.Size(126, 13);
            this.WindParameters_Direction.TabIndex = 1;
            this.WindParameters_Direction.Text = "Wind Direction (Degrees)";
            // 
            // WindParameters_SpeedInput
            // 
            this.WindParameters_SpeedInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindParameters_SpeedInput.Location = new System.Drawing.Point(97, 2);
            this.WindParameters_SpeedInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WindParameters_SpeedInput.Name = "WindParameters_SpeedInput";
            this.WindParameters_SpeedInput.Size = new System.Drawing.Size(96, 20);
            this.WindParameters_SpeedInput.TabIndex = 2;
            // 
            // WindParameters_DirectionInput
            // 
            this.WindParameters_DirectionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindParameters_DirectionInput.Location = new System.Drawing.Point(130, 29);
            this.WindParameters_DirectionInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WindParameters_DirectionInput.Name = "WindParameters_DirectionInput";
            this.WindParameters_DirectionInput.Size = new System.Drawing.Size(63, 20);
            this.WindParameters_DirectionInput.TabIndex = 3;
            // 
            // WindParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WindParameters_DirectionInput);
            this.Controls.Add(this.WindParameters_SpeedInput);
            this.Controls.Add(this.WindParameters_Direction);
            this.Controls.Add(this.WindParameters_Speed);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WindParameters";
            this.Size = new System.Drawing.Size(195, 64);
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
