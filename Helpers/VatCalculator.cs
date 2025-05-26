namespace CarPriceApi.Helpers
{
    public static class VatCalculator
    {
        public static decimal ToNet(decimal? net, decimal? gross, decimal vat)
        {
            if (net.HasValue && net > 0)
                return net.Value;

            if (gross.HasValue && gross > 0)
                return gross.Value / (1 + vat);

            return 0;
        }

        public static decimal ToGross(decimal? gross, decimal? net, decimal vat)
        {
            if (gross.HasValue && gross > 0)
                return gross.Value;

            if (net.HasValue && net > 0)
                return net.Value * (1 + vat);

            return 0;
        }
    }
}
