using IMAVD1.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public string imagePath;
        ToolButton toolButton;
        private Image imgOriginal;

        private List<Image> stackImages = new List<Image>();
        private List<Image> stackRedoImages = new List<Image>();
        private ToolStripMenuItem selectedZoom;

        private Font textFont;
        private Color textColor;

        private Boolean imageClick;

        public Form1()
        {

            InitializeComponent();

            this.StyleManager = appStyle;

            selectedZoom = zoom100toolStripMenuItem;
            WindowState = FormWindowState.Maximized;
            this.Text = "Image Editor";
            addToolButtons();
            addToolButtonsBasics();

            this.textFont = new Font("Arial", 14);
            this.textColor = Color.Black;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            themeCombo.SelectedIndex = 0;
            colorCombo.SelectedIndex = 0;
        }

        //**********************************************************************************************************************************************************
        //**TOOLS BUTTONS**

        //botoes tools 1
        private void addToolButtons()
        {
            this.toolsPanel.Controls.Add(new InvertColorButton(this));
            this.toolsPanel.Controls.Add(new FilterRedButton(this));
            this.toolsPanel.Controls.Add(new FilterGreenButton(this));
            this.toolsPanel.Controls.Add(new FilterBlueButton(this));
            this.toolsPanel.Controls.Add(new ChangeBrightnessButton(this));
            this.toolsPanel.Controls.Add(new ChangeContrastButton(this));
            this.toolsPanel.Controls.Add(new ChangeGamaButton(this));

        }
        //botoes tools 1
        private void addToolButtonsBasics()
        {
            this.toolsPanelBasic.Controls.Add(new InfoButton(this));
            this.toolsPanelBasic.Controls.Add(new ColorSelectionPickerButton(this));
            this.toolsPanelBasic.Controls.Add(new ColorSelectionMouseButton(this));
            this.toolsPanelBasic.Controls.Add(new RotateLeftButton(this));
            this.toolsPanelBasic.Controls.Add(new RotateRightButton(this));
            this.toolsPanelBasic.Controls.Add(new RotateVerticalAxisButton(this));
            this.toolsPanelBasic.Controls.Add(new RotateHorizontalAxisButton(this));
            this.toolsPanelBasic.Controls.Add(new CropButton(this));
            this.toolsPanelBasic.Controls.Add(new AddGraphicsButton(this));
            this.toolsPanelBasic.Controls.Add(new AddTextButton(this));
            this.toolsPanelBasic.Controls.Add(new RemoveChromakeyButton(this));
            this.toolsPanelBasic.Controls.Add(new FourAreasButton(this));
            this.toolsPanelBasic.Controls.Add(new TwoAreasButton(this));
            this.toolsPanelBasic.Controls.Add(new DiagonalCropButton(this));

        }


        //**********************************************************************************************************************************************************

        //**FILE MENU**
        //metro button File
        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroContextMenuFile.Show(metroTile1, 0, metroTile1.Height);
        }

        //file context menu new button
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imgPicBox.BackColor = Color.White;
            this.imgPicBox.ImageLocation = null;
            stackImages.Clear();
            stackRedoImages.Clear();
        }

        //file context menu open button 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                stackImages.Clear();
                stackRedoImages.Clear();
                imagePath = file.FileName;
                this.imgPicBox.ImageLocation = imagePath;
                imgPicBox.LoadCompleted += new AsyncCompletedEventHandler(ImageCompleted);
                this.fontXUpDown.Maximum = this.imgPicBox.Width;
                this.fontYUpDown.Maximum = this.imgPicBox.Height;
                this.imageClick = false;


            }
        }

        //file context menu save button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(this.imgPicBox.Image);
        }


        //file context menu exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        //**********************************************************************************************************************************************************

        //**EDIT MENU**
        //metro button Edit
        private void metroTile2_Click(object sender, EventArgs e)
        {
            metroContextMenuEdit.Show(metroTile2, 0, metroTile2.Height);
        }
        //edit context menu undo button
        private void toolStripMenuItemUndo_Click_1(object sender, EventArgs e)
        {
            undo();
        }
        
        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            undo();
        }
        
        public void undo()
        {
            if (stackImages.Count > 1)
            {
                Image currentImage = (Image)stackImages[0].Clone();
                Image undoImage = (Image)stackImages[1].Clone();
                stackImages.RemoveAt(0);
                imgPicBox.Image = (Image)undoImage.Clone();
                stackRedoImages.Insert(0, (Image)currentImage.Clone());
                imgOriginal = (Image)imgPicBox.Image.Clone();
                zoom100toolStripMenuItem.PerformClick();
                if (stackRedoImages.Count > 0)
                    redoToolStripMenuItem.Enabled = true;
                    toolStripMenuItemRedo.Enabled = true;
            }
            if (stackImages.Count <= 1)
            {
                undoToolStripMenuItem.Enabled = false;
                toolStripMenuItemUndo.Enabled = false;
            }
        }

        //edit context menu redo button
        private void toolStripMenuItemRedo_Click_1(object sender, EventArgs e)
        {
            redo();
        }
        private void redoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            redo();
        }

        public void redo()
        {
            if (stackRedoImages.Count > 0)
            {
                Image currentImage = (Image)stackRedoImages[0].Clone();
                stackRedoImages.RemoveAt(0);
                imgPicBox.Image = (Image)currentImage.Clone();
                stackImages.Insert(0, (Image)currentImage.Clone());
                imgOriginal = (Image)imgPicBox.Image.Clone();
                zoom100toolStripMenuItem.PerformClick();
            }
            if (stackRedoImages.Count == 0)
            {
                redoToolStripMenuItem.Enabled = false;
                toolStripMenuItemRedo.Enabled = false;
            }
            if (stackImages.Count > 1)
                undoToolStripMenuItem.Enabled = true;
                toolStripMenuItemUndo.Enabled = true;
        }

        //edit context menu resize image button
        private void toolStripMenuItemResizeImage_Click(object sender, EventArgs e)
        {
            ResizeForm resizeForm = new ResizeForm(this);
            resizeForm.Show();
            resizeForm.StyleManager = this.StyleManager;
        }
        
        //edit context menu pattern button
        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowsInput.Value = 1;
            columnsInput.Value = 1;
            this.valuePickerPanel.Visible = false;
            this.textGroupBox.Visible = false;
            this.graphicsGroupBox.Visible = false;
            this.twoAreasGroupBox.Visible = false;
            this.fourAreasGoupBox.Visible = false;
            this.diagonalCropGroupBox.Visible = false;
            this.patternGroupBox.Visible = true;
        }

        //**********************************************************************************************************************************************************

        //**SETTINGS MENU**
        //Theme
        private void themeCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (themeCombo.SelectedIndex)
            {
                case 0:
                    appStyle.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case 1:
                    appStyle.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
            }
}
        //Color
        private void colorCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            appStyle.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(colorCombo.SelectedIndex);
        }
        

        //**********************************************************************************************************************************************************

        private void ImageCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && stackImages.Count == 0)
            {
                stackImages.Insert(0, (Image)imgPicBox.Image.Clone());
                imgOriginal = (Image)imgPicBox.Image.Clone();
            }
            imgPicBox.LoadCompleted -= new AsyncCompletedEventHandler(ImageCompleted);
        }

        private void saveImage(Image img)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            dialog.Title = "Save an Image File";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {

                System.IO.FileStream fs = (System.IO.FileStream)dialog.OpenFile();
                switch (dialog.FilterIndex)
                {
                    case 1:

                        img.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        img.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        img.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        img.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                fs.Close();
            }

        }
        
        internal void NewImageStack(Image newImage)
        {
            stackRedoImages.Clear();
            imgPicBox.Image = (Image)newImage.Clone();
            stackImages.Insert(0, (Image)newImage.Clone());
            imgOriginal = (Image)newImage.Clone();
            if (stackImages.Count > 1)
                undoToolStripMenuItem.Enabled = true;
                toolStripMenuItemUndo.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
            toolStripMenuItemRedo.Enabled = false;
        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 70, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 70, Top = 50, Width = 100 };
            Button confirmation = new Button() { Text = "Ok", Left = 70, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        
        public void createValuePickerMenu(ToolButton toolButton, string title, string min, string max)
        {
            this.toolButton = toolButton;

            this.valueNameLabel.Text = title;
            this.textBox1.Text = "";
            this.minLabel.Text = min.ToString();
            this.maxLabel.Text = max.ToString();
            this.textGroupBox.Visible = false;
            this.graphicsGroupBox.Visible = false;
            this.fourAreasGoupBox.Visible = false;
            this.twoAreasGroupBox.Visible = false;
            this.patternGroupBox.Visible = false;
            this.diagonalCropGroupBox.Visible = false;
            this.valuePickerPanel.Visible = true;

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (this.toolButton != null && this.textBox1.Text != "")
            {
                this.toolButton.applyImageValue((float)Convert.ToDouble(this.textBox1.Text.Replace('.', ',')));
            }
            this.valuePickerPanel.Visible = false;

        }

        private void Zoom_OnClick(object sender, EventArgs e)
        {
            selectedZoom.Checked = false;
            string text = ((ToolStripMenuItem)sender).Text;
            switch (text)
            {
                case "50%":
                    selectedZoom = zoom50toolStripMenuItem;
                    break;
                case "100%":
                    selectedZoom = zoom100toolStripMenuItem;
                    break;
                case "150%":
                    selectedZoom = zoom150toolStripMenuItem;
                    break;
                case "200%":
                    selectedZoom = zoom200toolStripMenuItem;
                    break;
                case "400%":
                    selectedZoom = zoom400toolStripMenuItem;
                    break;
                case "500%":
                    selectedZoom = zoom500toolStripMenuItem;
                    break;
            }
            Zoom(imgOriginal, float.Parse(text.Replace("%", "")) / 100);
            zoomLabel.Text = "Zoom: " + text;
            selectedZoom.Checked = true;
        }
        
        private void Zoom(Image image, float zoomFactor)
        {
            Size newSize = new Size((int)(image.Width * zoomFactor), (int)(image.Height * zoomFactor));
            Bitmap bmp = new Bitmap((Image)image.Clone(), newSize);
            imgPicBox.Image = bmp;
        }
       
        private void loadGraphicsImageBtn_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Title = "Select Image File", Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif" };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                graphicsPicBox.Image = Image.FromFile(fileDialog.FileName);
                graphicsImageName.Text = fileDialog.SafeFileName;
            }
        }

        private void drawLogo(Bitmap img, Bitmap graphics, float x, float y, float w, float h)
        {

            if (graphicsPicBox.Image == null)
            {
                MessageBox.Show("No image to apply",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
            }
            else
            {

                Graphics g = Graphics.FromImage(img);
                g.DrawImage(graphicsPicBox.Image, img.Width * (x / 100), img.Height * (y / 100), img.Width * (w / 100), img.Height * (h / 100));
            }
        }

        private void cancelGraphics()
        {
            graphicsGroupBox.Visible = false;
            graphicsPicBox.Image = null;
            graphicsImageName.Text = "Image Name";
        }

        private void applyGraphicsBtn_Click(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)imgPicBox.Image;
            drawLogo(img, (Bitmap)graphicsPicBox.Image, (float)numericUpDownX.Value, (float)numericUpDownY.Value, (float)numericUpDownW.Value, (float)numericUpDownH.Value);
            NewImageStack((Image)img.Clone());

            cancelGraphics();
        }

        private void cancelGraphicsBtn_Click(object sender, EventArgs e)
        {
            cancelGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.textFont = fontDialog.Font;
                this.fontNameLbl.Text = this.textFont.Name;
                this.fontNameLbl.Font = this.textFont;
            }
        }
    
        private void chooseFontColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textColor = colorDialog.Color;
                this.fontNameLbl.ForeColor = this.textColor;
            }
        }

        private void cancelText()
        {
            this.textGroupBox.Visible = false;
            this.textBox.Text = "";
            this.fontNameLbl.Text = "- - -";
            this.fontXUpDown.Value = 0;
            this.fontYUpDown.Value = 0;
            this.textFont = new Font("Arial", 14);
            this.textColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)imgPicBox.Image;
            Graphics g = Graphics.FromImage(img);
            g.DrawString(this.textBox.Text, this.textFont, new SolidBrush(this.textColor), new Point((int)this.fontXUpDown.Value, (int)this.fontYUpDown.Value));
            NewImageStack((Image)img.Clone());
            cancelText();
        }

        private void cancelTextBtn_Click(object sender, EventArgs e)
        {
            cancelText();
        }

        public void activateChromakeyClick()
        {
            this.imageClick = true;
        }

        public void activateColorMouseClick()
        {
            this.imageClick = true;

        }

        private void imgPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.imageClick)
            {
                Bitmap img = new Bitmap(this.imgPicBox.Image);
                Color color = img.GetPixel(e.X, e.Y);
                img.MakeTransparent(color);
                NewImageStack((Image)img.Clone());
                this.imageClick = false;
                Cursor = Cursors.Default;
            }
        }

        private void showMousePickerColor(Color color)
        {
            Image image = this.imgPicBox.Image;
            int width = image.Width;
            int height = image.Height;

            Bitmap imageBitMap = new Bitmap(image);
            int counter = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = imageBitMap.GetPixel(i, j);
                    if (color.ToArgb().Equals(pixelColor.ToArgb()))
                    {
                        counter++;
                    }
                }
            }

            MessageBox.Show("The color " + color.ToString() + " was found " + counter + " times",
                       "Color Detection",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeForm resizeForm = new ResizeForm(this);
            resizeForm.StyleManager = this.StyleManager;
            resizeForm.Show();
            resizeForm.StyleManager = appStyle;
        }

        private void fourAreaPicBox1_Click(object sender, EventArgs e)
        {
            saveImage(((PictureBox)sender).Image);
        }
        
        private void applyPatternButton_Click(object sender, EventArgs e)
        {
            Image picture = (Image)imgPicBox.Image.Clone();
            Bitmap bitmap = new Bitmap((int)rowsInput.Value * picture.Width, (int)columnsInput.Value * picture.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 0; i <= bitmap.Width - picture.Width; i += picture.Width)
            {
                for (int j = 0; j <= bitmap.Height - picture.Height; j += picture.Height)
                {
                    graphics.DrawImage(picture, new PointF(i, j));
                }
            }
            NewImageStack(bitmap);
            patternGroupBox.Visible = false;
        }

        private void cancelPatternButton_Click(object sender, EventArgs e)
        {
            patternGroupBox.Visible = false;
        }

        private void toolStripMenuItemCancelCursor_Click(object sender, EventArgs e)
        {
            this.imageClick = false;
            Cursor = Cursors.Default;
        }
        
    }
}
