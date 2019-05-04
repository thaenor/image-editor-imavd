using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1.UI
{
    public partial class RemoveChromakeyButton : ToolButton
    {
        private Form1 form;

        public RemoveChromakeyButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.chromakey;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Remove chromakey color");
        }


        private void button_Click(object sender, EventArgs e)
        {
            form.Cursor = Cursors.Cross;
            this.form.activateChromakeyClick();
            this.form.imgPicBox.MouseClick += new MouseEventHandler(imageMouseClick);
        }

        private void imageMouseClick(object sender, MouseEventArgs e)
        {
            form.Cursor = Cursors.Cross;

            Bitmap img = new Bitmap(this.form.imgPicBox.Image);

            Color color = img.GetPixel(e.X, e.Y);
            Image image = form.imgPicBox.Image;
            int width = image.Width;
            int height = image.Height;

            Bitmap imageBitMap = new Bitmap(image);
            int counter = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = imageBitMap.GetPixel(i, j);
                    if (color.ToArgb().Equals(pixelColor.ToArgb()))
                    {
                        Color newColor = img.GetPixel(i, j);
                        newColor = Color.FromArgb(0, 255, 255, 255);
                        img.SetPixel(i, j, newColor);
                    }
                }
            }
            form.NewImageStack(img);
            form.imgPicBox.BackColor = Color.Transparent;

            this.form.imgPicBox.MouseClick -= new MouseEventHandler(imageMouseClick);
            this.form.Cursor = Cursors.Default;
        }
    }
}
