using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Android.Widget;
using Android.Views;

namespace FragmentSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            AppCenter.Start("ddb2e4ee-5858-493d-9898-5626f3aee4fd", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("{Your Xamarin Android App Secret}", typeof(Distribute));

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Click += FabOnClick;
        }  

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(AddPost));
        }
    }
}