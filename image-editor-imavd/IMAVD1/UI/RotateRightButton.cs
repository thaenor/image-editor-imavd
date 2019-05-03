using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    class RotateRightButton : ToolButton
    {
        private Form1 form;
        public RotateRightButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.rotate_right_arrow;
            BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Rotate 90º to the right");
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
                    flipImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    form.NewImageStack(flipImage);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
