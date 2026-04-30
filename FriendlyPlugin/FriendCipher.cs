namespace FriendPlugin
{
    public class FriendCipher
    {
        private byte key = 123;

        public string Title()
        {
            return "Friend Encrypt";
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
                result[i] = (byte)(data[i] ^ key);

            return result;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
                result[i] = (byte)(data[i] ^ key);

            return result;
        }
    }
}
