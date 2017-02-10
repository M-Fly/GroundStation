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
        VideoSourcePlayer videoSourcePlayer = null;
        VideoFileWriter vwriter = null;

        // Constructor
        public CameraPanel()
        {
            InitializeComponent();
        }

        public void PromptVideoSource()
        {
            if (videoSourcePlayer == null)
            {
                videoSourcePlayer = new VideoSourcePlayer();

                this.Controls.Add(videoSourcePlayer);

                videoSourcePlayer.Dock = DockStyle.Fill;
                videoSourcePlayer.Location = new Point(0, 0);
                videoSourcePlayer.BorderColor = Color.Transparent;
                videoSourcePlayer.BringToFront();

                videoSourcePlayer.NewFrame += videoSourcePlayer_NewFrame;

                videoSourcePlayer.KeepAspectRatio = true;
            }

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
            // Close Old Video Source and writer
            if (videoSourcePlayer.IsRunning) videoSourcePlayer.Stop();
            CloseVideoSource();

            if (vwriter != null && vwriter.IsOpen)
            {
                vwriter.Close();
            }

            // Open New Video Source
            videoSourcePlayer.VideoSource = device;
            videoSourcePlayer.Start();

            // Create new video file
            // Video file is .avi file. Title has "M-Fly Flight Video" followed by date and time
            vwriter = new VideoFileWriter();
            vwriter.Open("M-Fly Flight Video " + DateTime.Now.ToString("yyyy MMMM dd hh mm") + ".avi", device.VideoResolution.FrameSize.Width, device.VideoResolution.FrameSize.Height, device.VideoResolution.AverageFrameRate);
        }

        public void CloseVideoSource()
        {
            if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
            {
                videoSourcePlayer.Stop();
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

            if (vwriter != null && vwriter.IsOpen)
            {
                vwriter.Flush();
                vwriter.Close();
            }
        }

        // Runs for every new frame
        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(image);

            // paint current time
            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();

            g.Dispose();

            if (vwriter != null) vwriter.WriteVideoFrame(image);
        }
    }
}
