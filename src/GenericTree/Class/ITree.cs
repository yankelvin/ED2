using System.Collections.Generic;

namespace GenericTree.Class
{
    public interface ITree<Index, T>
    {
        // Adiciona um nó na árvore
        public void AddRoot(Index index, T data);
        public void AddNode(Index fatherIndex, Index ind, T data);

        // Busca um nó e retorna o mesmo
        public Node<Index, T> SearchNode(Index index);

        // Remove um nó na árvore
        public T RemoveNode(Index index);

        // Retorna a quantidade de nós da árvore
        public int Size();

        //retorna se a árvore está vazia
        public bool IsEmpty();

        // Retorna um coleção interável de nós
        public IEnumerable<Node<Index, T>> GetNodes();

        // Substitui o elemento armazenado em determinado nó
        public void Replace(Index index, T v);

        // Retorna a raiz da árvore
        public Node<Index, T> GetRoot();

        // retorna o pai de um nó
        public Node<Index, T> Parent(Index index);

        // retorna lista de filhos
        public IEnumerable<Node<Index, T>> Children(Index index);

        // retorna verdadeiro se o nó é interno
        public bool IsInternal(Index index);

        // retorna verdadeiro se o nó é externo
        public bool IsExternal(Index index);

        // retorna verdadeiro se o nó é raiz
        public bool IsRoot(Index index);
    }
}
