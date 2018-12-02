using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentView
{
    public class dbService
    {
        readonly string DateFormat = "dd/MM/yyyy HH:mm:ss";
        SQLiteConnection db;
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "db.db3");
            db = new SQLiteConnection(dbPath);
            CreateTable();            
        }

        public void CreateTable()
        {
            db.CreateTable<CommentPropertiesdb>();
            var newPost = new CommentPropertiesdb();
            if (db.Table<CommentPropertiesdb>().Count() == 0)
            {
                //<! --- POST ---!>
                newPost.UserName = "James";
                newPost.Likes = 10;
                newPost.Image = "JamesBond";
                newPost.Date = DateTime.Now.ToString(DateFormat);
                newPost.Comment = "“You only live twice: Once when you are born And once when you look death in the face” - Myself (James Bond)";         
                db.Insert(newPost);

                //<! --- POST ---!>
                newPost.UserName = "Elon";
                newPost.Likes = 105;
                newPost.Image = "ElonMusk";
                newPost.Date = DateTime.Now.ToString(DateFormat);
                newPost.Comment = "Used to live in Silicon Valley, now I live in Silicone Valley";
                db.Insert(newPost);
            };
        }

        public void DeletePost( CommentPropertiesdb Post2Delete )
        {
           CreateDatabase();
           db.Delete<CommentPropertiesdb>(Post2Delete.Id);
        }

        public void AddPost( CommentPropertiesdb Post )
        {           
            db.Insert(Post);
        }

        public TableQuery<CommentPropertiesdb> GetAllPosts()
        {
            var Table = db.Table<CommentPropertiesdb>();
            return Table;
        }
    }
}