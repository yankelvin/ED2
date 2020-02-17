using System;

namespace BinaryTree.Class
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node() { }

        public Node(T data) : this()
        {
            if (data == null)
                throw new NullReferenceException();

            Data = data;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Data: {Data} | Left: {Left} | Right: {Right}";
        }
    }
}
