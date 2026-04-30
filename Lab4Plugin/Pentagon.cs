using Lab4.Abstractions;
using Lab4.Abstractions.Shapes;
using System.Drawing;
using System.IO;

namespace Lab4Plugin
{
    public class Pentagon : BasicFigures
    {
        public int Size { get; set; }

        public Pentagon() { }

        public Pentagon(int x, int y, int size, Color color)
            : base(x, y, color)
        {
            Size = size;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write(Size);
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Size = reader.ReadInt32();
        }

        public override string GetInfo()
        {
            return $"Pentagon ({X},{Y}) size={Size}";
        }
    }
}
