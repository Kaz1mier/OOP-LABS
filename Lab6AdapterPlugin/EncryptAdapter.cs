using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Abstractions;
using FriendPlugin;


namespace Lab6AdapterPlugin
    {
        public class EncryptAdapter : IFilePlugin
        {
            private FriendCipher cipher =
                new FriendCipher();

            public string Name =>
                cipher.Title();

            public byte[] BeforeSave(byte[] data)
            {
                return cipher.Encrypt(data);
            }

            public byte[] AfterLoad(byte[] data)
            {
                return cipher.Decrypt(data);
            }
        }
    }
