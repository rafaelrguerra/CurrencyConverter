using CurrencyConverter.Models;

namespace CurrencyConverter.Repositories
{
    public interface IUserRepository
    {
        public User Get(string username, string password);
        public int GetUserId(string username);
    }
}
