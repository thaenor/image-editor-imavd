﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace IMAVD1
{
    class ChangeBrightnessButton : ToolButton
    {
        private Form1 form;
        public ChangeBrightnessButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.brightness_icon;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Change brightness");
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
                    form.createValuePickerMenu(this, "Adjust Brightness (0-1)", "0","1");
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

        public override void applyImageValue(float result)
        {           

            if (result >= -255 && result <= 255)
            {

                Bitmap originalImage = (Bitmap)form.imgPicBox.Image;
                Bitmap adjustedImage = (Bitmap)form.imgPicBox.Image;

                float brightness = result;
                float contrast = 1.0f;
                float gamma = 1.0f;

                float adjustedBrightness = brightness - 1.0f;

                float[][] ptsArray ={
                        new float[] {contrast, 0, 0, 0, 0},
                        new float[] {0, contrast, 0, 0, 0},
                        new float[] {0, 0, contrast, 0, 0},
                        new float[] {0, 0, 0, 1.0f, 0},
                        new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.ClearColorMatrix();
                imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
                Graphics g = Graphics.FromImage(adjustedImage);
                g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                    , 0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, imageAttributes);

                form.NewImageStack(adjustedImage);
            }
            else
            {

            }

        }

    }
}
