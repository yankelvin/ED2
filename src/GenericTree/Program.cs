using GenericTree.Class;
using System;

namespace GenericTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<string, int>("um", 1);
            tree.AddNode("um", "dois", 2);
            tree.AddNode("um", "tres", 3);

            tree.AddNode("dois", "quatro", 4);
            tree.AddNode("tres", "cinco", 5);

            tree.AddNode("quatro", "seis", 6);
            tree.AddNode("cinco", "sete", 7);

            Console.WriteLine(tree.Size());
        }
    }
}
