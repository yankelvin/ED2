using ed2_arvore_avl.Models;
using System;

namespace ed2_arvore_avl
{
    class Program
    {
        static void Main(string[] args)
        {
            var avlTree = new AvlTree<int, string>();
            avlTree.Add(30, "trinta");
            avlTree.Add(10, "dez");
            avlTree.Add(40, "quarenta");
            avlTree.Add(8, "oito");
            avlTree.Add(5, "cinco");
            avlTree.Add(2, "dois");
        }
    }
}
