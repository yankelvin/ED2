using System;

namespace BinaryTree.Class
{
    public class Node<K, T>
    {
        public K Key { get; private set; }
        public T Data { get; set; }
        public Node<K, T> Parent { get; set; }
        public Node<K, T> Left { get; set; }
        public Node<K, T> Right { get; set; }

        public Node(K key, T data)
        {
            if (key == null || data == null)
                throw new NullReferenceException();

            Key = key;
            Data = data;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            var left = Left == null ? "" : Left.Key.ToString();
            var right = Right == null ? "" : Right.Key.ToString();

            return $"Key: {Key} | Data: {Data} | Left: {left} | Right: {right}";
        }
    }
}
