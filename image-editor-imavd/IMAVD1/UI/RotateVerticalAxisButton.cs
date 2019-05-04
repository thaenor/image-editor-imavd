using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    class RotateVerticalAxisButton : ToolButton
    {
        private Form1 form;
        public RotateVerticalAxisButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.flip_vertical;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Flip the image vertically");
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

                    Image flipImage = form.imgPicBox.Image; ;
                    flipImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                    form.NewImageStack(flipImage);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
