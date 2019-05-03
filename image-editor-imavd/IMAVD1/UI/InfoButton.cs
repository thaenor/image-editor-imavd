using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IMAVD1
{
    class InfoButton : ToolButton
    {
        private Form1 form;
        public InfoButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.Image = IMAVD1.Properties.Resources.info;
            setToolTip("Show information of image");
        }

        protected void button_Click(object sender, EventArgs e)
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
                Image image = form.imgPicBox.Image;

                string path = form.imagePath;
                string fileName = Path.GetFileName(path);
                string extension = Path.GetExtension(path);

                int height = image.Height;
                int width = image.Width;

                FileInfo info = new FileInfo(path);
                long size = info.Length;
                DateTime date = info.CreationTime;

                string text = path + fileName + extension + height + width + size + date;
                MessageBox.Show("Name: " + fileName + Environment.NewLine
                    + "Location: " + path + Environment.NewLine
                    + "Extension: " + extension + Environment.NewLine
                    + "Dimensions: " + width + " x " + height + Environment.NewLine
                    + "Size: " + size + " bytes" + Environment.NewLine
                   + "Created at: " + date + Environment.NewLine
                    , "Information");

            }

        }

    }
}
