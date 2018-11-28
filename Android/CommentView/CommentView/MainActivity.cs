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
        dbService dbService = new dbService();
        public string SelectedImage;
        public static int ImageClicks = 0;
        ImageView Image;
        ListView List;
        Button SaveButton;
        protected override void OnCreate( Bundle savedInstanceState )
        {
            SetContentView(Resource.Layout.activity_main);
            base.OnCreate(savedInstanceState);

            DeleteDatabase("db.db3");
            DeleteDatabase("db.db");

            FindViewById<ImageView>(Resource.Id.ProfileImage).SetImageResource(Resource.Drawable.BlankProfile);
            SelectedImage = "BlankProfile";

            List<CommentPropertiesdb> Posts;

            dbService.CreateDatabase();
            Posts = (dbService.GetAllPosts()).ToList();

            SaveButton = FindViewById<Button>(Resource.Id.SaveButton);
            Image = FindViewById<ImageView>(Resource.Id.ProfileImage);
            List = FindViewById<ListView>(Resource.Id.PostsListView);


            List.Adapter = new CustomAdapterdb(this, Posts);

            SaveButton.Click += SaveButton_Click;
            Image.Click += Image_Click;
        }

        private void Image_Click( object sender, EventArgs e )
        {
            switch (ImageClicks)
            {
                case 2:
                    int ImageID2 = (int)typeof(Resource.Drawable).GetField("JamesBond").GetValue(null);
                    Image.SetImageResource(ImageID2);
                    SelectedImage = "JamesBond";
                    ImageClicks++;
                    break;
                case 3:
                    int ImageID3 = (int)typeof(Resource.Drawable).GetField("BlankProfile").GetValue(null);
                    Image.SetImageResource(ImageID3);
                    SelectedImage = "BlankProfile";
                    ImageClicks++;
                    break;
                default:
                    ImageClicks = 1;
                    int ImageID = (int)typeof(Resource.Drawable).GetField("ElonMusk").GetValue(null);
                    Image.SetImageResource(ImageID);
                    SelectedImage = "ElonMusk";
                    ImageClicks++;
                    break;
            }
        }

        private void SaveButton_Click( object sender, EventArgs e )
        {
            var editUserName = FindViewById<EditText>(Resource.Id.editText);
            var editComment = FindViewById<EditText>(Resource.Id.CommentEditText);
            if (editUserName.Text.ToString() != "" && editComment.Text.ToString() != "")
            {

                var newPost = new CommentPropertiesdb()
                {
                    UserName = editUserName.Text.ToString(),
                    Comment = editComment.Text.ToString(),
                    Date = DateTime.Now.ToString(),
                    Image = SelectedImage,
                    Likes = 0
                };
                dbService.AddPost(newPost);
                List<CommentPropertiesdb> Posts = dbService.GetAllPosts().ToList();
                List.Adapter = new CustomAdapterdb(this, Posts);
                editUserName.Text = "";
                editComment.Text = "";
                ImageClicks = 0;
                FindViewById<ImageView>(Resource.Id.ProfileImage).SetImageResource(Resource.Drawable.BlankProfile);
                FindViewById<TextView>(Resource.Id.CharacterLimit).Text = "character limit is 60\nPost Saved!";
            }
            else
            {
                FindViewById<TextView>(Resource.Id.CharacterLimit).Text = "character limit is 60\nPlease Enter Comment & Username";
            }
        }
    }
}