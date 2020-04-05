using System.Collections.Generic;

namespace ABB.models
{
    public class Comprador
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<Produto> Produtos { get; private set; }

        public Comprador()
        {
            Produtos = new List<Produto>();
        }
    }
}
