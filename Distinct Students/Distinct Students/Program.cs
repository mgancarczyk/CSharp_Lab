using System;
using System.Collections.Generic;

namespace StudentList
{
    class Program
    {
        static void Main(string[] args)
        {
            var studenci = new SortedSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                studenci.Add(input);
            }

            Console.WriteLine(studenci.Count);
            int index = 0;
            foreach (string student in studenci)
            {
                Console.WriteLine($"{++index}. {student}");
            }
        }
    }
}
