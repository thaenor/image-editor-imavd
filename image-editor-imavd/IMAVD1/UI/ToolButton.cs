using System.Drawing;
using System.Windows.Forms;

namespace IMAVD1
{
    public class ToolButton : Button
    {
        public readonly Font FONT = new Font("Helvetica", 10);

        public ToolButton() : base()
        {
            this.Dock = DockStyle.Fill;
            this.Font = FONT;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

        }

        public virtual void applyImageValue(float value) { }

        public void setToolTip(string tooltip)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this, tooltip);
        }
    }
}
