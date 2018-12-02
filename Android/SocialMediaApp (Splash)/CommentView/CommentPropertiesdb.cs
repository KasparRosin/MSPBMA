using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CommentView
{
    public class CommentPropertiesdb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Image { get; set; }        
        
        public string UserName { get; set; } = "Invalid Username";

        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public string Comment { get; set; } = "No Comment";

        public int Likes { get; set; }

    }
}