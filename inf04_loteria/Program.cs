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

        /**************************************************
        nazwa funkcji: WczytajLiczbeZestawow
        opis funkcji:  Wczytuje z klawiatury liczbę zestawów do wylosowania.
        parametry:     brak
        zwracany typ i opis:
            int - liczba zestawów do wylosowania
        **************************************************/
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

        /**************************************************
        nazwa funkcji: GenerujZestawy
        opis funkcji:  Generuje podaną liczbę zestawów losowych.
        parametry:
            n   - liczba zestawów do wygenerowania
            rnd - randomowe liczby
        zwracany typ i opis:
            List<List<int>> - lista wygenerowanych zestawów
        **************************************************/
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

        /**************************************************
        nazwa funkcji: WypiszZestawy
        opis funkcji:  Wypisuje na ekran wszystkie wygenerowane zestawy
        parametry:
            List<List<int>> zestawy - lista wygenerowanych zestawów
        zwracany typ i opis:
            void - funkcja wypisuje dane
        **************************************************/
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

        /**************************************************
        nazwa funkcji: ZliczIWypisz
        opis funkcji:  Zlicza, ile razy w sumie pojawiła się każda liczba
                       z zakresu
        parametry:
            List<List<int>> zestawy - lista wygenerowanych zestawów
        zwracany typ i opis:
            void - funkcja wypisuje liczność wystąpień
        **************************************************/
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
