using System.IO;
using System.IO.Compression;

namespace FriendPlugin
{
    public class FriendArchiver
    {
        public string GetTitle()
        {
            return "Friend ZIP";
        }

        public byte[] Pack(byte[] data)
        {
            using var ms = new MemoryStream();

            using (var ds =
                new DeflateStream(ms, CompressionMode.Compress))
            {
                ds.Write(data, 0, data.Length);
            }

            return ms.ToArray();
        }

        public byte[] Unpack(byte[] data)
        {
            using var input = new MemoryStream(data);

            using var ds =
                new DeflateStream(input, CompressionMode.Decompress);

            using var output = new MemoryStream();

            ds.CopyTo(output);

            return output.ToArray();
        }
    }
}
