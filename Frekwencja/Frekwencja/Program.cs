using System;
using System.Collections.Generic;
using System.Linq;
namespace console1
{
    class Program
    {
        static void Main(string[] args)
        {
            var chars = Console.ReadLine().ToCharArray();
            var count = new Dictionary<char, int>();

            foreach (var c in chars)
            {
                if (!count.ContainsKey(c))
                {
                    count.Add(c, 1);
                }
                else
                {
                    count[c]++;
                }
            }

            Console.WriteLine(count);

            Console.WriteLine("a)");
            foreach (var entry in count.OrderBy(c => c.Key))
            {
                Console.WriteLine(entry.Key);
            }

            Console.WriteLine("----------------");

            Console.WriteLine("b)");
            foreach (var entry in count.OrderByDescending(c => c.Value))
            {
                Console.WriteLine(entry.Key);
            }
        }
    }
}