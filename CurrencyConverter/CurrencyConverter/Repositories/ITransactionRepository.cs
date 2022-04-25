using CurrencyConverter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public interface ITransactionRepository
    {
        public Task<int> Add(Transaction transaction);
        public Task<List<Transaction>> GetAllTransactions(int userId);
    }
}