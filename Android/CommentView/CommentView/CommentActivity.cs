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
        string SelectedImage;
        ImageView Image;        
        public static int Clicks = 0;
        private ListView List;     
        protected override void OnCreate(Bundle savedInstanceState)
        {            
            SetContentView(Resource.Layout.CommentsRow);
            base.OnCreate(savedInstanceState);
            FindViewById<ImageView>(Resource.Id.ProfileImage).SetImageResource(Resource.Drawable.BlankProfile);
            SelectedImage = "BlankProfile";
            Button Back = FindViewById<Button>(Resource.Id.BackButton);
            Button Save = FindViewById<Button>(Resource.Id.SaveButton);
            Image = FindViewById<ImageView>(Resource.Id.ProfileImage);            
            List = FindViewById<ListView>(Resource.Id.ListViewComment);
            List.Adapter = new CommentViewAdapter(this, SelectedComments.Comments);

            Image.Click += Image_Click;
            Back.Click += Button_Click;
            Save.Click += Save_Click;
        }

        private void Image_Click(object sender, EventArgs e)
        {
            switch (Clicks)
            {                    
                case 2:
                    int ImageID2 = (int)typeof(Resource.Drawable).GetField("JamesBond").GetValue(null);
                    Image.SetImageResource(ImageID2);
                    SelectedImage = "JamesBond";
                    Clicks++;
                    break;
                case 3:
                    int ImageID3 = (int)typeof(Resource.Drawable).GetField("BlankProfile").GetValue(null);
                    Image.SetImageResource(ImageID3);
                    SelectedImage = "BlankProfile";
                    Clicks++;
                    break;
                default:
                    Clicks = 1;
                    int ImageID = (int)typeof(Resource.Drawable).GetField("ElonMusk").GetValue(null);
                    Image.SetImageResource(ImageID);
                    SelectedImage = "ElonMusk";
                    Clicks++;                    
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {            
            var editUserName = FindViewById<EditText>(Resource.Id.editText);
            var editComment = FindViewById<EditText>(Resource.Id.CommentEditText);
            if (editUserName.Text.ToString() != "" && editComment.Text.ToString() != "")
            {
                SelectedComments.Comments.Add(new SingleCommentProperties
                {
                    Date = DateTime.Now.ToString(),
                    Image = SelectedImage,
                    UserName = editUserName.Text.ToString(),
                    SingleComment = editComment.Text.ToString()                    
                });
                List.Adapter = new CommentViewAdapter(this, SelectedComments.Comments);
                editUserName.Text = "";
                editComment.Text = "";
                Clicks = 0;
                FindViewById<ImageView>(Resource.Id.ProfileImage).SetImageResource(Resource.Drawable.BlankProfile);
                FindViewById<TextView>(Resource.Id.CharacterLimit).Text = "character limit is 60";
            }
            else
            {
                FindViewById<TextView>(Resource.Id.CharacterLimit).Text = "character limit is 60\nPlease Enter Comment & Username";
            }            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SelectedComments.Comments.Clear();
            StartActivity(typeof(MainActivity));
        }
    }
}