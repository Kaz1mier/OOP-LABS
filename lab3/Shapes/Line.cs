using System;
using System.Drawing;

namespace Lab3.Shapes
{
    using System.Drawing;
    using System.IO;


        public class Line : BasicFigures
        {
            public int X2 { get; set; }
            public int Y2 { get; set; }

            public Line() { }

            public Line(int x1, int y1, int x2, int y2, Color color)
                : base(x1, y1, color)
            {
                X2 = x2;
                Y2 = y2;
            }

            public override void Save(BinaryWriter writer)
            {
                base.Save(writer);
                writer.Write(X2);
                writer.Write(Y2);
            }

            public override void Load(BinaryReader reader)
            {
                base.Load(reader);
                X2 = reader.ReadInt32();
                Y2 = reader.ReadInt32();
            }

            public override string GetInfo()
            {
                return $"Line ({X},{Y}) -> ({X2},{Y2})";
            }
        }
}