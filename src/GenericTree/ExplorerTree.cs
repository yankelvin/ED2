using GenericTree.Class;
using System;
using System.Collections.Generic;

namespace GenericTree
{
    public class ExplorerTree
    {
        private readonly Tree<string, int> Tree;

        public ExplorerTree()
        {
            Tree = new Tree<string, int>();
        }

        public ExplorerTree(string folderName, int kbytes) : this()
        {
            AddRoot(folderName, kbytes);
        }

        public void AddRoot(string folderName, int kbytes)
        {
            if (Tree.IsEmpty())
                Tree.AddRoot(folderName, kbytes);
        }

        public void AddFileFolder(string parent, string name, int kbytes)
        {
            if (!Tree.IsEmpty())
                Tree.AddNode(parent, name, kbytes);
        }

        public void ShowExplorer()
        {
            var root = Tree.GetRoot();

            Explorer(root, root.Childrens);

            static int Explorer(Node<string, int> node, List<Node<string, int>> childrens)
            {
                if (childrens.Count == 0)
                {
                    Console.WriteLine($"FolderFile: {node.Ind} | Kbytes: {node.Data}");
                    return 0;
                }

                int sumChildren = 0;
                foreach (var children in childrens)
                    sumChildren += children.Data;

                foreach (var children in childrens)
                    sumChildren += Explorer(children, children.Childrens);

                Console.WriteLine($"FolderFile: {node.Ind} | Kbytes: {sumChildren + 1}");

                return sumChildren;
            }
        }
    }
}
