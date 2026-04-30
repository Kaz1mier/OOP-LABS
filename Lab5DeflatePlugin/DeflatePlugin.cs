using Lab4.Abstractions;
using System.IO;
using System.IO.Compression;

namespace Lab5DeflatePlugin
{
    public class DeflatePlugin : IFilePlugin
    {
        public string Name => "Deflate";

        public byte[] BeforeSave(byte[] data)
        {
            using var ms = new MemoryStream();

            using (var ds = new DeflateStream(ms,
                CompressionMode.Compress))
            {
                ds.Write(data, 0, data.Length);
            }

            return ms.ToArray();
        }

        public byte[] AfterLoad(byte[] data)
        {
            using var input = new MemoryStream(data);
            using var ds = new DeflateStream(input,
                CompressionMode.Decompress);

            using var output = new MemoryStream();

            ds.CopyTo(output);

            return output.ToArray();
        }
    }
}
