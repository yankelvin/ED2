using System;
using System.Collections.Generic;
using System.Text;

namespace ed2_arvore_avl.Models
{
    public class Node<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public int Weight { get; set; }
        public Node<K, V> Parent { get; set; }
        public Node<K, V> Left { get; set; }
        public Node<K, V> Right { get; set; }


        public Node(K key, V value, Node<K, V> parent = null)
        {
            Parent = parent;
            Left = null;
            Right = null;
            Weight = 0;
            Key = key;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}
