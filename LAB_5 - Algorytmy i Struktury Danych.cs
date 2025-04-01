using System;
using System.IO;
using System.Diagnostics;

namespace DrzewoBTS
{
    class NODE
    {
        public int label; //etykieta
        public NODE left; //lewo
        public NODE right; //prawo

        public NODE(int data)
        {
            label = data;
            left = null;
            right = null;
        }

        public void ADD_NODE(NODE root)
        {
            if (root == null) { Console.WriteLine("Nie można uruchomić programu, ponieważ wartość korzenia jest pusta"); return; }
            else if (label < root.label)
            {   //lewo
                if (root.left != null) { ADD_NODE(root.left); }
                else { Console.WriteLine($"Dodano {label} na lewo od {root.label}"); root.left = this; }
            }
            else if (label > root.label)
            {   //prawo
                if (root.right != null) { ADD_NODE(root.right); }
                else { Console.WriteLine($"Dodano {label} na prawo od {root.label}"); root.right = this; }
            }
        }

        private int MinValue(NODE node)
        {
            int minv = node.label;
            while (node.left != null)
            {
                minv = node.left.label;
                node = node.left;
            }
            return minv;
        }

        public NODE root { get; set; }
        public void Remove(int value) { this.root = Remove(this.root, value); }

        private NODE Remove(NODE parent, int key)
        {
            if (parent == null) return parent;
            if (key < parent.label) parent.left = Remove(parent.left, key);
            else if (key > parent.label) parent.right = Remove(parent.right, key);
            else
            {   // Węzeł z jednym potomkiem lub bez potomka             
                if (parent.left == null) return parent.right;
                else if (parent.right == null) return parent.left;

                // Węzeł z 2 potomkami
                parent.label = MinValue(parent.right);
                parent.right = Remove(parent.right, parent.label);
            }
            return parent;
        }

        public void REMOVE_NODE(NODE root)
        {
            if (label < root.label)
            {   //lewo
                if (root.left != null) ADD_NODE(root.left);
                else { Console.WriteLine($"Dodano {label} na lewo od {root.label}"); root.left = this; }
            }
            else if (label > root.label)
            {   //prawo
                if (root.right != null) ADD_NODE(root.right);
                else { Console.WriteLine($"Dodano {label} na prawo od {root.label}"); root.right = this; }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NODE root = null;
            Random rand = new Random();

            Console.Write("Podaj liczbę węzłów:   ");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[] nodes = new int[p];
            for (int i = 0; i < p; i++)
            {
                int x = rand.Next(0, 100);
                NODE n = new NODE(x);

                if (root == null)
                {
                    Console.WriteLine($"Ustawiono {n.label} jako korzeń");
                    root = n;
                    nodes[i] = n.label;
                }
                else
                {
                    n.ADD_NODE(root);
                    nodes[i] = n.label;
                }
            }

            Console.Write("\nPodaj węzeł do usunięcia spośród wcześnienj podanych:   ");
            int b = int.Parse(Console.ReadLine());

            int ToRemove = b;
            var nodes_list = nodes.ToList();
            nodes_list.Remove(b);

            Console.WriteLine("\nUsuwanie...");
            Console.WriteLine();

            for (int i = 0; i < p - 1; i++)
            {
                int x = nodes_list[i];

                NODE n = new NODE(x);
                if (i == 0)
                {
                    Console.WriteLine($"Ustawiono {n.label} jako korzeń");
                    root = n;
                    nodes[i] = n.label;
                }
                else
                {
                    n.ADD_NODE(root);
                    nodes[i] = n.label;
                }
            }
        }
    }
}