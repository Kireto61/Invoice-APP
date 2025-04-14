using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using InvoiceApp.View.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvoiceApp.Model
{
    [Table("Invoices")]
    public partial class Invoice : ObservableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Currency))]
        private string? _currencyString;

        [NotMapped]
        public CurrencyEnum? Currency
        {
            get
            {
                if (string.IsNullOrEmpty(CurrencyString))
                    return null;
                if (Enum.TryParse(typeof(CurrencyEnum), CurrencyString, out var result))
                {
                    return (CurrencyEnum)result;
                }
                return null;
            }
            set
            {
                CurrencyString = value.ToString();
            }
        }

        public BindingList<Items> Items { get; set; } = new();

    }
}
