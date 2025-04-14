using InvoiceApp.Model;

namespace InvoiceApp.Other
{
    public abstract class Price
    {
        public double Amount { get; set; }
        public CurrencyType Currency { get; protected set; }

        protected Price(double amount, CurrencyType currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price operator*(Price price, double multiplier)
        {
            return price.multiply(multiplier);
        }

        public abstract Price multiply(double multiplier);

        public override string ToString()
        {
            return string.Format("{0:N2} {1}", Amount, Currency.Code);
        }
    }
}
