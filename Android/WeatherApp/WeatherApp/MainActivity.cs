using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using WeatherApp.Core;
using System.Net;
using Java.Net;
using Android.Graphics;
using Android.Content;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;  

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/FirstTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView textView;
        TextView textView2;
        TextView textView3;
        SearchView searchBar;
        ImageView Picture;
        string cityName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.activity_main);

            AppCenter.Start("d4082ce3-17d1-4fef-9c26-0e4167f855b7", typeof(Analytics), typeof(Crashes));

            var button = FindViewById<Button>(Resource.Id.button1);
            var weekLayoutButton = FindViewById<Button>(Resource.Id.button2);
            var toolBar = FindViewById<Toolbar>(Resource.Layout.TopToolbar);
            searchBar = FindViewById<SearchView>(Resource.Id.searchView1);            
            textView = FindViewById<TextView>(Resource.Id.textView1);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            Picture = FindViewById<ImageView>(Resource.Id.imageView1);

            button.Click += Button_Click;
            weekLayoutButton.Click += WeekLayoutButton_Click;           
           

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



        private void WeekLayoutButton_Click(object sender, EventArgs e)
        {                        
            Intent forecastActivity = new Intent(this, typeof(WeekForecastActivity));                      
            StartActivity(forecastActivity);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action Selected: " + item.TitleFormatted, ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            cityName = (searchBar.Query).ToString();
            var weather = await Core.Core.getForecast(cityName);
            textView.Text = "Temperature: " + weather.minTemperature + " / " + weather.maxTemperature + "°C";            
            textView2.Text = "Humidity: " + weather.Humidity;
            textView3.Text = "Wind Speed: " + weather.Wind + "m/s";
            switch (weather.Icon)
            {
                case ("01d"):

                    Picture.SetImageResource(Resource.Drawable.sun);
                    break;

                case ("02d"):
                    Picture.SetImageResource(Resource.Drawable.fewclouds);
                    break;

                case ("03d"):
                    Picture.SetImageResource(Resource.Drawable.scatteredclouds);
                    break;

                case ("04d"):
                    Picture.SetImageResource(Resource.Drawable.brokenclouds);
                    break;

                case ("09d"):
                    Picture.SetImageResource(Resource.Drawable.showerrain);
                    break;

                case ("10d"):
                    Picture.SetImageResource(Resource.Drawable.rain);
                    break;

                case ("11d"):
                    Picture.SetImageResource(Resource.Drawable.thunderstorm);
                    break;

                case ("13d"):
                    Picture.SetImageResource(Resource.Drawable.snow);
                    break;

                case ("50d"):
                    Picture.SetImageResource(Resource.Drawable.mist);
                    break;

                case ("01n"):
                    Picture.SetImageResource(Resource.Drawable.sunn);
                    break;

                case ("02n"):
                    Picture.SetImageResource(Resource.Drawable.fewcloudsn);
                    break;

                case ("03n"):
                    Picture.SetImageResource(Resource.Drawable.scatteredcloudsn);
                    break;

                case ("04n"):
                    Picture.SetImageResource(Resource.Drawable.brokencloudsn);
                    break;

                case ("09n"):
                    Picture.SetImageResource(Resource.Drawable.showerrainn);
                    break;

                case ("10n"):
                    Picture.SetImageResource(Resource.Drawable.rainn);
                    break;

                case ("11n"):
                    Picture.SetImageResource(Resource.Drawable.thunderstormn);
                    break;

                case ("13n"):
                    Picture.SetImageResource(Resource.Drawable.snown);
                    break;

                case ("50n"):
                    Picture.SetImageResource(Resource.Drawable.mistn);
                    break;
            }

        }
    }
}