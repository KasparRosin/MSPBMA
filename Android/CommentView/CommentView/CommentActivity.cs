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
        public int PostOwnerInt { get; set; }
        static List<SingleCommentProperties> SingleComments = new List<SingleCommentProperties>();
        ListView List;
        EditText SingleComment;        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dateFormat = "dd/MM/yyyy HH:mm:ss";
            SetContentView(Resource.Layout.CommentsRow);
            base.OnCreate(savedInstanceState);

            PostOwnerInt = Intent.GetIntExtra("CommentPosition", 0);
            SingleComment = FindViewById<EditText >(Resource.Id.editText);
            SingleComments.Add(new SingleCommentProperties { UserName = "1p1c", PostOwner = 0 , Image = "JamesBond", SingleComment = "This is first comment of first post", Date = DateTime.Now.ToString(dateFormat)});
            SingleComments.Add(new SingleCommentProperties { UserName = "1p2c", PostOwner = 0, Image = "ElonMusk", SingleComment = "This is second comment of first post", Date = DateTime.Now.ToString(dateFormat)});
            SingleComments.Add(new SingleCommentProperties { UserName = "2p1c", PostOwner = 1, Image = "JamesBond", SingleComment = "This is first comment of second post?", Date = DateTime.Now.ToString(dateFormat) });
            SingleComments.Add(new SingleCommentProperties { UserName = "2p2c", PostOwner = 1, Image = "ElonMusk", SingleComment = "This is second comment of second post", Date = DateTime.Now.ToString(dateFormat) });
            List = FindViewById<ListView>(Resource.Id.ListViewComment);
            List.Adapter = new CommentViewAdapter(this, SingleComments);

        }
    }
}