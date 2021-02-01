using StockMarketApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StockMarketApp.ViewModels
{

    public delegate double RandomiserFunctionPointer(Random random, double min, double max);

    class StockViewModel
    {
        public ObservableCollection<Stock> Stocks { get; set; }

        public StockViewModel()
        {
            Random random = new Random();
            RandomiserFunctionPointer randomiser = StockRandomiser;

            Stocks = new ObservableCollection<Stock>()
            {
                new Stock(1, "Google", "GOOG", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00),  randomiser(random, 0000.00, 1000.00),  "USD"),
                new Stock(2, "Apple", "AAPL", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00), randomiser(random, 0000.00, 1000.00),  "USD"),
                new Stock(3, "Microsoft", "MSFT", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00), randomiser(random, 0000.00, 1000.00),  "USD"),
                new Stock(4, "Suziki", "SUZI", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00),  randomiser(random, 0000.00, 1000.00),  "JPY"),
                new Stock(5, "Rolls Royce", "ROLL", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00),  randomiser(random, 0000.00, 1000.00),  "GBP"),
                new Stock(6, "Attock Petrol", "ATTO", randomiser(random, 1000.00, 2500.00), randomiser(random, 1500.00, 2500.00),  randomiser(random, 0000.00, 1000.00),  "PKR"),
            };
        }

        public double StockRandomiser(Random random, double min, double max)
        {
            return min + random.NextDouble() * (max - min);
        }

    }
}
