using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.DataAccess.Interfaces;
using API.DAL.Models.Data;

namespace API.BLL
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository accountRepository;
        public AccountManager(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task CreateReplenishment(User user, int value)
        {
            await accountRepository.CreateReplenishment(user, value);
        }

        public async Task<Subscribtion> CreateSubscription(User user, int cost, int[] genres)
        {
            return await accountRepository.CreateSubscription(user, cost, genres);
        }

        public async Task<User> GetUser(string username)
        {
            return await accountRepository.GetUser(username);
        }

        public async Task<bool> isSubscribed(MovieDTO movie, string? username)
        {
            if(username == null)
                return false;
            var user = await accountRepository.GetUser(username);
            if (user == null)
                return false;
            bool isSubscribed = false;
            user.Subscriptions.ToList().ForEach(sub =>
            {
                if(!isSubscribed)
                    sub.Genres.ToList().ForEach(genre =>
                    {
                        if (movie.Genres.Where(i => i.Id == genre).Any())
                            isSubscribed = true;
                    });
            });
            return isSubscribed;
        }

        public async Task RemoveSubscription(int id, string username)
        {
            var user = await accountRepository.GetUser(username); 
            if (!user.Subscriptions.Where(i => i.Id == id).Any())
                return;
            await accountRepository.RemoveSubscription(id, user);
        }
    }
}
