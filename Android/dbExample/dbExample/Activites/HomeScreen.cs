using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using dbExample.Adapters;
using System.IO;


namespace dbExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class HomeScreen : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.HomeScreen);
            var dbService = new dbService();
            dbService.CreateDatabase();
            dbService.CreateTable();
            var table = dbService.GetAllStocks();
            var StockListView = FindViewById<ListView>(Resource.Id.lstTasks);
            StockListView.Adapter = new StockListAdapter(this, table.ToList());
            var AddStockBtn = FindViewById<Button>(Resource.Id.btnAddTask);

            AddStockBtn.Click += AddStockBtn_Click;
        }

        private void AddStockBtn_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Activites.StockDetailsScreen));  
        }
    }
}