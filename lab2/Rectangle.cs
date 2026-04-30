using System;
using System.Drawing;

namespace Lab2
{
    public class Rectangle : BasicFigures    
    {
        public int Width { get; set; }
        public int Height { get; set; }
        

        public Rectangle(int x, int y, int width, int height, Color color, bool isFilled = false, int penWidth = 2)
            : base(x, y, color, penWidth)    
        {
            Width = width;
            Height = height;
          
        }

        

        public override string GetInfo()
        {
            return $"Rectangle({X}, {Y}, {Width}, {Height}, Color={Color.Name})";  
        }
    }
}