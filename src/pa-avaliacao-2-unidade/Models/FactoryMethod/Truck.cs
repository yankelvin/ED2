using System;

namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public class Truck : ITransport
    {
        public Guid Deliver()
        {
            Console.WriteLine("Um caminhão irá transportar a encomenda.");
            return Guid.NewGuid();
        }
    }
}
