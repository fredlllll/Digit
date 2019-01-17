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
    public partial class VisualElement : UserControl
    {
        /// <summary>
        /// renderer this item is part of
        /// </summary>
        public VisualElementRenderer Renderer { get; set; }
        /// <summary>
        /// the X coordinate
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// the y coordinate
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Width of the element
        /// </summary>
        public int ElementWidth { get; set; }
        /// <summary>
        /// Height of the element
        /// </summary>
        public int ElementHeight { get; set; }

        public void UpdateRenderOffsetScale()
        {
            Left = (int)((X + Renderer.RenderOffsetX) * Renderer.RenderScale);
            Top = (int)((Y + Renderer.RenderOffsetY) * Renderer.RenderScale);
            int width = (int)(ElementWidth * Renderer.RenderScale);
            int height = (int)(ElementHeight * Renderer.RenderScale);
            if(Width != width || Height != height) //only invalidate control when size is changed
            {
                Width = width;
                Height = height;
                Refresh();
            }
        }

        static Random r = new Random();

        public VisualElement()
        {
            InitializeComponent();
            X = Top;
            Y = Left;
            ElementWidth = Width;
            ElementHeight = Height;
        }

        protected void DrawBox(Graphics g)
        {
            float horizontalPadding = 3;

            Pen randPen = new Pen(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));

            //g.DrawRectangle(VisualSettings.ElementBoxLinePen, horizontalPadding, 0, ClientSize.Width - 2 * horizontalPadding - 1, ClientSize.Height - 1);
            g.DrawRectangle(randPen, horizontalPadding, 0, ClientSize.Width - 2 * horizontalPadding - 1, ClientSize.Height - 2);
        }

        public void DoOnPaint(PaintEventArgs e)
        {
            OnPaint(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBox(e.Graphics);

            e.Graphics.DrawLine(Pens.Red, -50, -50, 500, 500);
            //base.OnPaint(e);
        }
    }
}
