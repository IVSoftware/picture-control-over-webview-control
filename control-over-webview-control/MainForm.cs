using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace control_over_webview_control
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            const int WIDTH = 500, HEIGHT = 250;

            // Path to image on the local hard drive.
            string pathToImageOnLocalHardDrive = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Images",
                "0n0cW.jpg"
            );

            PictureBox pictureBox = CreatePictureBox(
                path: pathToImageOnLocalHardDrive,
                maxWidth: WIDTH,
                maxHeight: HEIGHT
            );
            pictureBox.Location = new Point(
                webView21.Right - pictureBox.Width,
                webView21.Bottom - pictureBox.Height);

            webView21.Controls.Add(pictureBox);
        }

        private PictureBox CreatePictureBox(
            string path,
            int maxWidth, 
            int maxHeight)
        {
            PictureBox newPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Aqua,
                Image = Bitmap.FromFile(path),
            };
            var measure = (Bitmap)newPictureBox.Image;
            float scaleWidth = maxWidth / (float)measure.Width;
            float scaleHeight = maxHeight / (float)measure.Height;
            float allowedScale = Math.Min(scaleWidth, scaleHeight);
            newPictureBox.Size = new Size
            {
                Width = (int)(allowedScale * measure.Width),
                Height = (int)(allowedScale * measure.Height),
            };
            return newPictureBox;
        }
    }
}
