using System;
using System.Windows.Forms;

namespace IMAVD1.UI
{
    public partial class AddGraphicsButton : ToolButton
    {

        private Form1 form;

        public AddGraphicsButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.insert;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Add other image");
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.form.valuePickerPanel.Visible = false;
            this.form.textGroupBox.Visible = false;
            this.form.fourAreasGoupBox.Visible = false;
            this.form.twoAreasGroupBox.Visible = false;
            this.form.patternGroupBox.Visible = false;
            this.form.diagonalCropGroupBox.Visible = false;
            this.form.graphicsGroupBox.Visible = true;
        }
        
    }
}
