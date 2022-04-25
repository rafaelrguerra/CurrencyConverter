using CurrencyConverter.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _cn;

        public TransactionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _cn = new SqlConnection(_configuration.GetConnectionString("CurrencyConverterDB"));
        }
        public async Task<int> Add(Transaction transaction)
        {
            string sql = @"INSERT INTO Transactions 
                            VALUES (@UserId, 
                            @FromCurrency, 
                            @FromValue, 
                            @ToCurrency, 
                            @ConversionRate, 
                            @UTCTransactionDateTime) 
                            SELECT CAST (SCOPE_IDENTITY() AS INT)";

            var param = new
            {
                UserId = transaction.UserId,
                FromCurrency = transaction.FromCurrency,
                FromValue = transaction.FromValue,
                ToCurrency = transaction.ToCurrency,
                ConversionRate = transaction.ConversionRate,
                UTCTransactionDateTime = transaction.UTCTransactionDateTime
            };

            //await _cn.ExecuteAsync(sql, new { transaction });

            var id = await _cn.QuerySingleAsync<int>(sql, param);
            return id;
        }

        public async Task<List<Transaction>> GetAllTransactions(int userId)
        {
            var sql = @"SELECT * FROM Transactions WHERE UserId = @UserId";
            var transactions = (await _cn.QueryAsync<Transaction>(sql, new { UserId = userId})).ToList();
            return transactions;
        }
    }
}