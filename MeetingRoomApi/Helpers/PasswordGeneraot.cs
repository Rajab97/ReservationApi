using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Helpers
{
    public static class PasswordGeneraot
    {
        public static void HashWithCSHA512(string password , out byte[] hashedPassword , out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                hashedPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyHashedPasswordByCSHA512(string password, byte[] hashedPassword , byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hashedPassword.Length; i++)
                    if (hashedPassword[i] != computedHash[i])
                        return false;

                return true;
            }
        }
    }
}
