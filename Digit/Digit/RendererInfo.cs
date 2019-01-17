using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digit
{
    public partial class RendererInfo : UserControl
    {
        public float offsetX, offsetY, scale;
        public VisualElementRenderer renderer;

        public RendererInfo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("offsetX: " + offsetX + " offsetY: " + offsetY + " scale: " + scale, Font, Brushes.Black, new Point(0, 0));
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if(renderer != null)
            {
                offsetX = renderer.RenderOffsetX;
                offsetY = renderer.RenderOffsetY;
                scale = renderer.RenderScale;
                Refresh();
            }
        }
    }
}
