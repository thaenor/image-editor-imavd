using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMAVD1.UI
{
    public partial class DiagonalCropButton : ToolButton
    {
        private Form1 form;

        public DiagonalCropButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.triangles_icon;
            BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Diagonal crop");
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

                    Bitmap originalImage = (Bitmap)this.form.imgPicBox.Image;

                    Bitmap img1 = new Bitmap(originalImage.Width, originalImage.Height);
                    img1.MakeTransparent();

                    Bitmap img2 = new Bitmap(originalImage.Width, originalImage.Height);
                    img2.MakeTransparent();

                    float lineSlope = ((float)originalImage.Height) / (-originalImage.Width);
                    float lineB = originalImage.Height;
                   

                    for (int x=0; x < originalImage.Width; x++)
                    {
                        float newY = lineSlope * x + lineB;
                        for(int y = 0; y < originalImage.Height; y++)
                        {
                            if(y <= newY)
                            {
                                img1.SetPixel(x, y, originalImage.GetPixel(x, y));
                            }

                            if(y >= newY)
                            {
                                img2.SetPixel(x, y, originalImage.GetPixel(x, y));
                            }
                        }
                    }

                    this.form.diagonalPicBox1.Image = img1;
                    this.form.diagonalPicBox2.Image = img2;

                    this.form.valuePickerPanel.Visible = false;
                    this.form.textGroupBox.Visible = false;
                    this.form.graphicsGroupBox.Visible = false;
                    this.form.fourAreasGoupBox.Visible = false;
                    this.form.twoAreasGroupBox.Visible = false;
                    this.form.patternGroupBox.Visible = false;
                    this.form.diagonalCropGroupBox.Visible = true;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error",
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation,
                             MessageBoxDefaultButton.Button1);
            }



        }

       


    }
}
