using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorytmy_i_Struktury_Danych___LAB_4
{    
    public class Edge
    {
        public int Punkt1 { get; set; }
        public int Punkt2 { get; set; }
        public int Waga { get; set; }
    }

    internal class Program
    {        

        public static void Read(List<Edge> edges)
        {
            StreamReader stream_reader = new StreamReader("../../../dane.txt", Encoding.UTF8);

            string linia = "";
            string Punkt_początek = "";
            string Punkt_koniec = "";
            string Waga = "";

            while (linia != null)
            {
                linia = stream_reader.ReadLine();

                Punkt_początek = linia.Substring(0, linia.IndexOf(","));
                linia = linia.Substring(linia.IndexOf(",") + 1);
                Punkt_koniec = linia.Substring(0, linia.IndexOf(","));
                linia = linia.Substring(linia.IndexOf(",") + 1);
                Waga = linia;

                edges.Add(new Edge() { Punkt1 = int.Parse(Punkt_początek), Punkt2 = int.Parse(Punkt_koniec), Waga = int.Parse(Waga) });
            }
        }

        static void Main(string[] args)
        {
            //wszystkie krawędzie
            List<Edge> edges = new List<Edge>();

            Read(edges);

            //Zbiór krawędzi
            List<int> vertices = new List<int>() { 0, 1, 2, 3, 4 };

            List<Edge> MinimumSpanningTree = Kruskals_MST(edges, vertices);

            //Wyświetlanie wyników
            int totalWeight = 0;
            foreach (Edge edge in MinimumSpanningTree)
            {
                totalWeight += edge.Waga;
                Console.WriteLine($"Z punktu {edge.Punkt1} do punktu {edge.Punkt2}: Waga: {edge.Waga}");
            }
            Console.WriteLine($"Waga całkowita: {totalWeight}");
        }

        static List<Edge> Kruskals_MST(List<Edge> edges, List<int> vertices)
        {
            //Tworzenie pustej listy wyników
            List<Edge> result = new List<Edge>();

            //Tworzenie Zestawu
            DisjointSet.Set set = new DisjointSet.Set(100);
            foreach (int vertex in vertices)
                set.MakeSet(vertex);

            //sorting the edges order by weight ascending
            var sortedEdge = edges.OrderBy(x => x.Waga).ToList();

            foreach (Edge edge in sortedEdge)
            {
                //adding edge to result if both vertices do not belong to same set
                //both vertices in same set means it can have cycles in tree
                if (set.FindSet(edge.Punkt1) != set.FindSet(edge.Punkt2))
                {
                    result.Add(edge);
                    set.Union(edge.Punkt1, edge.Punkt2);
                }
            }
            return result;
        }
    }
}
