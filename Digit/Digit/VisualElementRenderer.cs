using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Digit
{
    public partial class VisualElementRenderer : UserControl
    {
        float renderScale = 1;
        public float RenderScale { get { return renderScale; } set { renderScale = value; ApplyRenderOffsetScale(); } }
        float renderOffsetX = 0;
        public float RenderOffsetX { get { return renderOffsetX; } set { renderOffsetX = value; ApplyRenderOffsetScale(); } }
        float renderOffsetY = 0;
        public float RenderOffsetY { get { return renderOffsetY; } set { renderOffsetY = value; ApplyRenderOffsetScale(); } }

        readonly List<VisualElement> visualElements = new List<VisualElement>();


        public VisualElementRenderer()
        {
            InitializeComponent();

            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                var ve = new VisualElement();
                ve.X = r.Next(400);
                ve.Y = r.Next(400);
                ve.ElementWidth = 150;
                ve.ElementHeight = 150;
                AddVisualElement(ve);
            }

            grid1.MouseUp += VisualElementRenderer_MouseUp;
            grid1.MouseDown += VisualElementRenderer_MouseDown;
            grid1.MouseMove += VisualElementRenderer_MouseMove;
            grid1.MouseWheel += VisualElementRenderer_MouseWheel;
            grid1.SendToBack();
            /*MouseUp += VisualElementRenderer_MouseUp;
            MouseDown += VisualElementRenderer_MouseDown;
            MouseMove += VisualElementRenderer_MouseMove;
            MouseWheel += VisualElementRenderer_MouseWheel;*/
        }

        private void VisualElementRenderer_MouseWheel(object sender, MouseEventArgs e)
        {
            float delta = Math.Abs(e.Delta) / 100f;
            float scale = RenderScale;
            if(e.Delta > 0)
            {
                scale *= delta;
            }
            else
            {
                scale /= delta;
            }
            if(scale < 0.1)
            {
                scale = 0.1f;
            }
            else if(scale > 5)
            {
                scale = 5;
            }

            //calculating offset to keep cursor where it was
            float offsetX = RenderOffsetX;
            float offsetY = RenderOffsetY;
            float pointerX = (e.X + offsetX) * RenderScale;
            float pointerY = (e.Y + offsetY) * RenderScale;

            offsetX = (pointerX / scale) - e.X;
            offsetY = (pointerY / scale) - e.Y;

            UpdateRenderOffsetScale(offsetX, offsetY, scale);
        }

        class DragData
        {
            public bool isDragging = false;
            public float offsetStartX = 0;
            public float offsetStartY = 0;
            public int StartX = 0;
            public int StartY = 0;
        }

        DragData dragData = new DragData();

        private void VisualElementRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                dragData.isDragging = true;
                dragData.offsetStartX = RenderOffsetX;
                dragData.offsetStartY = RenderOffsetY;
                dragData.StartX = e.X;
                dragData.StartY = e.Y;
            }
        }

        private void VisualElementRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && dragData.isDragging)
            {
                dragData.isDragging = false;
            }
        }

        private void VisualElementRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragData.isDragging)
            {
                int offsetX = (int)((e.X - dragData.StartX) / renderScale);
                int offsetY = (int)((e.Y - dragData.StartY) / renderScale);

                UpdateRenderOffset(dragData.offsetStartX + offsetX, dragData.offsetStartY + offsetY);
            }
        }

        public void AddVisualElement(VisualElement ve)
        {
            ve.Renderer = this;
            visualElements.Add(ve);
            Controls.Add(ve);
        }

        public void RemoveVisualElement(VisualElement ve)
        {
            ve.Renderer = null;
            visualElements.Remove(ve);
            Controls.Remove(ve);
        }

        public void UpdateRenderOffset(float x, float y)
        {
            renderOffsetX = x;
            renderOffsetY = y;

            ApplyRenderOffsetScale();
        }

        public void UpdateRenderOffsetScale(float x, float y, float scale)
        {
            renderOffsetX = x;
            renderOffsetY = y;
            renderScale = scale;

            ApplyRenderOffsetScale();
        }

        public void ApplyRenderOffsetScale()
        {
            foreach(var ve in visualElements)
            {
                ve.UpdateRenderOffsetScale();
            }
            grid1.GridOffsetX = -renderOffsetX * renderScale;
            grid1.GridOffsetY = -renderOffsetY * renderScale;
            grid1.GridSpacing = 100 * renderScale;
        }

        /*protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            RectangleF visible = new RectangleF(-renderOffsetX * renderScale, -renderOffsetY * renderScale, Width * renderScale, Height * renderScale);

            float start = (float)Math.Ceiling(visible.X / 100) * 100;
            start += renderOffsetX * renderScale;
            float offset = 100 * renderScale;
            while(start < Width)
            {
                e.Graphics.DrawLine(Pens.Black, new PointF(start, 0), new PointF(start, Height));
                start += offset;
            }


            start = (float)Math.Ceiling(visible.Y / 100) * 100;
            start += renderOffsetY * renderScale;
            while(start < Height)
            {
                e.Graphics.DrawLine(Pens.Black, new PointF(0,start), new PointF(Width,start));
                start += offset;
            }
        }*/

        /*protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.ScaleTransform(RenderScale, RenderScale);
            base.OnPaint(e);

            /*Graphics g = e.Graphics;
            using(Matrix originalTransform = g.Transform)
            {
                foreach(var ve in visualElements)
                {
                    PaintEventArgs args = new PaintEventArgs(g, new Rectangle(ve.Left, ve.Top, ve.Width, ve.Height));

                    g.Transform = originalTransform;
                    g.TranslateTransform(ve.Left, ve.Top);
                    g.Clip = new Region(new RectangleF(0, 0, ve.Width*RenderScale, ve.Height*RenderScale));
                    g.ScaleTransform(RenderScale, RenderScale);


                    ve.DoOnPaint(args);
                }
            }
        }*/
    }
}
