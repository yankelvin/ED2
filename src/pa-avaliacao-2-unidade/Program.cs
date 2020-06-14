using pa_avaliacao_2_unidade.Models.FactoryMethod;
using pa_avaliacao_2_unidade.Models.Strategy;
using pa_avaliacao_2_unidade.Models.TemplateMethod;

namespace pa_avaliacao_2_unidade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var deliverSystem = new DeliverSystem();
            var invoice = new Invoice
            {
                Icms = new IcmsNorth(),
                Value = 200
            };

            var logisticTruck = new LogisticTruck(invoice, deliverSystem);
            logisticTruck.NewOperation();

            invoice.Icms = new IcmsWest();
            invoice.Value = 500;

            var logisticAirPlane = new LogisticAirPlane(invoice, deliverSystem);
            logisticAirPlane.NewOperation();
        }
    }
}
