using System.Collections.Generic;
using System.Linq;

namespace Prova.Class
{
    public class BinaryTree<K, T> : IBinaryTree<K, T>
    {
        public Node<K, T> Root { get; private set; }
        public int Count { get; private set; }

        public BinaryTree()
        {
            Root = null;
            Count = 0;
        }

        public BinaryTree(K key, T data) : this()
        {
            Root = new Node<K, T>(key, data);
            Count++;
        }

        public void AddIterative(K key, T data)
        {
            var node = new Node<K, T>(key, data);

            if (IsEmpty())
            {
                Root = node;
                Count++;
                return;
            }

            var current = Root;
            while (true)
            {
                Node<K, T> parent = current;
                if (key.GetHashCode() < current.GetHashCode())
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = node;
                        node.Parent = parent;
                        return;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = node;
                        node.Parent = parent;
                        return;
                    }
                }
            }
        }

        public void Add(K key, T data)
        {
            if (IsEmpty())
            {
                Root = new Node<K, T>(key, data);
                Count++;
                return;
            }

            insert(key, data, Root, Root);

            static Node<K, T> insert(K key, T data, Node<K, T> node, Node<K, T> parent)
            {
                if (node == null)
                {
                    return new Node<K, T>(key, data) { Parent = parent };
                }

                if (key.GetHashCode() < node.GetHashCode())
                    node.Left = insert(key, data, node.Left, node);
                else
                    node.Right = insert(key, data, node.Right, node);

                return node;
            }

            Count++;
        }

        public Node<K, T> Search(K key)
        {
            return SearchNode(key, Root);

            static Node<K, T> SearchNode(K key, Node<K, T> node)
            {
                if (node == null)
                    return null;

                if (node.Key.Equals(key))
                    return node;

                if (key.GetHashCode() < node.GetHashCode())
                    return SearchNode(key, node.Left);

                return SearchNode(key, node.Right);
            }
        }

        public Node<K, T> SearchIterative(K key)
        {
            var current = Root;

            while (!current.Key.Equals(key))
            {
                if (key.GetHashCode() < current.Key.GetHashCode())
                    current = current.Left;
                else
                    current = current.Right;

                if (current == null)
                    return null;
            }

            return current;
        }

        public Node<K, T> Remove(K key)
        {
            var node = Search(key);
            if (node == null)
                return Root;

            Node<K, T> q;
            if (node.Left == null || node.Right == null)
            {
                if (node.Left == null)
                    q = node.Right;
                else
                    q = node.Left;
            }
            else
            {
                Node<K, T> p = node;
                q = node.Left;

                while (q.Right != null)
                {
                    p = q;
                    q = q.Right;
                }

                if (!p.Equals(node))
                {
                    p.Right = q.Left;
                    q.Left = node.Left;
                }

                q.Right = node.Right;
                q.Parent = node.Parent;
                p.Parent = q;
            }

            var parent = node.Parent;

            if (parent == null)
            {
                Free(node.Key);
                Count--;
                return q;
            }

            if (key.GetHashCode() < parent.Key.GetHashCode())
                parent.Left = q;
            else
                parent.Right = q;

            Free(node.Key);
            Count--;
            return Root;
        }

        public void Replace(K key, T value)
        {
            var node = Search(key);
            if (node != null)
                node.Data = value;
        }

        private void Free(K key)
        {
            var parent = Parent(key);
            if (parent != null)
            {
                if (parent.Left.Key.Equals(key))
                    parent.Left = null;
                else if (parent.Right.Key.Equals(key))
                    parent.Right = null;
            }
        }

        public List<Node<K, T>> PreOrder()
        {
            List<Node<K, T>> list = new List<Node<K, T>>();
            ListPreOrder(Root, ref list);
            return list;

            static void ListPreOrder(Node<K, T> node, ref List<Node<K, T>> list)
            {
                if (node != null)
                {
                    list.Add(node);
                    ListPreOrder(node.Left, ref list);
                    ListPreOrder(node.Right, ref list);
                }
            }
        }

        public List<Node<K, T>> AfterOrder()
        {
            List<Node<K, T>> list = new List<Node<K, T>>();
            ListAfterOrder(Root, ref list);
            return list;

            static void ListAfterOrder(Node<K, T> node, ref List<Node<K, T>> list)
            {
                if (node != null)
                {
                    ListAfterOrder(node.Left, ref list);
                    ListAfterOrder(node.Right, ref list);
                    list.Add(node);
                }
            }
        }

        public List<Node<K, T>> SimetricOrder()
        {
            List<Node<K, T>> list = new List<Node<K, T>>();
            ListSimetricOrder(Root, ref list);
            return list;

            static void ListSimetricOrder(Node<K, T> node, ref List<Node<K, T>> list)
            {
                if (node != null)
                {
                    ListSimetricOrder(node.Left, ref list);
                    list.Add(node);
                    ListSimetricOrder(node.Right, ref list);
                }
            }
        }

        public T[] GetMinMax()
        {
            var min = int.MaxValue;
            T minValue = default;
            var max = int.MinValue;
            T maxValue = default;

            SimetricOrder().ForEach(it =>
            {
                if (it.Data.GetHashCode() > max)
                {
                    max = it.Data.GetHashCode();
                    maxValue = it.Data;
                }

                if (it.Data.GetHashCode() < min)
                {
                    min = it.Data.GetHashCode();
                    minValue = it.Data;
                }
            });

            return new T[] { minValue, maxValue };
        }

        public int GetAverage()
        {
            var sum = SimetricOrder().Sum(it => it.Data.GetHashCode());

            return sum / Count;
        }

        public int[] CountNodesAndLeafs()
        {
            int countNodes = 0;
            int countLeafs = 0;

            SimetricOrder().ForEach(it =>
            {
                if (it.Left == null && it.Right == null)
                    countLeafs++;
                else
                    countNodes++;
            });

            return new int[] { countNodes, countLeafs };
        }

        public int GetHeight()
        {
            return Height(Root);
        }

        private int Height(Node<K, T> h)
        {
            int u, v;

            if (h == null)
                return -1;

            u = Height(h.Left);
            v = Height(h.Right);

            if (u > v)
                return u + 1;
            else
                return v + 1;
        }

        public Node<K, T> GetRoot() => Root;

        public bool IsEmpty() => Root == null ? true : false;

        public Node<K, T> Parent(K key) => Search(key)?.Parent;

        public int Size() => Count;

        public override string ToString() => Root.ToString();
    }
}
