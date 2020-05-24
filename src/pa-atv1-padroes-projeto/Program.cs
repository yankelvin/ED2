using pa_atv1_padroes_projeto.Models;
using System;

namespace pa_atv1_padroes_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe a questão: ");
            var opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    var televisao = new Televisao("Samsung");
                    televisao.AdicionarCanal("TV Sergipe");

                    _ = new Telespectador("Nilda", televisao);
                    _ = new Telespectador("Marcio", televisao);
                    _ = new Telespectador("Jasiel", televisao);

                    televisao.AdicionarCanal("TV Aperipê");
                    televisao.AdicionarCanal("TV Atalaia");
                    break;
                case 2:
                    Impressora.SetMarca("HP Deskjet F300 Series");
                    Impressora.SetIp("10.211.55.1");
                    Impressora.SetPorta(9100);

                    var fun1 = new Funcionario("Nilda", "123");
                    Impressora.GetImpressora().Print(fun1.Matricula);

                    var fun2 = new Funcionario("Marcio", "456");
                    Impressora.GetImpressora().Print(fun2.Matricula);

                    var fun3 = new Funcionario("Jasiel", "789");
                    Impressora.GetImpressora().Print(fun3.Matricula);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
