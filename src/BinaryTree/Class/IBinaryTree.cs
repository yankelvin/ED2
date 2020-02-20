using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Class
{
    public interface IBinaryTree<K, T>
    {
        // Adiciona um nó na árvore
        public void Add(K key, T data);

        // Busca um nó e retorna o mesmo
        public Node<K, T> Search(K key);

        // Busca o pai de um nó e retorna o mesmo
        public Node<K, T> Parent(K key);

        // Remove um nó na árvore
        public Node<K, T> Remove(K key);

        // Retorna a quantidade de nós da árvore
        public int Size();

        //retorna se a árvore está vazia
        public bool IsEmpty();

        // Substitui o elemento armazenado em determinado nó
        public void Replace(K key, T value);

        // Retorna a raiz da árvore
        public Node<K, T> GetRoot();
    }
}
