using Microsoft.AspNetCore.Identity;

namespace API.DAL.Models.Data
{
    public class User : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public int Balance { get; set; }
        public ICollection<Subscribtion> Subscriptions { get; set; } = new List<Subscribtion>();
        public ICollection<Replenishment> Replenishments { get; set; } = new List<Replenishment>();
    }
}
