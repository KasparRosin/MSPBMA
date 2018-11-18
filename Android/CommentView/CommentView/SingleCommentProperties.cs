using System;

namespace CommentView
{
    public class SingleCommentProperties
    {
        public string Image { get; set; }
        public string UserName { get; set; } = "Invalid Username";
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");        
        public string SingleComment { get; set; } = "No Comment";
        public int PostOwner { get; set; }
    }
}