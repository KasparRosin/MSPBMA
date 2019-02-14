using System;
using SQLite;
using System.IO;

namespace FragmentSample
{
    public class dbService
    {
        SQLiteConnection db;
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "db.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<NoteModel>();
            var post = new NoteModel();
            post.Dialogue = "Hello World!";
            post.Title = "Hello World Title";
            if (db.Table<NoteModel>().Count() == 0)
            {
                db.Insert(post);
            }
        }

        public void DeletePost(NoteModel Post2Delete)
        {
           CreateDatabase();
           db.Delete<NoteModel>(Post2Delete.Id);
        }
        public void EditNote(string NewDialogue, int id)
        {
            NoteModel editedNote = new NoteModel();
            editedNote.Id = id;
            editedNote.Title = GetNote(id).Title;
            editedNote.Dialogue = NewDialogue;
            db.Update(editedNote);
        }

        public NoteModel GetNote(int id)
        {
            var table = GetAllPosts();
            foreach (var item in table)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            throw new Exception("empty table");
        }

        public void AddPost(NoteModel Post )
        {           
            db.Insert(Post);
        }

        public TableQuery<NoteModel> GetAllPosts()
        {
            var Table = db.Table<NoteModel>();
            return Table;
        }
    }
}