namespace pa_avaliacao_2_unidade.Models.Strategy
{
    public class IcmsNorth : IIcms
    {
        public decimal CalculateIcms(decimal value)
        {
            return value * 1.18M;
        }
    }

    public class IcmsSouth : IIcms
    {
        public decimal CalculateIcms(decimal value)
        {
            return value * 1.25M;
        }
    }

    public class IcmsEast : IIcms
    {
        public decimal CalculateIcms(decimal value)
        {
            return value * 1.12M;
        }
    }

    public class IcmsWest : IIcms
    {
        public decimal CalculateIcms(decimal value)
        {
            return value * 1.21M;
        }
    }
}
