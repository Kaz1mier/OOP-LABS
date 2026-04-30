using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Abstractions
{
    public interface IFilePlugin
    {
        string Name { get; }

        byte[] BeforeSave(byte[] data);

        byte[] AfterLoad(byte[] data);
    }
}
