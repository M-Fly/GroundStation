using System;
using System.Drawing;
using System.Windows.Forms;

namespace GroundStation.Panels {
    public partial class DropStatus : UserControl {
        public DropStatus() {
            InitializeComponent();

            Resize += (s, e) => {
                Size altSize;
                var size = Payload_Alt_Status.Font.Size;
                var step = 1;
                Font font;
                var ratio = 1.0;
                do {
                    font = new Font(Payload_Alt_Status.Font.FontFamily, size += (ratio < 0 ? 1 : -1));
                    altSize = TextRenderer.MeasureText(
                        Payload_Alt_Status.Text,
                        font,
                        Payload_Alt_Status.Size
                    );
                    ratio = altSize.Height - Payload_Alt_Status.Size.Height;
                } while (Math.Abs(ratio) > 4);
                Payload_Alt_Status.Font = font;
            };
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
