using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StockMarketApp.DB
{
    class DatabaseBinder
    {
        public SqlConnection Connection { get; set; }

        public string ConnectionString { get; private set; }

        public DatabaseBinder()
        {
            
        }

        public SqlConnection GetDBConnector()
        {
            ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Stocks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection = new SqlConnection(ConnectionString);
            return Connection;
        }

        public void CloseDbConnectioner()
        {
            Connection.Close();
        }

    }
}
