using InvoiceApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InvoiceApp.Other;
using InvoiceApp.Database;
using InvoiceApp.Model;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace InvoiceApp.ViewModel
{
    public partial class InvoiceViewModel : ObservableObject
    {
        private readonly DatabaseContext _context;
        // private string _invoiceNumber;
        // private DateTime _invoiceDate = DateTime.Now;
        // private Customer _selectedCustomer;
        // private double _totalExclVat;
        // private double _totalInclVat;
        private const double VatRate = 0.20;
        private static readonly GenericPrice<BGN> amountToGetDiscountBGN = new GenericPrice<BGN>(20000);
        public ICollection<string> Types { get; } = Enum.GetValues<ItemsEnum>().Select(x => x.ToString()).ToList();
        public ICollection<string> Currencies { get; } = Enum.GetValues<CurrencyEnum>().Select(x => x.ToString()).ToList();
        // private List<Customer> data;

        [ObservableProperty]
        private Invoice _currentInvoice;

        [ObservableProperty]
        private Customer _selectedCustomer;

        public Price TotalExclVat
        {
            get
            {
              //comp error
              //  GenericPrice<BGN> amountToGetDiscountBGN = new GenericPrice<BGN>(20000);
              // GenericPrice<EUR> amountToGetDiscountEUR = new GenericPrice<EUR>(100);
              // amountToGetDiscountBGN + amountToGetDiscountEUR;
                if (CurrentInvoice.Currency == CurrencyEnum.BGN)
                {
                    GenericPrice<BGN> temp = new GenericPrice<BGN>(0);
                    foreach (var item in CurrentInvoice.Items)
                    {
                        if (item.Currency == null) continue;
                        if (CurrentInvoice.Currency == null) continue;
                        if (item.Currency == CurrentInvoice.Currency) temp += new GenericPrice<BGN>(item.Total);
                        else
                        {
                            var rate = _context.CurrencyExchanges.Where(exh => exh.FromCurrency == item.Currency && exh.ToCurrency == CurrentInvoice.Currency).First().Rate;
                            temp += new GenericPrice<BGN>(rate * item.Total);
                        }
                    }
                    if (temp.CompareTo(amountToGetDiscountBGN) == 1)
                    {
                        return temp * 0.9;
                    }
                    else
                    {
                        return temp;
                    }
                }
                else if (CurrentInvoice.Currency == CurrencyEnum.EUR)
                {
                    GenericPrice<EUR> amountToGetDiscountEUR = new GenericPrice<EUR>(_context.CurrencyExchanges.Where(exh => exh.FromCurrency == CurrencyEnum.BGN && exh.ToCurrency == CurrencyEnum.EUR).First().Rate * amountToGetDiscountBGN.Amount);
                    GenericPrice<EUR> temp = new GenericPrice<EUR>(0);
                    foreach (var item in CurrentInvoice.Items)
                    {
                        if (item.Currency == null) continue;
                        if (CurrentInvoice.Currency == null) continue;
                        if (item.Currency == CurrentInvoice.Currency) temp += new GenericPrice<EUR>(item.Total);
                        else
                        {
                            var rate = _context.CurrencyExchanges.Where(exh => exh.FromCurrency == item.Currency && exh.ToCurrency == CurrentInvoice.Currency).First().Rate;
                            temp += new GenericPrice<EUR>(rate * item.Total);
                        }
                    }
                    if (temp.CompareTo(amountToGetDiscountEUR) == 1)
                    {
                        return temp * 0.9;
                    }
                    else
                    {
                        return temp;
                    }
                }
                else if (CurrentInvoice.Currency == CurrencyEnum.USD)
                {
                    GenericPrice<USD> amountToGetDiscountUSD = new GenericPrice<USD>(_context.CurrencyExchanges.Where(exh => exh.FromCurrency == CurrencyEnum.BGN && exh.ToCurrency == CurrencyEnum.USD).First().Rate * amountToGetDiscountBGN.Amount);
                    GenericPrice<USD> temp = new GenericPrice<USD>(0);
                    foreach (var item in CurrentInvoice.Items)
                    {
                        if (item.Currency == null) continue;
                        if (CurrentInvoice.Currency == null) continue;
                        if (item.Currency == CurrentInvoice.Currency) temp += new GenericPrice<USD>(item.Total);
                        else
                        {
                            var rate = _context.CurrencyExchanges.Where(exh => exh.FromCurrency == item.Currency && exh.ToCurrency == CurrentInvoice.Currency).First().Rate;
                            temp += new GenericPrice<USD>(rate * item.Total);
                        }
                    }
                    if (temp.CompareTo(amountToGetDiscountUSD) == 1)
                    {
                        return temp * 0.9;
                    }
                    else
                    {
                        return temp;
                    }
                }
                return new GenericPrice<BGN>(0);
            }
        }

        public Price TotalInclVat
        {
            get => TotalExclVat * (1 + VatRate);
        }

        public InvoiceViewModel()
        {
            CurrentInvoice = new Invoice();
            CurrentInvoice.Date = DateTime.Now;
            CurrentInvoice.Items = new BindingList<Items>();
            CurrentInvoice.Items.ListChanged += Items_ListChanged;

            _context = new DatabaseContext();
            _context.Database.EnsureCreated();
            // Load items with their currencies
            _context.Items.Load();
            // Load customers
            _context.Customers.Load();

            // In a production app you might retrieve these from the database
            Customers = new ObservableCollection<Customer>(_context.Customers.Local.ToList());

            //ItemsChoice = new ObservableCollection<Items>(_context.Items.Local.ToList());

            AddItemCommand = new RelayCommand(AddItem);
            CalculateCommand = new RelayCommand(CalculateTotals);
        }

        private void Items_ListChanged(object? sender, ListChangedEventArgs e)
        {
            OnCurrentInvoiceChanged(CurrentInvoice);
            OnPropertyChanged(nameof(TotalExclVat));
            OnPropertyChanged(nameof(TotalInclVat));
        }

        // public List<Customer> Data { get => data; private set => data = value; }

        // Invoice Header properties
        //public string InvoiceNumber
        //{
        //    get => _invoiceNumber;
        //    set { _invoiceNumber = value; OnPropertyChanged(); }
        //}

        //public DateTime InvoiceDate
        //{
        //    get => _invoiceDate;
        //    set { _invoiceDate = value; OnPropertyChanged(); }
        //}

        public ObservableCollection<Customer> Customers { get; set; }

        // public Customer SelectedCustomer
        // {
        //     get => _selectedCustomer;
        //     set { _selectedCustomer = value; OnPropertyChanged(); }
        // }

        //public ObservableCollection<Items> ItemsChoice { get; set; }

        // Commands
        public ICommand AddItemCommand { get; set; }
        public ICommand CalculateCommand { get; set; }

        // Command Methods
        private void AddItem(object parameter)
        {
            // Create a new item with default values.
            // You can later extend this to allow the user to select type or currency.
            var newItem = new Model.Items
            {
                Type = null,
                Currency = null,
                Price = 0,
                Quantity = 0
            };
            CurrentInvoice.Items.Add(newItem);
            OnPropertyChanged();
        }

        public void CalculateTotals(object parameter = null)
        {
            OnCurrentInvoiceChanged(CurrentInvoice);
            OnPropertyChanged(nameof(TotalExclVat));
            OnPropertyChanged(nameof(TotalInclVat));
            Task.Run(async () =>
            {
               await _context.RegisterInvoice(CurrentInvoice);
            });
            
        }
    }
}
