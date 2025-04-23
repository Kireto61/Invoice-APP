using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Other
{
    public class GenericPrice<T> : Price, IComparable<GenericPrice<T>> where T : CurrencyType, new()
    {
        public GenericPrice(double amount) : base(amount, new T())
        {
            Currency = new T();
            Amount = amount;
        }

        public override Price multiply(double multiplier)
        {
            return new GenericPrice<T>(Amount * multiplier);
        }

        public int CompareTo(GenericPrice<T>? other)
        {
            if (other == null) return 1;
            if (this.Amount > other.Amount) return 1;
            if (this.Amount < other.Amount) return -1;
            return 0;
        }

        public static GenericPrice<T> operator +(GenericPrice<T> price1, GenericPrice<T> price2)
        {
            return new GenericPrice<T>(price1.Amount + price2.Amount);
        }
    }
}
