using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MeetingRoomApi.DAL.EncryptionHelper
{
    using BCrypt = BCrypt.Net.BCrypt;
    public static class BCryptEncriptionExtension
    {
        public static string EncryptWithBCrypt(this string plainText)
        {
            return BCrypt.HashPassword(plainText);
        }
        public static bool DecryptTextWithBCrypt(this string hashedPassword, string plainText)
        {
            return BCrypt.Verify(plainText,hashedPassword);
        }
    }
}
