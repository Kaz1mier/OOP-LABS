using System.IO;
using System.Drawing;

namespace Lab3.Shapes
{
    public abstract class BasicFigures : IBinarySerializable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        protected BasicFigures() { }

        protected BasicFigures(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        // Save common properties
        public virtual void Save(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Color.ToArgb());
        }

        // Load common properties
        public virtual void Load(BinaryReader reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();
            Color = Color.FromArgb(reader.ReadInt32());
        }

        public virtual string GetInfo()
        {
            return $"{GetType().Name} ({X}, {Y})";
        }
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
