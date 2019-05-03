using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    class ColorSelectionPickerButton : ToolButton
    {
        private Form1 form;
        public ColorSelectionPickerButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.colors_wheel;
            BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Select color with picker");
        }

        protected void button_Click(object sender, EventArgs e)
        {
            try
            {
                if (form.imgPicBox.Image == null)
                {
                    MessageBox.Show("No image",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                }

                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
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

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
