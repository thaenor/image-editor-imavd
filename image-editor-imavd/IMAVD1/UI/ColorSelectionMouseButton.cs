using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    class ColorSelectionMouseButton : ToolButton
    {
        private Form1 form;
        public ColorSelectionMouseButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = Properties.Resources.color_counter;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Select color with mouse");
        }

        protected void button_Click(object sender, EventArgs e)
        {
            this.form.Cursor = Cursors.Cross;
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
                        counter++;
                    }
                }
            }

            MessageBox.Show("The color " + color.ToString() + " was found " + counter + " times",
                       "Color Detection",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);


            this.form.imgPicBox.MouseClick -= new MouseEventHandler(imageMouseClick);
            this.form.Cursor = Cursors.Default;
        }
    }
}
