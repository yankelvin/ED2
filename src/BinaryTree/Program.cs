using BinaryTree.Class;
using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int, string>();

            binaryTree.Add(18, "dezoito");
            binaryTree.Add(8, "oito");
            binaryTree.Add(2, "dois");
            binaryTree.Add(14, "quatorze");
            binaryTree.Add(10, "dez");
            binaryTree.Add(9, "nove");
            binaryTree.Add(12, "doze");
            binaryTree.Add(16, "dezeseis");
            binaryTree.Add(11, "onze");

            var nodes = binaryTree.PreOrder();
        }
    }
}
