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
    public partial class TwoAreasButton : ToolButton
    {
        private Form1 form;

        public TwoAreasButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.two_areas;
            BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Two area crop");
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

                    Rectangle rec1 = new Rectangle(0, 0, this.form.imgPicBox.Width, this.form.imgPicBox.Height / 2);
                    Rectangle rec2 = new Rectangle(0,this.form.imgPicBox.Height / 2, this.form.imgPicBox.Width, this.form.imgPicBox.Height / 2);
                    
                    this.form.twoAreaPicBox1.Image = getCroppedBitmap((Bitmap)this.form.imgPicBox.Image.Clone(), rec1);
                    this.form.twoAreaPicBox2.Image = getCroppedBitmap((Bitmap)this.form.imgPicBox.Image.Clone(), rec2);
                    
                    this.form.valuePickerPanel.Visible = false;
                    this.form.textGroupBox.Visible = false;
                    this.form.graphicsGroupBox.Visible = false;
                    this.form.fourAreasGoupBox.Visible = false;
                    this.form.patternGroupBox.Visible = false;
                    this.form.diagonalCropGroupBox.Visible = false;
                    this.form.twoAreasGroupBox.Visible = true;

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

        public Bitmap getCroppedBitmap(Bitmap originalImg, Rectangle rec)
        {
            Bitmap img = new Bitmap(this.form.imgPicBox.Width, this.form.imgPicBox.Height / 2);

            Graphics gr = Graphics.FromImage(img);

            gr.DrawImage((Image)originalImg.Clone(), new Rectangle(0, 0, originalImg.Width, originalImg.Height / 2), rec, GraphicsUnit.Pixel);

            return img;
        }


    }
}
