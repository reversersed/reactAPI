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

        public Task<Subscribtion> CreateSubscription(User user, int cost, int[] genres)
        {
            return accountRepository.CreateSubscription(user, cost, genres);
        }

        public Task<User> GetUser(string username)
        {
            return accountRepository.GetUser(username);
        }
    }
}
