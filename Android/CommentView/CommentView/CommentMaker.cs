using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommentView
{
    public class CommentMaker
    {
        public static List<CommentProperties> GetComments()
        {
            List<CommentProperties> CommentList = new List<CommentProperties>
            {
                new CommentProperties { Image = "TestImage", UserName = "TestUserName", Date = DateTime.Now.ToString(), Comment = "TestComment" }
            };

            return CommentList;
        }
    }
}