using System;
using System.Linq;

namespace CountIPAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IpsBetween("10.0.0.0", "10.0.0.50"));
            Console.WriteLine(IpsBetween("20.0.0.10", "20.0.1.0"));
            Console.WriteLine(IpsBetween("10.11.12.13", "10.11.13.0"));
            Console.WriteLine(IpsBetween("170.0.0.0", "170.0.0.1")); // 1
            Console.WriteLine(IpsBetween("170.0.0.0", "170.0.1.0")); // 256
            Console.WriteLine(IpsBetween("170.0.0.0", "170.1.0.0")); // 65536 
            Console.WriteLine(IpsBetween("50.0.0.0 ", "50.1.1.1")); //65793 838860800 838926593
        }

        public static long IpsBetween(string start, string end)
        {
            var starts = start.Split(".");
            var ends = end.Split(".");
            var sumStart = (Int32.Parse(starts[0]) * (int)Math.Pow(2,24)) + (Int32.Parse(starts[1]) * (int)Math.Pow(2,16)) + 
            (Int32.Parse(starts[2]) * (int)Math.Pow(2,8)) + Int32.Parse(starts[3]);
            var sumEnd = (Int32.Parse(ends[0]) * (int)Math.Pow(2,24)) + (Int32.Parse(ends[1]) * (int)Math.Pow(2,16)) + 
            (Int32.Parse(ends[2]) * (int)Math.Pow(2,8)) + Int32.Parse(ends[3]);


            return sumEnd - sumStart;
        }
    }
}
