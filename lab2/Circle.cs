using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
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

        

        public override string GetInfo()
        {
            return $"Circle(Center=({X + Radius}, {Y + Radius}), Radius={Radius}, Fill={IsFilled}, Color={Color.Name})";
        }
    }
}
