namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public class TruckCreator : AbstractCreator
    {
        public override ITransport FactoryMethod()
        {
            return new Truck();
        }

    }
}
