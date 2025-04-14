using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InvoiceApp.Model
{
    [Table("Items")]
    public class Items : ObservableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TypeString { get; set; }

        [NotMapped]
        public ItemsEnum? Type
        {
            get
            {
                if (string.IsNullOrEmpty(TypeString))
                    return null;
                if (Enum.TryParse(typeof(ItemsEnum), TypeString, out var result))
                {
                    return (ItemsEnum)result;
                }
                return null;
            }
            set
            {
                TypeString = value.ToString();
            }
        }
        public string? CurrencyString { get; set; }
        
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

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                SetProperty(ref _price, value);
                OnPropertyChanged(nameof(Total));
            }
        }

        private int _quantity;
        private CurrencyEnum? currency;

        public int Quantity
        {
            get => _quantity;
            set
            {
                SetProperty(ref _quantity, value);
                OnPropertyChanged(nameof(Total));
            }
        }
        public double Total
        { 
            get 
            {
                return (Price * Quantity) * (1 - ((Quantity > 10) ? 0.2 : 0));
            }
        }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
