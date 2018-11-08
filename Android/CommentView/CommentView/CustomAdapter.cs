﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CommentView;
using static Android.Resource;

namespace CommentView
{
    public class CustomAdapter : BaseAdapter<CommentProperties>
    {
        readonly List<CommentProperties> Items;
        readonly Activity Context;

        public CustomAdapter(Activity Context, List<CommentProperties> Items) : base()
        {
            this.Context = Context;
            this.Items = Items;
        }

        public override CommentProperties this[int position]
        {
            get { return Items[position]; }
        }

        public override int Count
        {
            get { return Items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            View view = convertView;

            if (view == null)
                view = Context.LayoutInflater.Inflate(Resource.Layout.CommentViewRow, null);

            int ImageID = (int)typeof(Resource.Drawable).GetField(Items[position].Image).GetValue(null);
            //Views
            Button Like = view.FindViewById<Button>(Resource.Id.LikeButton);
            view.FindViewById<TextView>(Resource.Id.UserName).Text = Items[position].UserName;
            view.FindViewById<TextView>(Resource.Id.PostDate).Text = (Items[position].Date).ToString();
            view.FindViewById<TextView>(Resource.Id.Comment).Text = Items[position].Comment;
            view.FindViewById<TextView>(Resource.Id.LikeCount).Text = "LIKES: " + Items[position].Likes;
            view.FindViewById<ImageView>(Resource.Id.ProfilePicture).SetImageResource(ImageID);
            Like.Click += delegate
            {
                int currentLikes = Convert.ToInt32(Like.Text);
                Like.Text += currentLikes++;
            };


            return view;
        }
    }
}