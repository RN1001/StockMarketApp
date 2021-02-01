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
            var stock = stockViewModel.Stocks.FirstOrDefault(s => s.MarketIdentifier.Contains(initials));

            ChangePercentageLabel.Content = stock.ChangePercentage.ToString("##.##");
            VolumeLabel.Content = stock.Volume;
            UpdatedLastLbl.Content = stock.UpdatedLast.Date;

            this.SetGrowthStatuses(stock);

        }

        private void SetGrowthStatuses(Stock stock)
        {
            DailyChangeLbl.Content = stock.DailyGrowth.ToString("##.##");
            MontlyChangeLbl.Content = stock.MonthlyGrowth.ToString("##.##");
            YearlyChangeLbl.Content = stock.YearlyGrowth.ToString("##.##");

            if (stock.DailyGrowth > 0.00)
            {
                DailyGrowthStatusLbl.Content = "INC";
                DailyGrowthStatusLbl.Background = Brushes.Green;
            }
            else
            {
                DailyGrowthStatusLbl.Content = "DEC";
                DailyGrowthStatusLbl.Background = Brushes.Red;
            }

            if (stock.MonthlyGrowth > 0.00)
            {
                MonthlyGrowthStatusLbl.Content = "INC";
                MonthlyGrowthStatusLbl.Background = Brushes.Green;
            }
            else
            {
                MonthlyGrowthStatusLbl.Content = "DEC";
                MonthlyGrowthStatusLbl.Background = Brushes.Red;
            }

            if (stock.YearlyGrowth > 0.00)
            {
                YearlyGrowthStatusLbl.Content = "INC";
                YearlyGrowthStatusLbl.Background = Brushes.Green;
            }
            else
            {
                YearlyGrowthStatusLbl.Content = "DEC";
                YearlyGrowthStatusLbl.Background = Brushes.Red;
            }
        }

    }
}
