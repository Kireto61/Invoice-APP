using InvoiceApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InvoiceApp.ViewModel;
using InvoiceApp.View.Components;

namespace InvoiceApp.View.Componets
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : UserControl
    {
        InvoiceDisplayWindow invoiceDisplay;
        public Invoice()
        {
            InitializeComponent();
            DataContext = new InvoiceViewModel();
            invoiceDisplay = new InvoiceDisplayWindow((InvoiceViewModel)DataContext);
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(!invoiceDisplay.IsLoaded)
            {
                invoiceDisplay = new InvoiceDisplayWindow((InvoiceViewModel)DataContext);
            }
            invoiceDisplay.Show();
            invoiceDisplay.Focus();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as InvoiceViewModel).CalculateTotals();
        }
    }
}
