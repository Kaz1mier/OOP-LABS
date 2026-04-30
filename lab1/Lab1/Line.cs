using System;
using System.Drawing;

namespace Lab1
{
    public class Line : BasicFigures
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Line(int x1, int y1, int x2, int y2, Color color, int penWidth = 2)
            : base(x1, y1, color, penWidth)
        {
            X2 = x2;
            Y2 = y2;
        }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, PenWidth))
            {
                g.DrawLine(pen, X, Y, X2, Y2);
            }
        }

        public override string GetInfo()
        {
            return $"Line({X}, {Y}, {X2}, {Y2}, Color={Color.Name})";
        }
    }
}