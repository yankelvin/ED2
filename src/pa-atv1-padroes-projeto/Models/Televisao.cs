using System;
using System.Collections.Generic;

namespace pa_atv1_padroes_projeto.Models
{
    public class Televisao : IObservable<Televisao>
    {
        public string Marca { get; private set; }
        public List<string> Canais { get; private set; }
        private List<IObserver<Televisao>> observers;

        public Televisao(string marca)
        {
            SetMarca(marca);
            Canais = new List<string>();
            observers = new List<IObserver<Televisao>>();
        }

        public void SetMarca(string marca)
        {
            if (!string.IsNullOrEmpty(marca))
                Marca = marca;
        }

        public void AdicionarCanal(string canal)
        {
            if (!string.IsNullOrEmpty(canal))
            {
                Canais.Add(canal);
                observers.ForEach(it => it.OnNext(this));
            }
        }

        public IDisposable Subscribe(IObserver<Televisao> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                observer.OnNext(this);
            }

            return null;
        }
    }
}
