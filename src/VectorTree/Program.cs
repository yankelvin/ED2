using System;
using VectorTree.Class;

namespace VectorTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var vectorTree = new VectorTree<int, string>();
            vectorTree.Add(5, "cinco");
            vectorTree.Add(7, "sete");
            vectorTree.Add(3, "tres");
            vectorTree.Add(8, "oito");
            vectorTree.Add(6, "seis");
            vectorTree.Add(4, "quatro");
            vectorTree.Add(2, "dois");

            var node = vectorTree.Parent(2);
        }
    }
}
