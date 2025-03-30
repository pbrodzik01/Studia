using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Edge
    {
        public int Vertex1 { get; set; }
        public int Vertex2 { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {     
        static void Main(string[] args)
        {
            //all edges
            List<Edge> edges = new List<Edge>();
            edges.Add(new Edge() { Vertex1 = 1, Vertex2 = 3, Weight = 5 });
            edges.Add(new Edge() { Vertex1 = 2, Vertex2 = 4, Weight = 7 });
            edges.Add(new Edge() { Vertex1 = 2, Vertex2 = 1, Weight = 2 });
            edges.Add(new Edge() { Vertex1 = 3, Vertex2 = 2, Weight = 3 });
            edges.Add(new Edge() { Vertex1 = 0, Vertex2 = 3, Weight = 3 });
            edges.Add(new Edge() { Vertex1 = 4, Vertex2 = 0, Weight = 12 });

            //set of vertices
            List<int> vertices = new List<int>() { 0, 1, 2, 3, 4 };

            List<Edge> MinimumSpanningTree = Kruskals_MST(edges, vertices);

            //printing results
            int totalWeight = 0;
            foreach (Edge edge in MinimumSpanningTree)
            {
                totalWeight += edge.Weight;
                Console.WriteLine("Vertex {0} to Vertex {1} weight is: {2}", edge.Vertex1, edge.Vertex2, edge.Weight);
            }
            Console.WriteLine("Total Weight: {0}", totalWeight);
            Console.ReadLine();
        }

        static List<Edge> Kruskals_MST(List<Edge> edges, List<int> vertices)
        {
            //empty result list
            List<Edge> result = new List<Edge>();

            //making set
            DisjointSet.Set set = new DisjointSet.Set(100);
            foreach (int vertex in vertices)
                set.MakeSet(vertex);

            //sorting the edges order by weight ascending
            var sortedEdge = edges.OrderBy(x => x.Weight).ToList();

            foreach (Edge edge in sortedEdge)
            {
                //adding edge to result if both vertices do not belong to same set
                //both vertices in same set means it can have cycles in tree
                if (set.FindSet(edge.Vertex1) != set.FindSet(edge.Vertex2))
                {
                    result.Add(edge);
                    set.Union(edge.Vertex1, edge.Vertex2);
                }
            }
            return result;
        }
    }
}
