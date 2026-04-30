using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab3.Shapes
{
    using System.Drawing;
    using System.IO;

    
       public class Triangle : BasicFigures
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }

        // Computed property (не хранится, а вычисляется)
        public Point[] Points => new Point[] { P1, P2, P3 };

        public Triangle() { }

        public Triangle(Point p1, Point p2, Point p3, Color color)
            : base(0, 0, color)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);

            writer.Write(P1.X); writer.Write(P1.Y);
            writer.Write(P2.X); writer.Write(P2.Y);
            writer.Write(P3.X); writer.Write(P3.Y);
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);

            P1 = new Point(reader.ReadInt32(), reader.ReadInt32());
            P2 = new Point(reader.ReadInt32(), reader.ReadInt32());
            P3 = new Point(reader.ReadInt32(), reader.ReadInt32());
        }

        public override string GetInfo()
        {
            return $"Triangle ({P1}) ({P2}) ({P3})";
        }
    }
}


