using pa_avaliacao_2_unidade.Models.FactoryMethod;
using pa_avaliacao_2_unidade.Models.Strategy;
using System;

namespace pa_avaliacao_2_unidade.Models.TemplateMethod
{
    public class LogisticAirPlane : LogisticSystem
    {

        public LogisticAirPlane(Invoice invoice, DeliverSystem deliverSystem) : base(invoice, deliverSystem) { }

        protected override Guid Deliver()
        {
            return DeliverSystem.NewDeliver(new AirPlaneCreator());
        }
    }
}
