using System.Text;
using System.Security.Cryptography;
using System;
using Microsoft.Data.SqlClient;
using netCoreApi.Helpers;

namespace netCoreApi.Utils
{
    public static class Functions
    {
        private static Random random = new Random();
        public static string SHA256Hash(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));

                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in bHash)
                {
                    sbHash.Append(b.ToString("x2"));
                }

                return sbHash.ToString();
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string EncodePassWord(string passWord, string randomCode)
        {
            return SHA256Hash(randomCode + passWord + randomCode + randomCode);
        }
        public static List<SqlParameter> DicToParam(Dictionary<string, string> param)
        {
            var p = new List<SqlParameter>();
            foreach (var item in param)
            {
                p.Add(new SqlParameter("@" + item.Key, item.Value));

            }
            return p;
        }
        public static ValidMessage CheckFileUpload(IFormFile file, string[] supportedTypes)
        {

            string extension = Path.GetExtension(file.FileName).Substring(1).ToLower();

            if (!supportedTypes.Contains(extension))
            {
                return new ValidMessage() { Valid = false, Message = "Tệp " + file.FileName + " không đúng định dạng \n" };
            }
            if (file.Length == 0)
            {
                return new ValidMessage() { Valid = false, Message = "Tệp " + file.FileName + " bị rỗng \n" };
            }
            if (file.Length > 10485760) // 10mb
            {
                return new ValidMessage() { Valid = false, Message = "Kích thước tệp " + file.FileName + " quá lớn, vui lòng chọn tệp có kích thước <= 10Mb (10,240 Kb) \n" };
            }
            if (file.ContentType.ToLower() == "text/plain")
            {
                return new ValidMessage() { Valid = false, Message = "Tệp " + file.FileName + "không đúng định dạng \n" };
            }

            return new ValidMessage() { Valid = true, Message = "" }; ;
        }
    }
}
