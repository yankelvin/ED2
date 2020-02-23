using System;

namespace VectorTree.Class
{
    public class Node<K, T>
    {
        public K Key { get; private set; }
        public T Data { get; set; }
        public Node<K, T> Parent { get; set; }

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
            return $"Key: {Key} | Data: {Data}";
        }
    }
}
