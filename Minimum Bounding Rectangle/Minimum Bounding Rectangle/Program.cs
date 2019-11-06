using System;
using System.Collections.Generic;

namespace MDR
{
    class Punkt
    {
        public int x;
        public int y;

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Program
    {
        static Punkt obsluzPunkt(string[] input)
        {
            if (input.Length != 3)
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[1], out int x))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[2], out int y))
            {
                throw new ArgumentException();
            }

            return new Punkt(x, y);
        }

        static Punkt[] obsluzKolo(string[] input)
        {
            if (input.Length != 4)
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[1], out int x))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[2], out int y))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[3], out int r))
            {
                throw new ArgumentException();
            }

            return new Punkt[]{
                new Punkt(x - r, y - r),
                new Punkt(x + r, y + r),
            };
        }

        static Punkt[] obsluzLinie(string[] input)
        {
            if (input.Length != 5)
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[1], out int x1))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[2], out int y1))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[3], out int x2))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[4], out int y2))
            {
                throw new ArgumentException();
            }

            return new Punkt[]{
                new Punkt(x1, y1),
                new Punkt(x2, y2),
            };
        }


        static string licz()
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int iloscElementow))
            {
                throw new ArgumentException();
            }
            var i = 0;
            var punkty = new List<Punkt>();
            while (i < iloscElementow)
            {
                string[] element = Console.ReadLine().Split(" ");
                var typ = element[0];

                switch (typ)
                {
                    case "p":
                        var p = obsluzPunkt(element);
                        punkty.Add(p);
                        break;
                    case "c":
                        var c = obsluzKolo(element);
                        punkty.AddRange(c);
                        break;
                    case "l":
                        var l = obsluzLinie(element);
                        punkty.AddRange(l);
                        break;
                }
                i++;
            }

            if (punkty.Count == 0)
            {
                return "";
            }

            var maxX = punkty[0].x;
            var maxY = punkty[0].y;
            var minX = punkty[0].x;
            var minY = punkty[0].y;

            for (var index = 1; index < punkty.Count; index++)
            {
                maxX = Math.Max(maxX, punkty[index].x);
                maxY = Math.Max(maxY, punkty[index].y);
                minX = Math.Min(minX, punkty[index].x);
                minY = Math.Min(minY, punkty[index].y);
            }

            return $"{minX} {minY} {maxX} {maxY}";
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int testCases))
            {
                throw new ArgumentException();
            }

            var wynik = "";
            var test = 0;
            while (test < testCases)
            {
                wynik += licz();
                var nastepnyTest = Console.ReadLine();
                if (nastepnyTest == "")
                {
                    if (test != testCases - 1)
                    {
                        wynik += "\n";
                    }
                    test++;
                }
            }

            Console.Write(wynik);
        }
    }
}