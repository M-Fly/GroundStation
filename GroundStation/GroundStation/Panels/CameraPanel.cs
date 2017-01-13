using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Accord.Controls;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;

namespace GroundStation.Panels
{
    public partial class CameraPanel : UserControl
    {
        VideoSourcePlayer videoSourcePlayer = new VideoSourcePlayer();

        VideoFileWriter vwriter = new VideoFileWriter();

        public CameraPanel()
        {
            InitializeComponent();

            this.Controls.Add(videoSourcePlayer);

            videoSourcePlayer.Dock = DockStyle.Fill;
            videoSourcePlayer.Location = new Point(0, 0);
            videoSourcePlayer.BorderColor = Color.Transparent;
            videoSourcePlayer.BringToFront();

            videoSourcePlayer.NewFrame += videoSourcePlayer_NewFrame;

            videoSourcePlayer.KeepAspectRatio = true;
        }

        public void PromptVideoSource()
        {
            VideoCaptureDeviceForm videoDialogForm = new VideoCaptureDeviceForm();

            if (videoDialogForm.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                VideoCaptureDevice videoSource = videoDialogForm.VideoDevice;

                // open it
                OpenVideoSource(videoSource);
            }
        }

        private void OpenVideoSource(VideoCaptureDevice device)
        {
            // Close Old Video Source
            videoSourcePlayer.Stop();
            CloseVideoSource();

            // Open New Video Source
            videoSourcePlayer.VideoSource = device;
            videoSourcePlayer.Start();

            //Create new video file
            vwriter.Open("M - Fly Flight Video " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".avi", device.VideoResolution.FrameSize.Width, device.VideoResolution.FrameSize.Height, device.VideoResolution.AverageFrameRate);
        }

        public void CloseVideoSource()
        {
            videoSourcePlayer.Stop();

            if (vwriter.IsOpen)
            {
                vwriter.Flush();
                vwriter.Close();
            }

            if (videoSourcePlayer.VideoSource != null)
            {
                if (videoSourcePlayer.VideoSource.IsRunning)
                {
                    videoSourcePlayer.VideoSource.Stop();
                    videoSourcePlayer.VideoSource.WaitForStop();
                }

                videoSourcePlayer.VideoSource = null;
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(image);

            // paint current time
            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();

            g.Dispose();

            vwriter.WriteVideoFrame(image);
        }
    }
}
