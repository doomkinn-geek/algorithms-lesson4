using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = new string[10000];
            HashSet<string> hashArray = new HashSet<string>();
            for (int i = 0; i < 9999; i++)
            {
                string randomStr = RandomString(10);
                strArray[i] = randomStr;
                hashArray.Add(randomStr);
            }
            strArray[9999] = "stringtofind";
            hashArray.Add("stringtofind");

            Stopwatch stopWatch1 = Stopwatch.StartNew();
            foreach (var item in hashArray)
            {
                if (item.Equals("stringtofind"))
                {
                    break;
                }
            }
            stopWatch1.Stop();
            long ticks = stopWatch1.ElapsedTicks;
            Console.WriteLine("Время поиска в списке HashSet: " + ticks);

            Stopwatch stopWatch2 = Stopwatch.StartNew();
            for (int i = 0; i < 9999; i++)
            {
                if (strArray[i].Equals("stringtofind"))
                {
                    break;
                }
            }
            stopWatch2.Stop();
            ticks = stopWatch2.ElapsedTicks;
            Console.WriteLine("Время поиска в массиве: " + ticks);
        }

        static string RandomString(int size)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[size];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return "";
        }
    }
}
