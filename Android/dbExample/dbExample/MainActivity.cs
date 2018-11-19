using Android.App;
using Android.OS;
using Android.Support.V7.App;
using SQLite;
using System.IO;


namespace dbExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.activity_main);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Stock>();          
            var newStock = new Stock();
            if (db.Table<Stock>().Count() == 0)
            {
                newStock.Symbol = "AAPL";
                db.Insert(newStock);
                newStock.Symbol = "MSDN";
                db.Insert(newStock);
            }           
            
            var table = db.Table<Stock>();
            foreach (var item in table)
            {
                System.Diagnostics.Debug.WriteLine(item.Id + " Reading Data: " + item.Symbol);
            }
        }
    }
    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
        
    }
}