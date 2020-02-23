using System.Collections.Generic;
using System.Linq;

namespace VectorTree.Class
{
    public class VectorTree<K, T> : IVectorTree<K, T>
    {
        public List<Node<K, T>> Nodes { get; private set; }
        public int Count { get; private set; }

        public VectorTree()
        {
            Nodes = new List<Node<K, T>>();
            Count = 0;
        }

        public VectorTree(K key, T data) : this()
        {
            Nodes.Add(new Node<K, T>(key, data));
            Count++;
        }

        public void Add(K key, T data)
        {
            if (IsEmpty())
            {
                Nodes.Add(new Node<K, T>(key, data));
                Count++;
                return;
            }

            var current = GetRoot();
            while (true)
            {
                if (current == null)
                    break;

                Node<K, T> parent = current;
                int index = key.GetHashCode() < current.GetHashCode() ? 2 * (Nodes.IndexOf(current) + 1) - 1 : 2 * (Nodes.IndexOf(current) + 1);

                for (int i = Nodes.Count; i < index + 1; i++)
                    Nodes.Add(null);

                if (Nodes[index] == null)
                {
                    Nodes[index] = new Node<K, T>(key, data) { Parent = parent };
                    break;
                }
                else
                {
                    current = Nodes[index];
                }
            }

            Count++;
        }

        public Node<K, T> Search(K key)
        {
            var current = GetRoot();

            while (true)
            {
                if (current == null)
                    break;

                if (current.Key.Equals(key))
                    return current;

                int index = key.GetHashCode() < current.GetHashCode() ? 2 * (Nodes.IndexOf(current) + 1) - 1 : 2 * (Nodes.IndexOf(current) + 1);

                if (index >= Nodes.Count || Nodes[index] == null)
                    break;

                current = Nodes[index];
            }

            return null;
        }

        public Node<K, T> Remove(K key)
        {
            var node = Search(key);
            if (node == null)
                return null;

            var index = Nodes.IndexOf(node);

            if (index < Nodes.Count)
                Nodes[index] = null;

            Count--;
            return node;
        }

        public void Replace(K key, T value)
        {
            var node = Search(key);
            if (node != null)
                node.Data = value;
        }

        public Node<K, T> GetRoot() => Nodes.FirstOrDefault();

        public bool IsEmpty() => Nodes.Count == 0 ? true : false;

        public Node<K, T> Parent(K key) => Search(key)?.Parent;

        public int Size() => Count;
    }
}
