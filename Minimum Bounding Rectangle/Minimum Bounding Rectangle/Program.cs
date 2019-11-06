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
            // sprawdzamy czy dane wejsciowe maja 3 elementy ["p", "3", "4" ]
            if (input.Length != 3)
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 2 element czyli "3" na 3 i zapisujemy jako x
            if (!int.TryParse(input[1], out int x))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 3 element czyli "4" na 4 i zapisujemy jako y
            if (!int.TryParse(input[2], out int y))
            {
                throw new ArgumentException();
            }

            // tworzymy Punkt(3,4)
            return new Punkt(x, y);
        }

        static Punkt[] obsluzKolo(string[] input)
        {
            // sprawdzamy czy dane wejsciowe maja 4 elementy ["p", "3", "4", "3"]

            if (input.Length != 4)
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 2 element czyli "3" na 3 i zapisujemy jako x

            if (!int.TryParse(input[1], out int x))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 3 element czyli "4" na 4 i zapisujemy jako y

            if (!int.TryParse(input[2], out int y))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 4 element czyli "3" na 3 i zapisujemy jako r czyli promien kola

            if (!int.TryParse(input[3], out int r))
            {
                throw new ArgumentException();
            }

            // Tworzymy najdalszy i najblizszy punkt obejmujacy kolo dodajac i odejmujac promien od srodka kola
            // srodek kola (3,4) 
            // najblizszy punkt (3 - 3, 4 - 3) i najdalszy punkt (3 + 3, 4 + 3)
            // [ Punkt(0, -1), Punkt(6 ,7) ]
            return new Punkt[]{
                new Punkt(x - r, y - r),
                new Punkt(x + r, y + r),
            };
        }

        static Punkt[] obsluzLinie(string[] input)
        {
            // sprawdzamy czy dane wejsciowe maja 4 elementy ["l", "3", "3", "4", "4"]

            if (input.Length != 5)
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 2 element czyli "3" na 3 i zapisujemy jako x1
            if (!int.TryParse(input[1], out int x1))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 3 element czyli "3" na 3 i zapisujemy jako y1
            if (!int.TryParse(input[2], out int y1))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 4 element czyli "4" na 4 i zapisujemy jako x2
            if (!int.TryParse(input[3], out int x2))
            {
                throw new ArgumentException();
            }

            // probujemy zamienic 5 element czyli "4" na 4 i zapisujemy jako y2
            if (!int.TryParse(input[4], out int y2))
            {
                throw new ArgumentException();
            }

            // Towrzymy punkt na koncu i poczatku lini [Punkt(3,3), Punkt(4,4)]
            return new Punkt[]{
                new Punkt(x1, y1),
                new Punkt(x2, y2),
            };
        }


        static string licz()
        {
            // czyta dane wpisane od uzytkownika
            string input = Console.ReadLine();
            // probuje zamienic tekst (string) na liczbe (int'a), jak sie uda to zapisuje liczbe do iloscElementow a jak sie nie to wchodzi w ifa i rzuca bledem.
            if (!int.TryParse(input, out int iloscElementow))
            {
                throw new ArgumentException();
            }
            var i = 0;
            var punkty = new List<Punkt>();
            while (i < iloscElementow)
            {
                // czyta od uzytkownika dane po spacji
                // np punkt w stringu 'p 3 3' jako ['p', '3', '3']
                string[] element = Console.ReadLine().Split(" ");

                // pobiera typ w przykladzie bedzie to 'p'
                var typ = element[0];
                // sprawdza co to jest za typ i przeksztalca je na punkty w zaleznosci co do za typ
                switch (typ)
                {
                    // punkt
                    case "p":
                        // zamien ['p', '3', '3'] na Punkt(3,3)
                        var p = obsluzPunkt(element);
                        // dodaj punkt do listy
                        punkty.Add(p);
                        break;
                    // kolo
                    case "c":
                        // zamien ['c', '3','3', '5'] na najdlaszy Punkt(8, 8) i najblizszy Punkt(-2,-2) obejmujacy kolo 
                        var c = obsluzKolo(element);
                        // dodaj punkty do listy
                        punkty.AddRange(c);
                        break;
                    // linia
                    case "l":
                        // zamien ['l','-3','-3','3','3'] na punkt na poczatku lini Punkt(-3,-3) i na koncu Punkt(3,3)
                        var l = obsluzLinie(element);
                        // dodaj punkty do listy
                        punkty.AddRange(l);
                        break;
                }
                i++;
            }

            // jak nie ma zadnych punktow to zwroc pusty string // to chyba nie ma szans sie zdarzyc tak wgl
            if (punkty.Count == 0)
            {
                return "";
            }

            // pobieramy pierwszy punkt z listy i ustawiamy x i y ze sa rownie najwieksze i najmniejsze zeby miec do czego porownywac
            var maxX = punkty[0].x;
            var maxY = punkty[0].y;
            var minX = punkty[0].x;
            var minY = punkty[0].y;
            
            // idziemy po nastepnych punktach
            for (var index = 1; index < punkty.Count; index++)
            {
                // jesli x jest wieksze od maksymalnego x to zastepujemy maksymalny x
                maxX = Math.Max(maxX, punkty[index].x);
                // jak y jest wieksze od maksymalengo y to zastepujemy maksymanly y
                maxY = Math.Max(maxY, punkty[index].y);
                // jak x jest mniejsze to zastepujemy najmniejszy x
                minX = Math.Min(minX, punkty[index].x);
                // jak y jest mniejsze to zastepujemy najmnieszy y
                minY = Math.Min(minY, punkty[index].y);
            }

            // wypisujemy najmniejszy i najwiekszy punkt i to beda wierzcholki prostokota
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