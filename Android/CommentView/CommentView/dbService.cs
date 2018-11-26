using System;
using SQLite;
using System.IO;
using System.Collections.Generic;

namespace CommentView
{
    public class dbService
    {
        string DateFormat = "dd/MM/yyyy HH:mm:ss";
        SQLiteConnection db;
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "db.db3");
            db = new SQLiteConnection(dbPath);           
            CreateTable();
        }

        public void CreateTable()
        {
           // db.CreateTable<SingleCommentPropertiesdb>();
            db.CreateTable<CommentPropertiesdb>();
            //var newComment = new  SingleCommentPropertiesdb();
            var newPost = new CommentPropertiesdb();
            if (db.Table<CommentPropertiesdb>().Count() == 0)
            {
                //<! --- POST ---!>
                newPost.UserName = "James";
                newPost.Likes = 10;
                newPost.Image = "JamesBond";
                newPost.Date = DateTime.Now.ToString(DateFormat);
                newPost.Comment = "“You only live twice: Once when you are born And once when you look death in the face” - Myself (James Bond)";
                newPost.PostComments = new List<SingleCommentProperties>
                {
                    new SingleCommentProperties
                    {
                        UserName = "James Bond Fan",
                        Date = DateTime.Now.ToString(DateFormat),
                        Image = "JamesBond",
                        SingleComment = "Nice quote"
                    }
                };
                db.Insert(newPost);


                //<! --- COMMENT ---!>
                //newComment.Date = DateTime.Now.ToString();
                //newComment.SingleComment = "Nice quote";
                //newComment.Image = "JamesBond";
                //newComment.UserName = "James Bond Fan";
                //db.Insert(newComment);


                //<! --- POST ---!>
                newPost.UserName = "Elon";
                newPost.Likes = 105;
                newPost.Image = "ElonMusk";
                newPost.Date = DateTime.Now.ToString(DateFormat);
                newPost.Comment = "Used to live in Silicon Valley, now I live in Silicone Valley";
                newPost.PostComments = new List<SingleCommentProperties>
                {
                    new SingleCommentProperties
                    {
                        UserName = "Anon",
                        Date = DateTime.Now.ToString(DateFormat),
                        Image = "BlankProfile",
                        SingleComment = "Used to live in a House, now I live in a Bigger House"
                    }
                };
                db.Insert(newPost);


                //<! --- COMMENT ---!>
                //newComment.Date = DateTime.Now.ToString();
                //newComment.SingleComment = "Used to live in a House, now I live in a Bigger House";
                //newComment.Image = "BlankProfile";
                //newComment.UserName = "Anon";
                //db.Insert(newComment);

            };
        }

        public TableQuery<CommentPropertiesdb> GetAllPosts()
        {
            var Table = db.Table<CommentPropertiesdb>();
            return Table;
        }

        public TableQuery<SingleCommentPropertiesdb> GetComments()
        {
            var Table = db.Table<SingleCommentPropertiesdb>();
            return Table;
        }
    }
}