using InvoiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Other
{
    public class CurrencyType
    {
        public string Name { get; protected set; }
        public string Symbol { get; protected set; }
        public string Code { get; protected set; }

        protected CurrencyType(string name, string symbol, string code)
        {
            Name = name;
            Symbol = symbol;
            Code = code;
        }

        public static CurrencyType? from(CurrencyEnum currency)
        {
            switch (currency)
            {
                case CurrencyEnum.BGN:
                    return new BGN();
                case CurrencyEnum.USD:
                    return new USD();
                case CurrencyEnum.EUR:
                    return new EUR();
                default:
                    return null;
            }
        }
    }
}
