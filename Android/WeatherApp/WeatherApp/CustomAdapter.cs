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
using WeatherApp.Core;

namespace WeatherApp
{
    public class CustomAdapter : BaseAdapter<Forecast>
    {
        List<Forecast> items;        
        Activity context;

        public CustomAdapter(Activity context, List<Forecast> items) : base()
        {
            this.context = context;            
            this.items = items;
        }        

        public override Forecast this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string picture = items[position].Description;
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.dateTxt).Text = items[position].Date;
            switch (picture)
            {
                case ("_01d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.sun);                    
                break;

                case ("_02d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.fewclouds);
                break;

                case ("_03d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.scatteredclouds);
                break;

                case ("_04d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.brokenclouds);
                break;

                case ("_09d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.showerrain);
                break;

                case ("_10d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.rain);
                break;

                case ("_11d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.thunderstorm);
                break;

                case ("_13d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.snow);
                break;

                case ("_50d"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.mist);
                break;

                case ("_01n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.sunn);
                break;

                case ("_02n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.fewcloudsn);
                break;

                case ("_03n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.scatteredcloudsn);
                break;

                case ("_04n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.brokencloudsn);
                break;

                case ("_09n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.showerrainn);
                break;

                case ("_10n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.rainn);
                break;

                case ("_11n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.thunderstormn);
                break;

                case ("_13n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.snown);
                break;

                case ("_50n"):
                    view.FindViewById<ImageView>(Resource.Id.weatherPicture).SetImageResource(Resource.Drawable.mistn);
                break;
            }
            view.FindViewById<TextView>(Resource.Id.tempMax).Text = items[position].maxTemperature;
            view.FindViewById<TextView>(Resource.Id.tempMin).Text = " / " + items[position].minTemperature;
            
            return view;

        }
    }
}