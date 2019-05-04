using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    class FilterRedButton : ToolButton
    {
        private Form1 form;
        public FilterRedButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.red_filter;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Filter to red colors");
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
                            color = Color.FromArgb(255, (255), (color.G), (color.B));
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
