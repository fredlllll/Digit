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
    public partial class Grid : UserControl
    {
        float spacing = 100, offsetX = 0, offsetY = 0;
        Pen linePen = Pens.Black;

        public float GridSpacing { get { return spacing; } set { spacing = value; Refresh(); } }
        public float GridOffsetX { get { return offsetX; } set { offsetX = value; Refresh(); } }
        public float GridOffsetY { get { return offsetY; } set { offsetY = value; Refresh(); } }
        public Pen LinePen { get { return linePen; } set { linePen = value; Refresh(); } }

        public Grid()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            float start = (float)Math.Ceiling(offsetX / spacing) * spacing; //coordinate of first visible line
            start -= offsetX; //move to drawing space
            while(start < Width)
            {
                e.Graphics.DrawLine(linePen, new PointF(start, 0), new PointF(start, Height));
                start += spacing;
            }

            //do same for y axis
            start = (float)Math.Ceiling(offsetY / spacing) * spacing;
            start -= offsetY;
            while(start < Height)
            {
                e.Graphics.DrawLine(linePen, new PointF(0, start), new PointF(Width, start));
                start += spacing;
            }
        }
    }
}
