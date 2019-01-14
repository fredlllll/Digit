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
                ve.Location = new Point(r.Next(400), r.Next(400));
                AddVisualElement(ve);
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

        public void ApplyRenderOffsetScale()
        {
            foreach(var ve in visualElements)
            {
                ve.UpdateRenderOffsetScale();
            }
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButtons.Left)
            {
                dragData.isDragging = true;
                dragData.offsetStartX = RenderOffsetX;
                dragData.offsetStartY = RenderOffsetY;
                dragData.StartX = e.X;
                dragData.StartY = e.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && dragData.isDragging)
            {
                dragData.isDragging = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(dragData.isDragging)
            {
                int offsetX = e.X - dragData.StartX;
                int offsetY = e.Y - dragData.StartY;

                UpdateRenderOffset(dragData.offsetStartX + offsetX, dragData.offsetStartY + offsetY);
            }
        }



        protected override void OnPaint(PaintEventArgs e)
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
            }*/
        }
    }
}
