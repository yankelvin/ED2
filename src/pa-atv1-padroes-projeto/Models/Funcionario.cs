namespace pa_atv1_padroes_projeto.Models
{
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
