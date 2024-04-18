using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;

namespace API.DAL.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private DataContext context;
        public AccountRepository(DataContext context) => this.context = context;
    }
}
