using System;

namespace CommentView
{
    public class CommentProperties
    {
        public string Image { get; set; }
        public string UserName { get; set; } = "Invalid Username";
        public string Date { get; set; } = DateTime.Now.ToString();
        public string Comment { get; set; } = "No Comment";

        public int Likes { get; set; }
    }
}