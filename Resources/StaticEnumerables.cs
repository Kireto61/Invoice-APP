using InvoiceApp.Model;

namespace InvoiceApp.Resources
{
    public static class StaticEnumerables
    {
        // Returns a read-only list of all CurrencyEnum values.
        public static IEnumerable<CurrencyEnum> CurrencyList { get; } =
            Enum.GetValues(typeof(CurrencyEnum))
                .Cast<CurrencyEnum>()
                .ToList()
                .AsReadOnly();
    }
}