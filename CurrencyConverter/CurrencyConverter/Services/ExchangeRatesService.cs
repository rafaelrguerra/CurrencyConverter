using CurrencyConverter.Tools;
using System.Threading.Tasks;
using static CurrencyConverter.DTO.Rates;

namespace CurrencyConverter.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        public async Task<Root> Rates()
        {
            return await HTTPClientWrapper<Root>.Get("http://api.exchangeratesapi.io/v1/latest?access_key=c350200cd860094cd2eb8fffc7299c55&format=1");
        }
    }
}