namespace pa_avaliacao_2_unidade.Models.FactoryMethod
{
    public class AirPlaneCreator : AbstractCreator
    {
        public override ITransport FactoryMethod()
        {
            return new AirPlane();
        }
    }
}
