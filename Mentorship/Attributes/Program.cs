using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class HashOrderAttribute : Attribute
    {
        readonly int order;

        public HashOrderAttribute(int order)
        {
            this.order = order;
        }

        public int OrderValue
        {
            get { return order; }
        }
    }

    public class FakeHttpRequest
    {
        public string Url { get; set; } = "localhost...";

        [HashOrder(1)]
        public string UserAgent { get; set; } = "Chrome";

        [HashOrder(3)]
        public string Ip { get; set; } = "168.04.23.12";

        [HashOrder(5)]
        public string BrowserVersion { get; set; } = "1.0";

        [HashOrder(7)]
        public string Connection { get; set; } = "Keep-alive";

        [HashOrder(2)]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [HashOrder(4)]
        public string ContentEncoding { get; set; } = "gzip";

        [HashOrder(6)]
        public string ContentType { get; set; } = "text/plain; charset=utf-8";

        [HashOrder(8)]
        public int ContentLength { get; set; } = 678;

        public Dictionary<string, int> GetOrder()
        {
            Dictionary<string, int> _dict = new Dictionary<string, int>();

            PropertyInfo[] props = typeof(FakeHttpRequest).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    HashOrderAttribute orderAttr = attr as HashOrderAttribute;
                    if (orderAttr != null)
                    {
                        var propValue = prop.GetValue(this);
                        int order = orderAttr.OrderValue;

                        _dict.Add(propValue.ToString(), order);
                    }
                }
            }

            return _dict;
        }

        public string GetHash()
        {
            var orderDict = GetOrder();
            var sorted = orderDict.OrderBy(i => i.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var item in sorted)
            {
                sb.Append(item.Key);
            }

            Console.WriteLine(sb);
            return sb.ToString();
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            FakeHttpRequest a = new FakeHttpRequest();
            var q = a.GetOrder();
            foreach (var item in q)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            a.GetHash();

            string source = a.GetHash();
            
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                Console.WriteLine("Verifying the hash...");
                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
    
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
 
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
