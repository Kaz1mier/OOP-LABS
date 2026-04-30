using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Abstractions
{
    public interface IBinarySerializable
    {
        void Save(BinaryWriter writer);
        void Load(BinaryReader reader);
    }
}
