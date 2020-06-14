namespace pa_avaliacao_2_unidade.Models.Strategy
{
    public class Invoice
    {
        // IMPOSTO SOBRE CIRCULAÇÃO DE MERCADORIAS e SERVIÇOS
        public IIcms Icms { get; set; }
        public decimal Value { get; set; }

        public decimal CalculateIcms()
        {
            return Icms.CalculateIcms(Value);
        }
    }
}
