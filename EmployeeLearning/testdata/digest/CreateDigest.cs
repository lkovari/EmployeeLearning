using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.testdata.digest
{
    public static class CreateDigest
    {
        private static readonly MD5 md5 = MD5.Create();
        public static string GenerateDigest(string text)
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hash);
        }
    }
}
