using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace dbExample
{
    public class dbService
    {
        SQLiteConnection db;        
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
            db = new SQLiteConnection(dbPath);
            CreateTable();
        }        
        
        public void CreateTable()
        {
            db.CreateTable<Stock>();
            var newStock = new Stock();
            if (db.Table<Stock>().Count() == 0)
            {
                newStock.Symbol = "AAPL";
                db.Insert(newStock);
                newStock.Symbol = "MSDN";
                db.Insert(newStock);
                newStock.Symbol = "TESLA";
                db.Insert(newStock);
                newStock.Symbol = "AMAZON";
                db.Insert(newStock);
                newStock.Symbol = "AMD";
                db.Insert(newStock);
            }
        }

        public TableQuery<Stock> GetAllStocks()
        {
            var Table = db.Table<Stock>();
            return Table;
        }

        public void DeleteStock(int Id)
        {
            var stockToDelete = new Stock();
            stockToDelete.Id = Id;
            db.Delete(stockToDelete);
        }

    }
}