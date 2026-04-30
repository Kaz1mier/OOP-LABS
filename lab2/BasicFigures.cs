using System;
using System.Drawing;

namespace Lab2
{
    public abstract class BasicFigures
    {
        public int X { get; set; }      
        public int Y { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }

        
        protected BasicFigures(int x, int y, Color color, int penWidth = 2)
        {
            X = x;                        
            Y = y;
            Color = color;
            PenWidth = penWidth;
        }


        public virtual string GetInfo()
        {
            return $"{GetType().Name}(X={X}, Y={Y}, Color={Color.Name})";
        }
    }
}