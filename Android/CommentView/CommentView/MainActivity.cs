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
        
        ListView List;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_main);
            base.OnCreate(savedInstanceState);  
            
            var dbService = new dbService();
            dbService.CreateDatabase();
            //dbService.CreateTable();

            var Comments = dbService.GetAllPosts();
            List = FindViewById<ListView>(Resource.Id.PostsListView);
            List.Adapter = new CustomAdapterdb(this, Comments.ToList()); 
            //List.Adapter = new CustomAdapter(this, GetPostProperties());
        }
        

        public List<CommentProperties> GetPostProperties()
        {
            string dateFormat = "dd/MM/yyyy HH:mm:ss";
            List<CommentProperties> Comments = new List<CommentProperties>
            {
                new CommentProperties
                {
                    UserName = "James",
                    Image = "JamesBond",
                    Comment = "An Idea?",
                    Date = DateTime.Now.ToString(dateFormat),
                    PostComments = new List<SingleCommentProperties>
                {
                    new SingleCommentProperties
                    {
                        Date = DateTime.Now.ToString(dateFormat),
                        Image = "BlankProfile",
                        UserName = "Happy Meal",
                        SingleComment = "Happy"
                    }
                }
                },
                new CommentProperties
                {
                    UserName = "Elon Musk",
                    Image = "ElonMusk",
                    Comment = "a Joke",
                    Date = DateTime.Now.ToString(dateFormat),
                    PostComments = new List<SingleCommentProperties>
                {
                    new SingleCommentProperties
                    {
                        Date = DateTime.Now.ToString(dateFormat),
                        Image = "BlankProfile",
                        UserName = "Sad Meal",
                        SingleComment = "Sad"
                    }
                }
                }
            };
            return Comments;
        }
    }
}