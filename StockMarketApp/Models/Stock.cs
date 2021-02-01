using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApp.Models
{
    class Stock
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string MarketIdentifier { get; set; }
        public double CurrentValue { get; set; }
        public double HighestStockValue { get; set; }
        public double LowestStockValue { get; set; }
        public string CurrencyName { get; set; }


        public Stock(
            int id,
            string companyName,
            string marketIdentifier,
            double currentValue,
            double highestStockValue,
            double lowestStockValue,
            string currencyName
        )
        {
            this.Id = id;
            this.CompanyName = companyName;
            this.MarketIdentifier = marketIdentifier;
            this.CurrentValue = currentValue;
            this.HighestStockValue = highestStockValue;
            this.LowestStockValue = lowestStockValue;
            this.CurrencyName = currencyName;
        }

        public override string ToString()
        {
            return $"id: {Id}, Company: {CompanyName}, Initials: {MarketIdentifier}, Current Value: {CurrentValue.ToString("####.##")}, High: {HighestStockValue.ToString("####.##")}, Low {LowestStockValue.ToString("####.##")}, Current: {CurrencyName}";
        }

    }
}
