using System;
using System.Drawing;


namespace IMAVD1
{
    public partial class ResizeForm : MetroFramework.Forms.MetroForm
    {
        Form1 mainForm;

        public ResizeForm(Form1 form)
        {
            
            InitializeComponent();
            this.CenterToParent();
            this.mainForm = form;
            this.numericUpDownH.Value = this.mainForm.imgPicBox.Height;
            this.numericUpDownW.Value = this.mainForm.imgPicBox.Width;
           
        }

        private void okResizeBtn_Click(object sender, EventArgs e)
        {

            Image newImage = resize(this.mainForm.imgPicBox.Image, (int)numericUpDownW.Value, (int)numericUpDownH.Value);
            this.mainForm.imgPicBox.Height = (int)numericUpDownH.Value;
            this.mainForm.imgPicBox.Width = (int)numericUpDownW.Value;
            this.mainForm.imgPicBox.Image = newImage;
            this.Close();
        }

        private Image resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }

        private void cancelResizeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
