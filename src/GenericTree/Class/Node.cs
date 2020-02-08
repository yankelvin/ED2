using System;
using System.Collections.Generic;

namespace GenericTree.Class
{
    public class Node<Index, T>
    {
        public Index Ind { get; set; }
        public T Data { get; set; }
        public List<Node<Index, T>> Childrens { get; private set; }

        public Node()
        {
            Childrens = new List<Node<Index, T>>();
        }

        public Node(Index ind, T data) : this()
        {
            if (ind == null || data == null)
                throw new NullReferenceException();

            Ind = ind;
            Data = data;
        }

        public void AddChildren(Node<Index, T> node)
        {
            if (node != null)
                Childrens.Add(node);
        }

        public T RemoveChildren(Index index)
        {
            var children = Childrens.Find(it => it.Ind.Equals(index));
            if (children != null)
                Childrens.Remove(children);

            return default;
        }

        public Node<Index, T> FindNode(Index index)
        {
            var children = Childrens.Find(it => it.Ind.Equals(index));

            if (children != null)
                return children;

            return default;
        }

        public override string ToString()
        {
            return $"Data: {Data} : Childrens: {Childrens}";
        }
    }
}
