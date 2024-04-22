using System.ComponentModel.DataAnnotations;

namespace API.DAL.Models.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public double Rating { get; set; }
        [Required]
        public Movie movie { get; set; }
        [Required]
        public User user { get; set; }
        public string Text { get; set; }
    }
}
