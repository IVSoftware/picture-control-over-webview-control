In `WinForms` you can show _any_ control (e.g. `PictureBox`) over any _other_ control (e.g. `WebView2`) by adding the former to the `Controls` collection of the latter.

[![screenshot][1]][1]

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
        .
        .
        .
    }

***
To make the picture box do this:

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


  [1]: https://i.stack.imgur.com/jNc1i.png