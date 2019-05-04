using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1.UI
{
    public partial class CropButton : ToolButton
    {
        private Form1 form;

        private bool bHaveMouse;
        private Point ptOriginal;
        private Point ptLast;
        private Rectangle rectCropArea;

        public CropButton(Form1 form) : base()
        {
            Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = Properties.Resources.crop;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Crop Image");
        }



        private void button_Click(object sender, EventArgs e)
        {
            if (form.Cursor == Cursors.Cross)
                Clear();
            else
            {
                form.Cursor = Cursors.Cross;
                form.imgPicBox.MouseDown += imgPicBox_MouseDown;
                form.imgPicBox.MouseUp += imgPicBox_MouseUp;
                form.imgPicBox.MouseMove += imgPicBox_MouseMove;
                form.imgPicBox.Paint += imgPicBox_Paint;
            }
        }

        private void imgPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            bHaveMouse = true;

            ptOriginal.X = e.X;
            ptOriginal.Y = e.Y;

            ptLast.X = -1;
            ptLast.Y = -1;

            rectCropArea = new Rectangle(new Point(e.X, e.Y), new Size());
        }

        private void imgPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);

            if (bHaveMouse)
            {

                ptLast = ptCurrent;

                if (e.X > ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;

                    rectCropArea.Height = e.Y - ptOriginal.Y;
                }
                else if (e.X < ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = ptOriginal.X - e.X;
                    rectCropArea.Height = e.Y - ptOriginal.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = ptOriginal.Y;
                }
                else if (e.X > ptOriginal.X && e.Y < ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;
                    rectCropArea.Height = ptOriginal.Y - e.Y;

                    rectCropArea.X = ptOriginal.X;
                    rectCropArea.Y = e.Y;
                }
                else
                {
                    rectCropArea.Width = ptOriginal.X - e.X;

                    rectCropArea.Height = ptOriginal.Y - e.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = e.Y;
                }
                form.imgPicBox.Refresh();
            }
        }

        private void imgPicBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), rectCropArea);
        }

        private void imgPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (bHaveMouse)
            {
                bHaveMouse = false;

                if (ptLast.X != -1)
                {
                    Bitmap area = new Bitmap(rectCropArea.Width, rectCropArea.Height);
                    Graphics gr = Graphics.FromImage(area);
                    Point ptCurrent = new Point(e.X, e.Y);
                    Rectangle source_rectangle = new Rectangle(Math.Min(ptOriginal.X, ptCurrent.X), Math.Min(ptOriginal.Y, ptCurrent.Y), rectCropArea.Width, rectCropArea.Height);
                    Rectangle dest_rectangle = new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height);
                    gr.DrawImage((Image)form.imgPicBox.Image.Clone(), dest_rectangle,
                        source_rectangle, GraphicsUnit.Pixel);
                    form.NewImageStack(area);
                }
                Clear();
            }
        }

        private void Clear()
        {
            form.Cursor = Cursors.Default;

            ptLast.X = -1;
            ptLast.Y = -1;
            ptOriginal.X = -1;
            ptOriginal.Y = -1;

            form.imgPicBox.MouseDown -= imgPicBox_MouseDown;
            form.imgPicBox.MouseUp -= imgPicBox_MouseUp;
            form.imgPicBox.MouseMove -= imgPicBox_MouseMove;
            form.imgPicBox.Paint -= imgPicBox_Paint;
        }
    }
}
