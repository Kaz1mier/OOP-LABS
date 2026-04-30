using FriendPlugin;
using Lab4.Abstractions;

namespace Lab6AdapterPlugin
{
    public class FriendAdapter : IFilePlugin
    {
        private FriendArchiver archiver =
            new FriendArchiver();

        public string Name =>
            archiver.GetTitle();

        public byte[] BeforeSave(byte[] data)
        {
            return archiver.Pack(data);
        }

        public byte[] AfterLoad(byte[] data)
        {
            return archiver.Unpack(data);
        }
    }
}
