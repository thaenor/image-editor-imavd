using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMAVD1
{
    class InvertColorButton : ToolButton
    {
        private Form1 form;
        public InvertColorButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.invert_color;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Invert colors of image");
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
                else
                {
                    Bitmap pic = new Bitmap(form.imgPicBox.Image);
                    for (int y = 0; (y <= (pic.Height - 1)); y++)
                    {
                        for (int x = 0; (x <= (pic.Width - 1)); x++)
                        {
                            Color color = pic.GetPixel(x, y);
                            color = Color.FromArgb(255, (255 - color.R), (255 - color.G), (255 - color.B));
                            pic.SetPixel(x, y, color);
                        }
                    }

                    form.NewImageStack(pic);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
