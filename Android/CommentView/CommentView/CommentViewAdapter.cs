using System;
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace CommentView
{
    public class CommentViewAdapter : BaseAdapter<SingleCommentProperties>
    {           
        readonly CommentActivity commentActivity;
        readonly List<SingleCommentProperties> singleComments;

        public CommentViewAdapter(CommentActivity commentActivity, List<SingleCommentProperties> singleComments) : base()
        {
            this.commentActivity = commentActivity;
            this.singleComments = singleComments;
        }

        public override SingleCommentProperties this[int position]
        {
            get { return singleComments[position]; }
        }

        public override int Count
        {
            get { return singleComments.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View view = convertView;

            if (view == null)
                view = commentActivity.LayoutInflater.Inflate(Resource.Layout.CommentListView, null);

           
            int ImageID = (int)typeof(Resource.Drawable).GetField(SelectedComments.Comments[position].Image).GetValue(null);

            //View                   
            view.FindViewById<ImageView>(Resource.Id.ProfilePicture).SetImageResource(ImageID);
            view.FindViewById<TextView>(Resource.Id.PostDate).Text = (SelectedComments.Comments[position].Date).ToString();
            view.FindViewById<TextView>(Resource.Id.UserName).Text = SelectedComments.Comments[position].UserName;
            view.FindViewById<TextView>(Resource.Id.Comment).Text = SelectedComments.Comments[position].SingleComment;
            return view;        
            
        }
    }
}