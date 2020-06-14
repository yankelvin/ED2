using System;

namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public class AirPlane : ITransport
    {
        public Guid Deliver()
        {
            Console.WriteLine("Um avião irá transportar a encomenda.");
            return Guid.NewGuid();
        }
    }
}
