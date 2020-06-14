using System;

namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public class DeliverSystem
    {
        public Guid NewDeliver(AbstractCreator creator)
        {
            return creator.NewDeliver();
        }
    }
}
