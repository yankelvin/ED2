using pa_avaliacao_2_unidade.Models.FactoryMethod;
using pa_avaliacao_2_unidade.Models.Strategy;
using System;

namespace pa_avaliacao_2_unidade.Models.TemplateMethod
{
    public abstract class LogisticSystem
    {
        public Invoice Invoice { get; set; }
        public DeliverSystem DeliverSystem { get; set; }

        public LogisticSystem(Invoice invoice, DeliverSystem deliverSystem)
        {
            Invoice = invoice;
            DeliverSystem = deliverSystem;
        }

        public void NewOperation()
        {
            var operation = Deliver();
            Console.WriteLine($"ID da Operação: {operation}");

            CalculateInvoice();
            SendInformations();
        }

        protected abstract Guid Deliver();

        public void CalculateInvoice()
        {
            var value = Invoice.CalculateIcms();
            Console.WriteLine($"O valor da nota fiscal ficou em: {value}");
        }

        public void SendInformations()
        {
            Console.WriteLine("Enviando informações para o cliente.\n");
        }
    }
}
