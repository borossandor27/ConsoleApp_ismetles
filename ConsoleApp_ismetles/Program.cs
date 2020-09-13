using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ismetles
{
    class Program
    {
        /**
         * A program öt KÜLÖNBÖZŐ számot véletlenszerúen előállít 1 és 45 között.
         * Bekér a felhasználótól öt számot és kiírja az egyezések számát.
         */
        static int[] gondoltSzamok = new int[5];
        static int[] tippeltSzamok = new int[5];
        static void Main(string[] args)
        {
            Random r = new Random();
            //-- Sorsol
            for (int i = 0; i < 5; i++)
            {
                int uj;
                do
                {
                    uj = r.Next(1, 46);
                } while (gondoltSzamok.Length > 0 && Array.Exists(gondoltSzamok, elem => elem == uj));
                gondoltSzamok[i] = uj;
            }

            //-- Bekér
            for (int i = 0; i < 5; i++)
            {
                tippeltSzamok[i] = szamotBeker(1, 45);
                Console.WriteLine(tippeltSzamok[i]);
            }
            //-- Összehasonlít
            //-- eredményt kiir
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static int szamotBeker(int tol, int ig)
        {
            int szam;
            Console.Write($"Kérek egy számot {tol} és {ig} között: ");
            while (!(int.TryParse(Console.ReadLine(), out szam) && szam <= ig && szam >= tol && !(tippeltSzamok.Length > 0 && Array.Exists(tippeltSzamok, elem => elem == szam)))) 
            {
                Console.WriteLine($"Ne szórakozz! Adj egy számot {tol} és {ig} között: ");
            }
            return szam;
        }
    }
}
