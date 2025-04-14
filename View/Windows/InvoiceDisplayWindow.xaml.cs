using System.Windows;
using InvoiceApp.View.Windows;
using InvoiceApp.ViewModel;

namespace InvoiceApp.View.Components
{
    public partial class InvoiceDisplayWindow : Window
    {
        public InvoiceDisplayWindow(InvoiceViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Show();
            MainWindow.Instance.Focus();
        }
    }
}