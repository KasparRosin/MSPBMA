using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;

namespace WeatherApp
{
    [Activity(Label = "WeekForecastActivity")]
    public class WeekForecastActivity : Activity
    {
        ListView list;
        SearchView searchBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeekLayout);

            list = FindViewById<ListView>(Resource.Id.listView1);
            searchBar = FindViewById<SearchView>(Resource.Id.searchView1);

            var button = FindViewById<Button>(Resource.Id.button1);

            button.Click += Button_Click;
        }


        private async void Button_Click(object sender, EventArgs e)
        {            
            string cityName = (searchBar.Query).ToString();
            var forecasts = await Core.Core.GetWeekForecast(cityName);

            if (forecasts != null)
            {
                list.Adapter = new CustomAdapter(this, forecasts);
            }
        }      
    }
}