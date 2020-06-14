using System;

namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public abstract class AbstractCreator
    {
        public abstract ITransport FactoryMethod();

        public Guid NewDeliver()
        {
            var transport = FactoryMethod();

            return transport.Deliver();
        }
    }
}
