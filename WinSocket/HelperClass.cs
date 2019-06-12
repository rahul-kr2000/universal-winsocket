using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WinSocket
{
    public struct Tick
    {
        public string Mode
        {
            get;
            set;
        }

        public uint InstrumentToken
        {
            get;
            set;
        }

        public bool Tradable
        {
            get;
            set;
        }

        public decimal LastPrice
        {
            get;
            set;
        }

        public uint LastQuantity
        {
            get;
            set;
        }

        public decimal AveragePrice
        {
            get;
            set;
        }

        public uint Volume
        {
            get;
            set;
        }

        public uint BuyQuantity
        {
            get;
            set;
        }

        public uint SellQuantity
        {
            get;
            set;
        }

        public decimal Open
        {
            get;
            set;
        }

        public decimal High
        {
            get;
            set;
        }

        public decimal Low
        {
            get;
            set;
        }

        public decimal Close
        {
            get;
            set;
        }

        public decimal Change
        {
            get;
            set;
        }
        public DateTime? LastTradeTime
        {
            get;
            set;
        }

        public uint OI
        {
            get;
            set;
        }

        public uint OIDayHigh
        {
            get;
            set;
        }

        public uint OIDayLow
        {
            get;
            set;
        }

        public DateTime? Timestamp
        {
            get;
            set;
        }
    }


    public class Utils
    {
        public static DateTime? StringToDate(string DateString)
        {
            try
            {
                if (DateString.Length == 10)
                {
                    return DateTime.ParseExact(DateString, "yyyy-MM-dd", null);
                }
                return DateTime.ParseExact(DateString, "yyyy-MM-dd HH:mm:ss", null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MemoryStream StreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

        public static void AddIfNotNull(Dictionary<string, dynamic> Params, string Key, string Value)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                Params.Add(Key, Value);
            }
        }

        public static string SHA256(string Data)
        {
            Console.WriteLine(Data);
            SHA256Managed sHA256Managed = new SHA256Managed();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(Data), 0, Encoding.UTF8.GetByteCount(Data));
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static string BuildParam(string Key, dynamic Value)
        {
            if (Value is string)
            {
                return HttpUtility.UrlEncode(Key) + "=" + HttpUtility.UrlEncode((string)Value);
            }
            string[] source = (string[])Value;
            return string.Join("&", from x in source
                                    select HttpUtility.UrlEncode(Key) + "=" + HttpUtility.UrlEncode(x));
        }

        public static DateTime UnixToDateTime(ulong unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 5, 30, 0, 0, DateTimeKind.Unspecified).AddSeconds(unixTimeStamp);
        }
    }

}
