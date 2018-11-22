using SQLite;


namespace dbExample
{
    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
        
    }
}