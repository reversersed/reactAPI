using Microsoft.AspNetCore.Identity;

namespace API.DAL.Models.Data
{
    public class User : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
