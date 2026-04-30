using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    public class Triangle : BasicFigures

    {
        public Point[] Points { get; set; }
        public bool IsFilled { get; set; }

        public Triangle(Point p1, Point p2, Point p3, Color color, bool isFilled = false, int penWidth = 2)
            : base(p1.X, p1.Y, color, penWidth)
        {
            Points = new Point[] { p1, p2, p3 };
            IsFilled = isFilled;
        }

        public override void Draw(Graphics g)
        {
            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(Color))
                {
                    g.FillPolygon(brush, Points);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color, PenWidth))
                {
                    g.DrawPolygon(pen, Points);
                }
            }
        }

        public override string GetInfo()
        {
            return $"Triangle({Points[0]}, {Points[1]}, {Points[2]}, Fill={IsFilled}, Color={Color.Name})";
        }
    }
}
