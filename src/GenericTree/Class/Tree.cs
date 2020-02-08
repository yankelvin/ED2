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

        public Node<Index, T> SearchNode(Index index)
        {
            if (IsEmpty())
                return null;

            if (Root.Ind.Equals(index))
                return Root;

            return Search(index, Root.Childrens);
        }

        private Node<Index, T> Search(Index index, List<Node<Index, T>> nodes)
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

        public bool IsEmpty()
        {
            return Root == null ? true : false;
        }

        public Node<Index, T> GetRoot() => Root;

        public int Size() => Count;

        public bool IsExternal(Index index)
        {
            var _node = SearchNode(index);
            return _node.Childrens.Count == 0 ? true : false;
        }

        public bool IsInternal(Index index)
        {
            var _node = SearchNode(index);
            return _node.Childrens.Count > 0 ? true : false;
        }

        public bool IsRoot(Index index)
        {
            return Root.Ind.Equals(index) ? true : false;
        }

        public Node<Index, T> Parent(Index index)
        {
            throw new NotImplementedException();
        }

        public T Replace(Index index, T v)
        {
            var _node = SearchNode(index).Data = v;
            return _node;
        }

        public Iterator<T> Iterator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Node<Index, T>> GetNodes()
        {
            return Root.Childrens;
        }

        public IEnumerable<Node<Index, T>> Children(Index index)
        {
            return SearchNode(index).Childrens;
        }
    }
}
