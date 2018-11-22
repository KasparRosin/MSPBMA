using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace dbExample.Activites
{
    [Activity(Label = "StockDetailsScreen")]
    public class StockDetailsScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskDetails);            
            var SaveStockBtn = FindViewById<Button>(Resource.Id.btnSave);
            SaveStockBtn.Click += SaveStockBtn_Click;
        }
        

        private void SaveStockBtn_Click(object sender, EventArgs e)
        {
            var GetStockSymbol = FindViewById<EditText>(Resource.Id.NameLabel);
            //Write GetStockSymbol To Stock Class
            StartActivity(typeof(HomeScreen));
        }
    }
}