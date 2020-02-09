using System;
using System.Collections.Generic;

namespace GenericTree.Class
{
    public class Tree<Index, T> : ITree<Index, T>
    {
        private Node<Index, T> Root;
        private int Count;

        public Tree()
        {
            _ = Root == null;
        }

        public Tree(Index index, T data)
        {
            Root = new Node<Index, T>(index, data);
        }

        public void AddRoot(Index index, T data)
        {
            if (IsEmpty())
            {
                Root = new Node<Index, T>(index, data);
                Count++;
            }
        }

        public void AddNode(Index fatherIndex, Index index, T data)
        {
            if (IsEmpty())
                return;

            var node = SearchNode(fatherIndex);
            if (node != null)
            {
                node.AddChildren(new Node<Index, T>(index, data));
                Count++;
            }
        }

        public T RemoveNode(Index index)
        {
            var parent = Parent(index);

            if (parent != null)
            {
                var node = parent.FindNode(index);
                parent.RemoveChildren(index);
                Count -= (1 + node.Childrens.Count);

                return node.Data;
            }

            return default;
        }

        public Node<Index, T> SearchNode(Index index)
        {
            if (IsEmpty())
                return null;

            if (Root.Ind.Equals(index))
                return Root;

            return Search(index, Root.Childrens);

            static Node<Index, T> Search(Index index, List<Node<Index, T>> nodes)
            {
                if (nodes.Count == 0)
                    return null;

                foreach (var n in nodes)
                    if (n.Ind.Equals(index))
                        return n;

                Node<Index, T> node = null;

                foreach (var n in nodes)
                {
                    node = Search(index, n.Childrens);
                    if (node != null)
                        return node;
                }

                return node;
            }
        }

        public bool IsEmpty() => Root == null ? true : false;

        public Node<Index, T> GetRoot() => Root;

        public int Size() => Count;

        public bool IsExternal(Index index)
        {
            var node = SearchNode(index);

            return node != null && node.Childrens.Count == 0 ? true : false;
        }

        public bool IsInternal(Index index)
        {
            var node = SearchNode(index);

            return node != null && node.Childrens.Count > 0 ? true : false;
        }

        public bool IsRoot(Index index)
        {
            return !IsEmpty() && Root.Ind.Equals(index) ? true : false;
        }

        public Node<Index, T> Parent(Index index)
        {
            return SearchParent(index, Root, Root.Childrens);

            static Node<Index, T> SearchParent(Index index, Node<Index, T> parent, List<Node<Index, T>> nodes)
            {
                if (nodes.Count == 0)
                    return null;

                foreach (var n in nodes)
                    if (n.Ind.Equals(index))
                        return parent;

                Node<Index, T> node = null;

                foreach (var n in nodes)
                {
                    node = SearchParent(index, n, n.Childrens);
                    if (node != null)
                        return node;
                }

                return node;
            }
        }

        public void Replace(Index index, T v)
        {
            var node = SearchNode(index);

            if (node != null)
                node.Data = v;
        }

        public IEnumerable<Node<Index, T>> GetNodes()
        {
            return !IsEmpty() ? Root.Childrens : null;
        }

        public IEnumerable<Node<Index, T>> Children(Index index)
        {
            return SearchNode(index)?.Childrens;
        }
    }
}
