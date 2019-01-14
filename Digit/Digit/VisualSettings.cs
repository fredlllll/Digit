using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digit
{
    public static class VisualSettings
    {
        static Color elementBoxLineColor = Color.Black;
        public static Color ElementBoxLineColor { get { return elementBoxLineColor; } private set { elementBoxLineColor = value; elementBoxLinePen.Invalidate(); } }
        public static float ElementBoxLineWidth { get; private set; } = 1;

        static CachedObject<Pen> elementBoxLinePen = new CachedObject<Pen>(() => { return new Pen(ElementBoxLineColor, ElementBoxLineWidth); });
        public static Pen ElementBoxLinePen
        {
            get
            {
                return elementBoxLinePen;
            }
        }
    }
}
