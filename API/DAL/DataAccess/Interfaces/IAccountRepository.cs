using API.DAL.Models.Data;

namespace API.DAL.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        public Task CreateReplenishment(User user, int value);
        public Task<Subscribtion> CreateSubscription(User user, int cost, int[] genres);
        public Task<User> GetUser(string username);
        public Task RemoveSubscription(int id, User user);
    }
}
