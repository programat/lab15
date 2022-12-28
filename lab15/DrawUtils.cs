using System;
using System.Drawing;

namespace lab15
{
    class DrawUtils
    {
        public static readonly SolidBrush brushBlack = new SolidBrush(Color.Black);
        public static readonly SolidBrush brushWhite = new SolidBrush(Color.White);
        public static readonly Pen penBlack = new Pen(Color.Black, 1);
        public static readonly Pen penRed = new Pen(Color.Red);
        public static readonly Pen penBlue = new Pen(Color.Blue);
        public static readonly Font vertexFont = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Regular);
        
        public static void DrawVertex(Graphics gfx, Node v, float x, float y)
        {
            gfx.FillEllipse(brushWhite, x - 14F, y - 14F, 28F, 28F);
            gfx.DrawEllipse(penBlack, x - 14F, y - 14F, 28F, 28F);
            string text = v.id.ToString();
            SizeF textSize = gfx.MeasureString(text, vertexFont);
            gfx.DrawString(v.id.ToString(), vertexFont, brushBlack, x - textSize.Width / 2, y - textSize.Height / 2);
        }
        
        public static void DrawLineFromTo(Graphics gfx, Pen pen, float from_x, float from_y, float to_x, float to_y, bool offset, int value)
        {
            
            float dist = GetDistance(from_x, from_y, to_x, to_y) - (offset ? 14F : 0F);
            float angle = GetAngle(from_x, from_y, to_x, to_y);
            float dx = (float)(dist * Math.Cos(angle));
            float dy = (float)(dist * Math.Sin(angle));
            gfx.DrawLine(pen, from_x, from_y, from_x + dx, from_y + dy);
            gfx.DrawString(value.ToString(), vertexFont, brushBlack, from_x + dx/2, from_y + dy/2);
        }
        
        public static void DrawLineFromTo(Graphics gfx, Pen pen, Node from, Node to, int value)
        {
            DrawLineFromTo(gfx, pen, from.x, from.y, to.x, to.y, true, value);
        }
        // Угол между 2 точками в радианах
        private static float GetAngle(float x1, float y1, float x2, float y2)
        {
            float angle = (float)Math.Atan2(y2 - y1, x2 - x1);
            return angle;
        }
        // Расстояние между 2 точками
        private static float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}