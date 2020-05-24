using System;
using System.Collections.Generic;
using System.Text;

namespace pa_atv1_padroes_projeto.Models
{
    public class Impressora
    {
        private static Impressora _impressora = null;
        public static string Marca { get; private set; }
        public static string IP { get; private set; }
        public static int Porta { get; private set; }

        private Impressora() { }

        public static Impressora GetImpressora()
        {
            if (_impressora == null)
                _impressora = new Impressora();

            return _impressora;
        }

        public static void SetMarca(string marca)
        {
            if (!string.IsNullOrEmpty(marca))
                Marca = marca;
        }

        public static void SetIp(string ip)
        {
            if (!string.IsNullOrEmpty(ip))
                IP = ip;
        }

        public static void SetPorta(int porta)
        {
            if (porta > 0)
                Porta = porta;
        }

        public void Print(string matricula)
        {
            Console.WriteLine($"Matrícula: {matricula} | Memória: {GetHashCode()} | Marca: {Marca} | Ip: {IP} | Porta: {Porta}");
        }
    }

    public class Funcionario
    {
        public string Nome { get; private set; }
        public string Matricula { get; private set; }

        public Funcionario(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
    }
}
