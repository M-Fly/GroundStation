using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroundStation.Panels {
    public partial class DropStatus : UserControl {
        public DropStatus() {
            InitializeComponent();
        }

        /// <summary>
        /// Updates this <see cref="DropStatus"/> instance with the given altitude.
        /// Optionally forces the indicator to show a specific value.
        /// </summary>
        /// <param name="alt_ft">payload drop altitude</param>
        /// <param name="isDropped">payload drop flag</param>
        public void UpdateDrop(double alt_ft, bool isDropped = true) {
            statusPanel.BackColor = isDropped ? Color.Green : Color.Red;
            Payload_Alt_Status.Text = $"{alt_ft:0.0} ft";   // States altitude that payload was dropped.
        }

        public string PayloadType {
            get {
                if (string.IsNullOrWhiteSpace(payloadType.Text)) return null;
                return payloadType.Text;
            }
            set {
                payloadType.Text = value;
            }
        }
    }
}
