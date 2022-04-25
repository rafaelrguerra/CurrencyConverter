using CurrencyConverter.Models;
using CurrencyConverter.Tools;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CurrencyConverter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _cn;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _cn = new SqlConnection(_configuration.GetConnectionString("CurrencyConverterDB"));

        }
        public User Get(string username, string password)
        {
            string sql = @"SELECT * FROM Users WHERE Username = @username AND Password = @password";

            var sha256 = new Sha256();
            var hashedPassword = sha256.Hash(password);

            var param = new { Username = username, Password = hashedPassword };

            var user = _cn.Query<User>(sql, param).FirstOrDefault();

            return user;
        }

        public int GetUserId(string username)
        {
            string sql = @"SELECT Id FROM Users WHERE Username = @Username";
            return _cn.QueryFirstOrDefault<int>(sql, new { Username = username });
        }
    }
}