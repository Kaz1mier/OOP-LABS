using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Circle : BasicFigures
    {
        public int Radius { get; set; }
        public bool IsFilled { get; set; }

        public Circle(int x, int y, int radius, Color color, bool isFilled = false, int penWidth = 2)
            : base(x - radius, y - radius, color, penWidth)
        {
            Radius = radius;
            IsFilled = isFilled;
        }

        public override void Draw(Graphics g)
        {
            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(Color))
                {
                    g.FillEllipse(brush, X, Y, Radius * 2, Radius * 2);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color, PenWidth))
                {
                    g.DrawEllipse(pen, X, Y, Radius * 2, Radius * 2);
                }
            }
        }

        public override string GetInfo()
        {
            return $"Circle(Center=({X + Radius}, {Y + Radius}), Radius={Radius}, Fill={IsFilled}, Color={Color.Name})";
        }
    }
}
