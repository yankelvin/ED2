using GenericTree.Class;
using System.Collections.Generic;
using System.Linq;

namespace LavaJato
{
    public class LavaJato
    {
        public Tree<string, List<string>> Suspeitos { get; private set; }

        public LavaJato()
        {
            Suspeitos = new Tree<string, List<string>>("Suspeitos", null);
        }

        public void AdicionarSuspeito(string nomeSuspeito, List<string> crimesCumplice)
        {
            Suspeitos.AddNode("Suspeitos", nomeSuspeito, crimesCumplice);
        }

        public void AdicionarCumplice(string nomeSuspeito, string nomeCumplice, List<string> crimesCumplice)
        {
            var crimesSuspeito = Suspeitos.SearchNode(nomeSuspeito).Data;

            foreach (var crime in crimesSuspeito)
            {
                if (crimesCumplice.Contains(crime))
                {
                    crimesCumplice.Add("Formação de Quadrilha");
                    crimesSuspeito.Add("Formação de Quadrilha");
                    break;
                }
            }

            Suspeitos.AddNode(nomeSuspeito, nomeCumplice, crimesCumplice);
        }

        public List<string> ListarCumplices(string nomeSuspeito)
        {
            var list = new List<string>();
            var cumplices = Suspeitos.SearchNode(nomeSuspeito).Childrens;

            foreach (var cump in cumplices)
                list.Add(cump.Ind);

            list.Sort();

            return list;
        }

        public List<string> ListarCrimes(string nomeSuspeito)
        {
            var crimes = Suspeitos.SearchNode(nomeSuspeito).Data;

            crimes.Sort();

            return crimes;
        }

        public List<string> ListarSuspeitosComum(string nomeSuspeito1, string nomeSuspeito2)
        {
            var cumplices1 = Suspeitos.SearchNode(nomeSuspeito1).Childrens.Select(it => it.Ind);
            var cumplices2 = Suspeitos.SearchNode(nomeSuspeito2).Childrens.Select(it => it.Ind);

            var comum = cumplices1.Intersect(cumplices2);

            return comum.ToList();
        }
    }
}
