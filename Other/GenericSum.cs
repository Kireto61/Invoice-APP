using InvoiceApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Other
{
    public interface Sum
    {
        Price Sum { get; }
        void Clear();
        void Add(Items item, DbSet<CurrencyExchange> currencyExchanges);
    }
    public class GenericSum<T> : Sum where T : CurrencyType, new()
    {
        private GenericPrice<T> sum;
        private CurrencyEnum currencyEnum;

        public Price Sum { get => sum; }

        public GenericSum(CurrencyEnum currencyEnum)
        {
            this.currencyEnum = currencyEnum;
            this.sum = new GenericPrice<T>(0);
        }

        public void Clear()
        {
            this.sum = new GenericPrice<T>(0);
        }

        public void Add(Items item, DbSet<CurrencyExchange> currencyExchanges)
        {
            if (item.Currency == null)
            {
                return;
            }
            if (item.Currency == currencyEnum)
            {
                sum += new GenericPrice<T>(item.Total); 
            }
            else
            {
                var rate = currencyExchanges.Where(exh => exh.FromCurrency == item.Currency && exh.ToCurrency == currencyEnum).First().Rate;
                sum += new GenericPrice<T>(rate * item.Total);
            }
        }

        public void ApplyBigSumDiscount(GenericPrice<T> amountToGetDiscountBGN)
        {
            if (sum.Amount > amountToGetDiscountBGN.Amount)
            {
                sum = sum.multiply(0.9) as GenericPrice<T>;
            }
        }
    }
}