using API.BLL.DTO;
using API.DAL.Models.Data;
using Microsoft.Extensions.Hosting;

namespace API.BLL.Interfaces
{
    public interface IAccountManager
    {
        public Task CreateReplenishment(User user, int value);
        public Task<Subscribtion> CreateSubscription(User user, int cost, int[] genres);
        public Task<User> GetUser(string username);
        public Task RemoveSubscription(int id, string username);
        public Task<bool> isSubscribed(MovieDTO movie, string? username);
    }
}
