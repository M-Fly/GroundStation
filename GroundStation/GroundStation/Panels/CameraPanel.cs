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
        // Objects to handle the video source (camera) and the video file writer (saving the video to a file)
        VideoSourcePlayer videoSourcePlayer = null;
        VideoFileWriter vwriter = null;

        // Constructor
        public CameraPanel()
        {
            InitializeComponent();
        }

        // Creates a prompt asking the user which video device to use (webcam, usb camera, etc...)
        public void PromptVideoSource()
        {
            // If their is no video source
            if (videoSourcePlayer == null)
            {
                // Create the video source player and add it to the form
                videoSourcePlayer = new VideoSourcePlayer();

                this.Controls.Add(videoSourcePlayer);

                // Properties to add the video source player to the form
                videoSourcePlayer.Dock = DockStyle.Fill;
                videoSourcePlayer.Location = new Point(0, 0);
                videoSourcePlayer.BorderColor = Color.Transparent;
                videoSourcePlayer.BringToFront();

                // Add the new frame callback to the source player
                videoSourcePlayer.NewFrame += videoSourcePlayer_NewFrame;

                // Force to keep the original source aspect ratio
                videoSourcePlayer.KeepAspectRatio = true;
            }

            // Create the dialog box
            VideoCaptureDeviceForm videoDialogForm = new VideoCaptureDeviceForm();

            // If the dialog exited correctly, open the video source
            if (videoDialogForm.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                VideoCaptureDevice videoSource = videoDialogForm.VideoDevice;

                // open the video device
                OpenVideoSource(videoSource);
            }
        }

        private void OpenVideoSource(VideoCaptureDevice device)
        {
            // Close Old Video Source and writer
            if (videoSourcePlayer.IsRunning) videoSourcePlayer.Stop();
            CloseVideoSource();

            // Close the writer if it is already open so it can be re-opened with the new source
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

        // Closes the video source
        public void CloseVideoSource()
        {
            // If the video source player exists and is running
            if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
            {
                // Stop the source and set the object to null
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

            // If the video writer isn't null, flush its output and close it
            if (vwriter != null && vwriter.IsOpen)
            {
                vwriter.Flush();
                vwriter.Close();
            }
        }

        // Runs for every new frame
        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            // Datetime to print on the video frame
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(image);

            // paint current time
            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();

            // dispose the graphics object
            g.Dispose();

            // Write the new frame (with the date) to the video writer
            if (vwriter != null) vwriter.WriteVideoFrame(image);
        }
    }
}
