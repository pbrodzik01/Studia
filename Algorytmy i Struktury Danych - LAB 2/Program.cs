using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Algorytmy_i_Struktury_Danych___LAB_2
{
    internal class Program
    {
        public static void Show(int n)
        {
            Stack<int> q, w, e;
            q = new Stack<int>(new Stack<int>(A));
            w = new Stack<int>(new Stack<int>(B));
            e = new Stack<int>(new Stack<int>(C));
            Console.WriteLine(Krążki(n, q, w, e));
        }
        public static string Krążki(int n, Stack<int> A, Stack<int> B, Stack<int> C)
        {
            string l = "";
            int r;
            for (int st = 0; st < n; st++)
            {
                r = n - A.Count;
                if (st != r) l += Gwiazdki(0, n);
                else l += Gwiazdki(A.Pop(), n);
                r = n - B.Count;
                if (st != r) l += Gwiazdki(0, n);
                else l += Gwiazdki(B.Pop(), n);
                r = n - C.Count;
                if (st != r) l += Gwiazdki(0, n);
                else l += Gwiazdki(C.Pop(), n);
                l += "\n";
            }            
            return l;
        }
        public static string Gwiazdki(int il, int n)
        {
            string s = "";          
            for(int j = 0; j < 0.5 * (n * 2 - il *2 ); j++) s += " ";
            for(int j = 0; j < il*2; j++) s += "*";
            for(int j = 0; j < 0.5 * (n * 2 - il * 2); j++) s += " ";
            return s;
        }
        static void HANOI(int n, int on, Stack<int> A, Stack<int> B, Stack<int> C)
        {        
            if (n > 0)
            {                
                HANOI(n - 1, on, A, C, B); //Przenosimy rekurencyjnie n – 1 krążków ze słupka A na słupek B posługując się słupkiem C
                C.Push(A.Pop()); //Przenosimy jeden krążek za słupka A na słupek C
                Show(on);
                HANOI(n - 1,on, B, A, C); //Przenosimy rekurencyjnie n -1 krążków ze słupka B na słupek C posługując się słupkiem A
            }
        }
        static Stack<int> A = new Stack<int>();
        static Stack<int> B = new Stack<int>();
        static Stack<int> C = new Stack<int>();
        static void Main(string[] args)
        {            
            Console.Write("\tTOWER OF HANOI\nProszę podać ilość krążków: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for(int i = n; i > 0; i--) A.Push(i);
            Show(n);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HANOI(n, n, A, B, C);
            stopwatch.Stop();
            Console.WriteLine($"Czas ułożenia {n} elementowej wieży Hanoi:   {stopwatch.Elapsed}");
        }
    }
}
