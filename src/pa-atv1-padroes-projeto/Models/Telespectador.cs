using System;
using System.Linq;

namespace pa_atv1_padroes_projeto.Models
{
    public class Telespectador : IObserver<Televisao>
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public Telespectador(string nome, IObservable<Televisao> televisao)
        {
            SetNome(nome);
            televisao.Subscribe(this);
        }

        public void SetNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
                Nome = nome;
        }

        public void SetEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
                Email = email;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Televisao televisao)
        {
            if (televisao.Canais.Any())
                Console.WriteLine($"\n{Nome}, o canal {televisao.Canais.LastOrDefault()} foi adicionado à televisão que você observa.");
        }
    }
}
