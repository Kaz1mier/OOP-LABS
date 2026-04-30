using System;
using System.Drawing;

namespace Lab1
{
    public class Rectangle : BasicFigures    
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsFilled { get; set; }

        public Rectangle(int x, int y, int width, int height, Color color, bool isFilled = false, int penWidth = 2)
            : base(x, y, color, penWidth)    
        {
            Width = width;
            Height = height;
            IsFilled = isFilled;
        }

        public override void Draw(Graphics g)
        {
            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(Color))
                {
                    g.FillRectangle(brush, X, Y, Width, Height);  
                }
            }
            else
            {
                using (Pen pen = new Pen(Color, PenWidth))
                {
                    g.DrawRectangle(pen, X, Y, Width, Height);    
                }
            }
        }

        public override string GetInfo()
        {
            return $"Rectangle({X}, {Y}, {Width}, {Height}, Fill={IsFilled}, Color={Color.Name})";  
        }
    }
}