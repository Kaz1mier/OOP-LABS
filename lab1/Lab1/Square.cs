using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Square : BasicFigures
    {
        public int Side { get; set; }
        public bool IsFilled { get; set; }

        public Square(int x, int y, int side, Color color, bool isFilled = false, int penWidth = 2)
            : base(x, y, color, penWidth)
        {
            Side = side;
            IsFilled = isFilled;
        }

        public override void Draw(Graphics g)
        {
            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(Color))
                {
                    g.FillRectangle(brush, X, Y, Side, Side);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color, PenWidth))
                {
                    g.DrawRectangle(pen, X, Y, Side, Side);
                }
            }
        }

        public override string GetInfo()
        {
            return $"Square({X}, {Y}, {Side}, Fill={IsFilled}, Color={Color.Name})";
        }
    }
}
