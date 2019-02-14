using SQLite;

namespace FragmentSample
{
    public class NoteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Dialogue { get; set; }
    }
}