using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Abstractions.Shapes
{
    using System.Drawing;
    using System.IO;

   
    
        public class Square : BasicFigures
        {
            public int Side { get; set; }

            public Square() { }

            public Square(int x, int y, int side, Color color)
                : base(x, y, color)
            {
                Side = side;
            }

            public override void Save(BinaryWriter writer)
            {
                base.Save(writer);
                writer.Write(Side);
            }

            public override void Load(BinaryReader reader)
            {
                base.Load(reader);
                Side = reader.ReadInt32();
            }

            public override string GetInfo()
            {
                return $"Square ({X},{Y}) side={Side}";
            }
        }
    

}
