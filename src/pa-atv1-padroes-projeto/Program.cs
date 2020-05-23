using pa_atv1_padroes_projeto.Models;
using System;

namespace pa_atv1_padroes_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var televisao = new Televisao("Samsung");
            televisao.AdicionarCanal("TV Sergipe");

            var tel1 = new Telespectador("Nilda", televisao);
            var tel2 = new Telespectador("Marcio", televisao);
            var tel3 = new Telespectador("Jasiel", televisao);

            televisao.AdicionarCanal("TV Aperipê");
            televisao.AdicionarCanal("TV Atalaia");
        }
    }
}
