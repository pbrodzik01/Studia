using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Algorytmy_i_Struktury_Danych___LAB_1
{
    internal class Program
    {
        //Sortowanie Bąbelkowe
        static int[] BubbleSort_TAB(int[] tab)
        {
            int temp = tab[0];

            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        temp = tab[j + 1];
                        tab[j + 1] = tab[j];
                        tab[j] = temp;
                    }

                }
            }
            return tab;
        }
        static List<int> BubbleSort_List(List<int> list)
        {
            int temp = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }

        static int[] QuickSort_TAB(int[] tab, int left, int right)
        {
            int l = left, r = right;
            int pivot = tab[(left + right) / 2];

            while (l <= r)
            {
                while (tab[l] < pivot) l++;
                while (tab[r] > pivot) r--;

                if (l <= r)
                {
                    var tmp = tab[l];
                    tab[l++] = tab[r];
                    tab[r--] = tmp;
                }
            };

            if (left < r) QuickSort_TAB(tab, left, r);
            if (l < right) QuickSort_TAB(tab, l, right);

            return tab;
        }
        static List<int> QuickSort_List(List<int> list, int left, int right)
        {
            int l = left, r = right;
            int pivot = list[(left + right) / 2];

            while (l <= r)
            {
                while (list[l] < pivot) l++;
                while (list[r] > pivot) r--;

                if (l <= r)
                {
                    var tmp = list[l];
                    list[l++] = list[r];
                    list[r--] = tmp;
                }
            };


            if (left < r) QuickSort_List(list, left, r);
            if (l < right) QuickSort_List(list, l, right);

            return list;
        }

        //Sortowanie Przez Scalanie

        static int[] tab_pom;        
        static int[] MergeSort_TAB(int[] tab, int from, int to)
        {
            if (to <= from)
                return tab;
            int sr = (to + from) / 2;

            MergeSort_TAB(tab, from, sr);
            MergeSort_TAB(tab, sr + 1, to);
            Scal_TAB(tab, from, sr, to);
            return tab;
        }
        static void Scal_TAB(int[] tab, int from, int sr, int to)
        {
            for (int p = from; p <= to; p++) tab_pom[p] = tab[p];
            int i = from, j = sr + 1;

            for (int k = from; k <= to; k++)
            {
                if (i <= sr)
                {
                    if (j <= to)
                    {
                        tab[k] = (tab_pom[j] < tab_pom[i]) ? tab_pom[j++] : tab_pom[i++];
                    }
                    else
                    {
                        tab[k] = tab_pom[i++];
                    }
                }
                else
                {
                    tab[k] = tab_pom[j++];
                }
            }
        }

        static List<int> list_pom = new List<int>();
        static List<int> MergeSort_List(List<int> list, int from, int to)
        {
            if (to <= from) return list;
            int sr = (to + from) / 2;

            MergeSort_List(list, from, sr);
            MergeSort_List(list, sr + 1, to);
            Scal_List(list, from, sr, to);
            return list;
        }
        static void Scal_List(List<int> list, int from, int sr, int to)
        {            
            for (int p = from; p <= to; p++) list_pom.Insert(p, list[p]);

            int i = from, j = sr + 1;

            for (int k = from; k <= to; k++)
            {
                if (i <= sr)
                {
                    if (j <= to)
                    {
                        list.RemoveAt(k);
                        list.Insert(k, (list_pom[j] < list_pom[i]) ? list_pom[j++] : list_pom[i++]);
                    }
                    else
                    {
                        list.RemoveAt(k);
                        list.Insert(k, list_pom[i++]);
                    }
                }
                else
                {
                    list.RemoveAt(k);
                    list.Insert(k, list_pom[j++]);
                }
            }
        }

        static void Nierosnąco(int n, StreamWriter SW)
        {
            SW.WriteLine
                (
                "************************************\n" +
                "*  Sortowanie Danych Nierosnących  *\n" +
                "************************************\n"                
                );
            StreamReader SR = new StreamReader("../../../Nierosnąco.txt");
            Stopwatch stopwatch = new Stopwatch();
            string line;

            int[] tab_bubble = new int[n];
            List<int> list_bubble = new List<int>();

            int[] tab_quick = new int[n];
            List<int> list_quick = new List<int>();

            int[] tab_merge = new int[n];
            List<int> list_merge = new List<int>();

            for (int i = 0; i < n; i++)
            {
                line = SR.ReadLine();

                tab_bubble[i] = int.Parse(line);
                list_bubble.Add(int.Parse(line));

                tab_quick[i] = int.Parse(line);
                list_quick.Add(int.Parse(line));

                tab_merge[i] = int.Parse(line);
                list_merge.Add(int.Parse(line));
            }
            SR.Close();

            #region Tablice
            Console.WriteLine("Tablica przed sortowaniem: ");
            SW.WriteLine($"***Tablica***\n");
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort: ");
            stopwatch.Start();
            BubbleSort_TAB(tab_bubble);
            stopwatch.Stop();
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort: ");
            stopwatch.Start();
            QuickSort_TAB(tab_quick, 0, tab_quick.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_quick.Length; i++)
            {
                Console.Write(tab_quick[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort: ");
            tab_pom = new int[n];
            stopwatch.Start();
            MergeSort_TAB(tab_merge, 0, tab_merge.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_merge.Length; i++)
            {
                Console.Write(tab_merge[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Listy
            Console.WriteLine("Lista przed sortowaniem: ");
            SW.WriteLine($"\n***Lista***\n");
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort:");
            stopwatch.Start();
            BubbleSort_List(list_bubble);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort:");
            stopwatch.Start();
            QuickSort_List(list_quick, 0, list_quick.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort:");
            stopwatch.Start();
            MergeSort_List(list_merge, 0, list_merge.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_merge)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion
        }

        static void Niemalejąco(int n, StreamWriter SW)
        {
            SW.WriteLine
                ("\n\n\n" +
                "*************************************\n" +
                "*  Sortowanie Danych Niemalejących  *\n" +
                "*************************************\n"
                );
            StreamReader SR = new StreamReader("../../../Niemalejąco.txt");
            Stopwatch stopwatch = new Stopwatch();
            string line;

            int[] tab_bubble = new int[n];
            List<int> list_bubble = new List<int>();

            int[] tab_quick = new int[n];
            List<int> list_quick = new List<int>();

            int[] tab_merge = new int[n];
            List<int> list_merge = new List<int>();

            for (int i = 0; i < n; i++)
            {
                line = SR.ReadLine();

                tab_bubble[i] = int.Parse(line);
                list_bubble.Add(int.Parse(line));

                tab_quick[i] = int.Parse(line);
                list_quick.Add(int.Parse(line));

                tab_merge[i] = int.Parse(line);
                list_merge.Add(int.Parse(line));
            }
            SR.Close();

            #region Tablice
            Console.WriteLine("Tablica przed sortowaniem: ");
            SW.WriteLine($"***Tablica***\n");
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort: ");
            stopwatch.Start();
            BubbleSort_TAB(tab_bubble);
            stopwatch.Stop();
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort: ");
            stopwatch.Start();
            QuickSort_TAB(tab_quick, 0, tab_quick.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_quick.Length; i++)
            {
                Console.Write(tab_quick[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort: ");
            tab_pom = new int[n];
            stopwatch.Start();
            MergeSort_TAB(tab_merge, 0, tab_merge.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_merge.Length; i++)
            {
                Console.Write(tab_merge[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Listy
            Console.WriteLine("Lista przed sortowaniem: ");
            SW.WriteLine($"\n***Lista***\n");
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort:");
            stopwatch.Start();
            BubbleSort_List(list_bubble);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort:");
            stopwatch.Start();
            QuickSort_List(list_quick, 0, list_quick.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort:");
            stopwatch.Start();
            MergeSort_List(list_merge, 0, list_merge.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_merge)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion
        }

        static void Losowo(int n, StreamWriter SW)
        {
            SW.WriteLine
                ("\n\n\n" +
                "********************************\n" +
                "*  Sortowanie Danych Losowych  *\n" +
                "********************************\n"
                );
            StreamReader SR = new StreamReader("../../../Losowo.txt");
            Stopwatch stopwatch = new Stopwatch();
            string line;

            int[] tab_bubble = new int[n];
            List<int> list_bubble = new List<int>();

            int[] tab_quick = new int[n];
            List<int> list_quick = new List<int>();

            int[] tab_merge = new int[n];
            List<int> list_merge = new List<int>();

            for (int i = 0; i < n; i++)
            {
                line = SR.ReadLine();

                tab_bubble[i] = int.Parse(line);
                list_bubble.Add(int.Parse(line));

                tab_quick[i] = int.Parse(line);
                list_quick.Add(int.Parse(line));

                tab_merge[i] = int.Parse(line);
                list_merge.Add(int.Parse(line));
            }
            SR.Close();

            #region Tablice
            Console.WriteLine("Tablica przed sortowaniem: ");
            SW.WriteLine($"***Tablica***\n");
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort: ");
            stopwatch.Start();
            BubbleSort_TAB(tab_bubble);
            stopwatch.Stop();
            for (int i = 0; i < tab_bubble.Length; i++)
            {
                Console.Write(tab_bubble[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort: ");
            stopwatch.Start();
            QuickSort_TAB(tab_quick, 0, tab_quick.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_quick.Length; i++)
            {
                Console.Write(tab_quick[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort: ");
            tab_pom = new int[n];
            stopwatch.Start();
            MergeSort_TAB(tab_merge, 0, tab_merge.Length - 1);
            stopwatch.Stop();
            for (int i = 0; i < tab_merge.Length; i++)
            {
                Console.Write(tab_merge[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Listy
            Console.WriteLine("Lista przed sortowaniem: ");
            SW.WriteLine($"\n***Lista***\n");
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("BubbleSort:");
            stopwatch.Start();
            BubbleSort_List(list_bubble);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"BubbleSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("QuickSort:");
            stopwatch.Start();
            QuickSort_List(list_quick, 0, list_quick.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_bubble)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"QuickSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MergeSort:");
            stopwatch.Start();
            MergeSort_List(list_merge, 0, list_merge.Count - 1);
            stopwatch.Stop();
            foreach (var item in list_merge)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Czas wykonywania: " + stopwatch.Elapsed);
            SW.WriteLine($"MergeSort:\nCzas wykonywania: { stopwatch.Elapsed} \n");
            stopwatch.Reset();
            Console.WriteLine();
            Console.WriteLine();
            #endregion
        }

        static void Main(string[] args)
        {
            Random rand = new Random();           
            StreamWriter SW;           

            Console.Write("Proszę podać wielkość kolekcji: ");
            int n = int.Parse(Console.ReadLine());

            //dane posortowane nierosnąco
            SW = new StreamWriter("../../../Nierosnąco.txt");
            for (int i = n; i > 0; i--)
            {
                SW.WriteLine(rand.Next(i, i + 25));
            }
            SW.Close();

            //dane posortowan niemalejąco
            SW = new StreamWriter("../../../Niemalejąco.txt");
            for (int i = 0; i < n; i++)
            {
                SW.WriteLine(rand.Next(i, i + 25));
            }
            SW.Close();

            //dane posortowane losowo
            SW = new StreamWriter("../../../Losowo.txt");
            for (int i = 0; i < n; i++)
            {
                SW.WriteLine(rand.Next(n));
            }
            SW.Close();
            Console.WriteLine();

            SW = new StreamWriter($"../../../Wynik_Testu_Wydajności_Sortowań_Dla_{n}_Elementów.txt");

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Sortowanie Danych Nierosnących: ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
            Nierosnąco(n, SW);

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Sortowanie Danych Niemalejących: ");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Niemalejąco(n, SW);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Sortowanie Danych Losowych: ");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Losowo(n, SW);

            SW.Close();
        }
    }
}
