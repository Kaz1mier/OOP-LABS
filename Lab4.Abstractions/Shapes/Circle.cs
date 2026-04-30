using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Abstractions.Shapes
{
    using System.Drawing;
    using System.IO;

  
        public class Circle : BasicFigures
        {
            public int Radius { get; set; }

            public Circle() { }

            public Circle(int x, int y, int r, Color color)
                : base(x, y, color)
            {
                Radius = r;
            }

            public override void Save(BinaryWriter writer)
            {
                base.Save(writer);
                writer.Write(Radius);
            }

            public override void Load(BinaryReader reader)
            {
                base.Load(reader);
                Radius = reader.ReadInt32();
            }

            public override string GetInfo()
            {
                return $"Circle ({X},{Y}) R={Radius}";
            }
        }
    }



