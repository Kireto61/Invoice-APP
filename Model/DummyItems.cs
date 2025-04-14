using InvoiceApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Model
{
    public class DummyItems:Items
    {
        private readonly InvoiceViewModel _invoice;
        public DummyItems(InvoiceViewModel invoice)
        {
            _invoice = invoice;
            bool testcond = true;
#if testcond
#error x
#endif
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            _invoice.CalculateTotals(null);
        }
    }
}
