using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;


namespace ListViewExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        string[] food = new string[]
        {
            "piim", "sai", "leib", "õun", "pitsa"
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Sisse ehitatud Adapter

            /*//<---> 
             ListAdapter = new ArrayAdapter<string>(this
                 , Android.Resource.Layout.SimpleExpandableListItem1, food);
           *///<--->
            ListAdapter = new CustomAdapter(this, food); 
            ListView.ItemClick += ListView_Click;
        }

        private void ListView_Click(object sender, AdapterView.ItemClickEventArgs args)
        {
            Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Long).Show();
        }
    }
}