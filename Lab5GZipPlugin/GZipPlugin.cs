using Lab4.Abstractions;
using System.IO;
using System.IO.Compression;

namespace Lab5GZipPlugin
{
    public class GZipPlugin : IFilePlugin
    {
        public string Name => "GZip";

        public byte[] BeforeSave(byte[] data)
        {
            using var ms = new MemoryStream();

            using (var gz = new GZipStream(ms,
                CompressionMode.Compress))
            {
                gz.Write(data, 0, data.Length);
            }

            return ms.ToArray();
        }

        public byte[] AfterLoad(byte[] data)
        {
            using var input = new MemoryStream(data);
            using var gz = new GZipStream(input,
                CompressionMode.Decompress);

            using var output = new MemoryStream();

            gz.CopyTo(output);

            return output.ToArray();
        }
    }
}
