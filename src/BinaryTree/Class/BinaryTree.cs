using System;

namespace BinaryTree.Class
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(T data)
        {
            Root = new Node<T>(data);
        }

        public Node<T> GetRoot() => Root;

        public bool IsEmpty() => Root == null ? true : false;

        public void Add(T data)
        {
            if (IsEmpty())
            {
                Root = new Node<T>(data);
                Count++;
                return;
            }

            insert(data, Root);

            static Node<T> insert(T data, Node<T> node)
            {
                if (node == null)
                    return new Node<T>(data);

                if (data.GetHashCode() < node.GetHashCode())
                    node.Left = insert(data, node.Left);
                else
                    node.Right = insert(data, node.Right);

                return node;
            }

            Count++;
        }

        public Node<T> Search(T data)
        {
            return SearchNode(data, Root);

            static Node<T> SearchNode(T data, Node<T> node)
            {
                if (node == null)
                    return null;

                if (node.Data.Equals(data))
                    return node;

                if (node.Data.GetHashCode() > data.GetHashCode())
                    return SearchNode(data, node.Left);

                return SearchNode(data, node.Right);
            }
        }

        public void Remove(T data)
        {
            _ = Search(data);
        }

        public int Size() => Count;

        public void Replace(T data, T value)
        {
            var node = Search(data);
            node.Data = value;
        }
    }
}
