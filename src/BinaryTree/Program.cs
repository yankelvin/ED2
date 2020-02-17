using BinaryTree.Class;
using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            binaryTree.Add(5);
            binaryTree.Add(3);
            binaryTree.Add(8);
        }
    }
}
