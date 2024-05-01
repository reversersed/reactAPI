namespace API.DAL.Models.Data
{
    public class Replenishment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
