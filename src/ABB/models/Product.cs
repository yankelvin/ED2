using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.models
{
    public class Produto
    {
        public string Nome { get; set; }
        public int AnoFabricacao { get; set; }
        public string Chassi { get; set; }
        public Categoria Categoria { get; set; }
        public Comprador Comprador { get; set; }

        public Produto()
        {
            Comprador = null;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Chassi: {Chassi} | Categoria: {Categoria.ToString()} | Comprador: {Comprador?.Nome}";
        }
    }
}
