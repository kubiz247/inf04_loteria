using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf04_loteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = WczytajLiczbeZestawow();
            if(n == 0)
            {
                Console.WriteLine("Brak losowan - koniec programu");
                return;
            }

            var rnd = new Random();
            var zestawy = GenerujZestawy(n, rnd);

            Console.WriteLine();
            WypiszZestawy(zestawy);
            Console.WriteLine();
            ZliczIWypisz(zestawy);
        }

        static int WczytajLiczbeZestawow()
        {
            while(true)
            {
                Console.WriteLine("Ile zestawow wylosowac? ");
                string line = Console.ReadLine();
                if(int.TryParse(line, out int value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Niepoprawna liczba - podaj liczbe calkowita nieujemna");
            }
        }

        static List<List<int>> GenerujZestawy(int n, Random rnd)
        {
            var wynik = new List<List<int>>();
            for(int i = 0; i < n; i++)
            {
                var zestaw = new List<int>();
                while(zestaw.Count < 6)
                {
                    zestaw.Add(rnd.Next(1, 50));
                }
                var lista = zestaw.ToList();
                lista.Sort();
                wynik.Add(lista);
            }
            return wynik;
        }

        static void WypiszZestawy(List<List<int>> zestawy)
        {
            for(int i = 0; i < zestawy.Count; i++)
            { 
                var s = zestawy[i];
                Console.WriteLine($"Zestaw {i + 1,2}:");
                foreach (var num in s)
                    Console.Write($" {num,2}");
                Console.WriteLine();
            }
        }

        static void ZliczIWypisz(List<List<int>> zestawy)
        {
            int[] wystapienia = new int[50];

            foreach (var s in zestawy)
                foreach (var num in s)
                    wystapienia[num]++;

            Console.WriteLine("Wystapienia liczb 1-49: ");
            for(int num = 1; num <= 49; num++)
            {
                Console.WriteLine($"{num,2}: {wystapienia[num]}");
            }
        }
    }
}
