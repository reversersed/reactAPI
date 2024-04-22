using API.DAL.Models.Data;

namespace API.BLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public float Rating { get; set; }
        public User user { get; set; }
    }
}
