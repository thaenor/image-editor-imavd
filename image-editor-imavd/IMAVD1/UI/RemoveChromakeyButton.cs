using System;
using System.Windows.Forms;

namespace IMAVD1.UI
{
    public partial class RemoveChromakeyButton : ToolButton
    {
        private Form1 form;

        public RemoveChromakeyButton(Form1 form) : base()
        {
            this.Click += new EventHandler(button_Click);
            this.form = form;
            this.BackgroundImage = IMAVD1.Properties.Resources.chromakey_icon;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            setToolTip("Remove chromakey color");
        }


        private void button_Click(object sender, EventArgs e)
        {
            form.Cursor = Cursors.Cross;
            this.form.activateChromakeyClick();

        }
    }
}
