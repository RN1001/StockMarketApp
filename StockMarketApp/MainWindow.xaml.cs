using StockMarketApp.DB;
using StockMarketApp.Models;
using StockMarketApp.ViewModels;
using System;
using System.Collections.Generic;
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

namespace StockMarketApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StockViewModel stockViewModel = new StockViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StockViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabaseBinder binder = new DatabaseBinder();
            var conn = binder.GetDBConnector();
            MessageBox.Show(conn.Database);
            binder.CloseDbConnectioner();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var initials = searchStockTbox.Text;

            var stock = from stocks in stockViewModel.Stocks
                        select stocks.MarketIdentifier;

            if (stock.Contains(initials))
            {
                MessageBox.Show("Found a stock");
            } 
            else
            {
                MessageBox.Show("Could not find stock identifier");
            }

        }
    }
}
