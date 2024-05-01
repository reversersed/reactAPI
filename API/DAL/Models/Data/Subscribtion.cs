using System.ComponentModel.DataAnnotations;

namespace API.DAL.Models.Data
{
    public class Subscribtion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        public int[] Genres { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int Cost { get; set; }
    }
}
