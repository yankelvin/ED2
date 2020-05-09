using Prova.Class;
using System;

namespace Prova
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int, int>();
            binaryTree.Add(5, 5);
            binaryTree.Add(3, 3);
            binaryTree.Add(7, 7);

            // 1 - a)
            Console.WriteLine("1 - a)");
            binaryTree.PreOrder().ForEach(it => Console.WriteLine(it));
            Console.WriteLine();
            binaryTree.AfterOrder().ForEach(it => Console.WriteLine(it));
            Console.WriteLine();
            binaryTree.SimetricOrder().ForEach(it => Console.WriteLine(it));

            // 1 - b)
            Console.WriteLine("\n1 - b)");
            Console.WriteLine("Buscando um valor: " + binaryTree.Search(7));

            // 1 - c)
            Console.WriteLine("\n1 - c)");
            var minMax = binaryTree.GetMinMax();
            Console.WriteLine($"Menor valor: {minMax[0]} | Maior valor: {minMax[1]}");

            // 1 - d)
            Console.WriteLine("\n1 - d)");
            var average = binaryTree.GetAverage();
            Console.WriteLine($"Valor médio: {average}");

            // 1 - e)
            Console.WriteLine("\n1 - e)");
            var nodesAndLeafs = binaryTree.CountNodesAndLeafs();
            Console.WriteLine($"Número de nós: {nodesAndLeafs[0]}");

            // 1 - f)
            Console.WriteLine("\n1 - f)");
            Console.WriteLine($"Número de folhas: {nodesAndLeafs[1]}");

            // 1 - g)
            Console.WriteLine("\n1 - g)");
            var height = binaryTree.GetHeight();
            Console.WriteLine($"Altura da árvore: {height}");

            // 1 - h)
            Console.WriteLine("\n1 - h)");
            binaryTree.Remove(3);
        }
    }
}
