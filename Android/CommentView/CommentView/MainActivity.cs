using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace CommentView
{   
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity    
    {
        public int Count = 0;
        public static List<CommentProperties> Comments = new List<CommentProperties>();
        ListView List;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_main);
            base.OnCreate(savedInstanceState);
            List = FindViewById<ListView>(Resource.Id.ListView1);
            string dateFormat = "dd/MM/yyyy HH:mm:ss";
            Comments.Add(new CommentProperties { UserName = "James", Image = "JamesBond", Comment = "An Idea?", Date = DateTime.Now.ToString(dateFormat)}); 
            Comments.Add(new CommentProperties { UserName = "Elon Musk", Image = "ElonMusk", Comment = "a Joke", Date = DateTime.Now.ToString(dateFormat)});            
            List.Adapter = new CustomAdapter(this, Comments);
        }      
    }
}