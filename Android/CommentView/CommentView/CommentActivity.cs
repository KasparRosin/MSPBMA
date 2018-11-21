using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace CommentView
{
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : Activity
    {
        private ListView List;     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            SetContentView(Resource.Layout.CommentsRow);
            base.OnCreate(savedInstanceState);
            Button button = FindViewById<Button>(Resource.Id.BackButton);
            List = FindViewById<ListView>(Resource.Id.ListViewComment);
            List.Adapter = new CommentViewAdapter(this, SelectedComments.Comments);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SelectedComments.Comments.Clear();
            StartActivity(typeof(MainActivity));
        }
    }
}