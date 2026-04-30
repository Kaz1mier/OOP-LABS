using System;
using System.Drawing;

namespace Lab2
{
    public class Ellipse : BasicFigures
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsFilled { get; set; }

        public Ellipse(int x, int y, int width, int height, Color color, bool isFilled = false, int penWidth = 2)
            : base(x, y, color, penWidth)
        {
            Width = width;
            Height = height;
            IsFilled = isFilled;
        }

        

        public override string GetInfo()
        {
            return $"Ellipse({X}, {Y}, {Width}, {Height}, Fill={IsFilled}, Color={Color.Name})";
        }
    }
}  