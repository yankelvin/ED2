using System;
using System.Collections.Generic;
using System.Text;

namespace ed2_arvore_avl.Models
{
    public class AvlTree<K, V>
    {
        protected Node<K, V> Root;

        public void Add(K key, V value)
        {
            var n = new Node<K, V>(key, value);
            AddWithCompare(Root, n);
        }

        private void AddWithCompare(Node<K, V> compare, Node<K, V> node)
        {
            if (compare == null)
            {
                Root = node;
            }
            else
            {
                if (node.GetHashCode() < compare.GetHashCode())
                {
                    if (compare.Left == null)
                    {
                        compare.Left = node;
                        node.Parent = compare;
                        VerifyWeight(compare);
                    }
                    else
                    {
                        AddWithCompare(compare.Left, node);
                    }
                }
                else if (node.GetHashCode() > compare.GetHashCode())
                {
                    if (compare.Right == null)
                    {
                        compare.Right = node;
                        node.Parent = compare;
                        VerifyWeight(compare);

                    }
                    else
                    {
                        AddWithCompare(compare.Right, node);
                    }
                }
            }
        }

        public void VerifyWeight(Node<K, V> node)
        {
            SetWeight(node);

            if (node.Weight == -2)
            {
                if (Height(node.Left.Left) >= Height(node.Left.Right))
                {
                    node = RightRotation(node);
                }
                else
                {
                    node = DoubleRotationLeftRight(node);
                }
            }
            else if (node.Weight == 2)
            {

                if (Height(node.Right.Right) >= Height(node.Right.Left))
                {
                    node = LeftRotation(node);
                }
                else
                {
                    node = DoubleRotationRightLeft(node);
                }
            }

            if (node.Parent != null)
            {
                VerifyWeight(node.Parent);
            }
            else
            {
                Root = node;
            }
        }

        public void Remove(int k)
        {
            RemoveAVL(Root, k);
        }

        private void RemoveAVL(Node<K, V> node, int k)
        {
            if (node == null)
            {
                return;

            }
            else
            {
                if (node.GetHashCode() > k)
                {
                    RemoveAVL(node.Left, k);
                }
                else if (node.GetHashCode() < k)
                {
                    RemoveAVL(node.Right, k);
                }
                else if (node.GetHashCode() == k)
                {
                    RemoveNode(node);
                }
            }
        }

        public void RemoveNode(Node<K, V> node)
        {
            Node<K, V> r;

            if (node.Left == null || node.Right == null)
            {
                if (node.Parent == null)
                {
                    Root = null;
                    return;
                }

                r = node;
            }
            else
            {
                r = Next(node);
                node.Key = r.Key;
            }

            Node<K, V> p;
            if (r.Left != null)
            {
                p = r.Left;
            }
            else
            {
                p = r.Right;
            }

            if (p != null)
            {
                p.Parent = r.Parent;
            }

            if (r.Parent == null)
            {
                Root = p;
            }
            else
            {
                if (r == r.Parent.Left)
                {
                    r.Parent.Left = p;
                }
                else
                {
                    r.Parent.Right = p;
                }

                VerifyWeight(r.Parent);
            }
        }

        public Node<K, V> LeftRotation(Node<K, V> node)
        {
            Node<K, V> right = node.Right;
            right.Parent = node.Parent;

            node.Right = right.Left;

            if (node.Right != null)
            {
                node.Right.Parent = node;
            }

            right.Left = node;
            node.Parent = right;

            if (right.Parent != null)
            {

                if (right.Parent.Right == node)
                {
                    right.Parent.Right = right;

                }
                else if (right.Parent.Left == node)
                {
                    right.Parent.Left = right;
                }
            }

            SetWeight(node);
            SetWeight(right);

            return right;
        }

        public Node<K, V> RightRotation(Node<K, V> node)
        {
            Node<K, V> left = node.Left;
            left.Parent = node.Parent;

            node.Left = left.Right;

            if (node.Left != null)
            {
                node.Left.Parent = node;
            }

            left.Right = node;
            node.Right = left;

            if (left.Parent != null)
            {

                if (left.Parent.Right == node)
                {
                    left.Parent.Right = left;

                }
                else if (left.Parent.Left == node)
                {
                    left.Parent.Left = left;
                }
            }

            SetWeight(node);
            SetWeight(left);

            return left;
        }

        public Node<K, V> DoubleRotationLeftRight(Node<K, V> node)
        {
            node.Left = LeftRotation(node.Left);
            return RightRotation(node);
        }

        public Node<K, V> DoubleRotationRightLeft(Node<K, V> node)
        {
            node.Right = RightRotation(node.Right);
            return LeftRotation(node);
        }

        public Node<K, V> Next(Node<K, V> q)
        {
            if (q.Right != null)
            {
                Node<K, V> r = q.Right;
                while (r.Left != null)
                {
                    r = r.Left;
                }

                return r;
            }
            else
            {
                Node<K, V> p = q.Parent;
                while (p != null && q == p.Right)
                {
                    q = p;
                    p = q.Parent;
                }

                return p;
            }
        }

        private int Height(Node<K, V> node)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Left == null && node.Right == null)
            {
                return 0;
            }
            else if (node.Left == null)
            {
                return 1 + Height(node.Right);
            }
            else if (node.Right == null)
            {
                return 1 + Height(node.Left);
            }
            else
            {
                return 1 + Math.Max(Height(node.Left), Height(node.Right));
            }
        }

        private void SetWeight(Node<K, V> no)
        {
            no.Weight = Height(no.Right) - Height(no.Left);
        }

        public void Clean()
        {
            Root = null;
        }
    }
}
