using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;
using API.DAL.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private DataContext context;
        public AccountRepository(DataContext context) => this.context = context;

        public async Task CreateReplenishment(User user, int value)
        {
            await context.Replenishments.AddAsync(new Replenishment { User = user, Value = value, Date = DateTime.UtcNow });
        }

        public async Task<Subscribtion> CreateSubscription(User user, int cost, int[] genres)
        {
            var sub = new Subscribtion { User = user, Cost = cost, Genres = genres, RegDate = DateTime.UtcNow, ExpirationTime = DateTime.UtcNow.AddDays(31) };
            var response = context.Subscribtions.Add(sub);
            await context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<User> GetUser(string username)
        {
            return await context.Users.Where(x => x.UserName.Equals(username)).Include(x => x.Subscriptions.Where(i => i.ExpirationTime > DateTime.UtcNow)).SingleAsync();
        }
    }
}
