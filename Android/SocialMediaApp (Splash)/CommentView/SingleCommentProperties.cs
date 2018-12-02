using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace CommentView
{
    public class SingleCommentProperties
    {

        public string Image { get; set; }
        public string UserName { get; set; } = "Invalid Username";
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");        
        public string SingleComment { get; set; } = "No Comment";
    }
}