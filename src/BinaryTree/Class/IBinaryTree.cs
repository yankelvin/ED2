using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Class
{
    public interface IBinaryTree<T>
    {
        // Adiciona um nó na árvore
        public void Add(T data);

        // Busca um nó e retorna o mesmo
        public Node<T> Search(T data);

        // Remove um nó na árvore
        public void Remove(T data);

        // Retorna a quantidade de nós da árvore
        public int Size();

        //retorna se a árvore está vazia
        public bool IsEmpty();

        // Substitui o elemento armazenado em determinado nó
        public void Replace(T data, T value);

        // Retorna a raiz da árvore
        public Node<T> GetRoot();
    }
}
