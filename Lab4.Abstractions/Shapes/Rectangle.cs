using System;

namespace Lab4.Abstractions.Shapes
{
    using System.Drawing;
    using System.IO;

    
        public class Rectangle : BasicFigures
        {
            public int Width { get; set; }
            public int Height { get; set; }

            public Rectangle() { }

            public Rectangle(int x, int y, int w, int h, Color color)
                : base(x, y, color)
            {
                Width = w;
                Height = h;
            }

            public override void Save(BinaryWriter writer)
            {
                base.Save(writer);
                writer.Write(Width);
                writer.Write(Height);
            }

            public override void Load(BinaryReader reader)
            {
                base.Load(reader);
                Width = reader.ReadInt32();
                Height = reader.ReadInt32();
            }

            public override string GetInfo()
            {
                return $"Rectangle ({X},{Y}) {Width}x{Height}";
            }
        }
    

}