using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceApp.Model;
namespace InvoiceApp.Model
{
    [Table("Currencies")]
    public class CurrencyExchange
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CurrencyEnum FromCurrency { get; set; }
        public CurrencyEnum ToCurrency { get; set; }
        public double Rate { get; set; }
    }
}
