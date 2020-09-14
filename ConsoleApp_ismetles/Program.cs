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
        const int MIN = 1, MAX = 45, TIPPEKSZAMA = 5;
        static int[] sorsoltSzamok = new int[TIPPEKSZAMA];
        static int[] tippeltSzamok = new int[TIPPEKSZAMA];
        static List<int> talalatok = new List<int>();
        static void Main(string[] args)
        {
            Random r = new Random();
            //-- Sorsol ---------------
            for (int i = 0; i < TIPPEKSZAMA; i++)
            {
                int uj;
                do
                {
                    uj = r.Next(MIN, MAX + 1);
                } while (sorsoltSzamok.Contains(uj));
                sorsoltSzamok[i] = uj;
            }

            //-- Sorsolt számok sorba rendezése -------------------
            Array.Sort(sorsoltSzamok);

            //-- Bekér --------------
            for (int i = 0; i < TIPPEKSZAMA; i++)
            {
                tippeltSzamok[i] = szamotBeker(MIN, MAX + 1);
            }
            //-- Összehasonlít -------------
            for (int i = 0; i < tippeltSzamok.Length; i++)
            {
                if (sorsoltSzamok.Contains(tippeltSzamok[i])) talalatok.Add(tippeltSzamok[i]);
            }
            //-- eredményt kiir
            Console.WriteLine($"\nA sorsolt számok: {String.Join(", ", sorsoltSzamok)}");
            Console.WriteLine($"\nA tippjeid: {String.Join(", ", tippeltSzamok)}");
            if (talalatok.Count>0)
            {
                Console.WriteLine($"\nAz eltalált számok: {String.Join(", ", talalatok)}");
            }
            else
            {
                Console.WriteLine("\nSajnos most nem nyertél!\nMajd legközelebb!");
            }

            //-- vége ---------------
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static int szamotBeker(int tol, int ig)
        {
            int szam;
            Console.Write($"Kérek egy számot {tol} és {ig} között: ");
            while (!(int.TryParse(Console.ReadLine(), out szam) && szam <= ig && szam >= tol) || tippeltSzamok.Contains(szam))
            {
                Console.WriteLine($"Ne szórakozz! Adj egy számot {tol} és {ig} között: ");
            }
            return szam;
        }
    }
}
