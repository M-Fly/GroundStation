using System.Drawing;
using System.Windows.Forms;

namespace GroundStation.Panels {
    public partial class DropStatus : UserControl {
        public DropStatus() {
            InitializeComponent();

            Resize += (s, e) => {
                // ensures that the indicator is a square
                //statusPanel.Width = statusPanel.Height;

                Size altSize;
                var size = Payload_Alt_Status.Font.Size;
                var step = 2;
                Font font;
                do {
                    font = new Font(Payload_Alt_Status.Font.FontFamily, size += step);
                    altSize = TextRenderer.MeasureText(
                        Payload_Alt_Status.Text,
                        font,
                        Payload_Alt_Status.Size
                    );
                    step = altSize.Ratio(Payload_Alt_Status.Size) > 1 ? 2 : -2;
                } while (!altSize.FitsInto(Payload_Alt_Status.Size));
                Payload_Alt_Status.Font = font;

                //Payload_Alt_Status.Location = Payload_Alt_Status.Location + new Size(statusPanel.Width + 9, 0);
                //payloadType.Location = payloadType.Location + new Size(statusPanel.Width + 9, 0);
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
