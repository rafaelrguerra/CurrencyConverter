using System.Threading.Tasks;
using static CurrencyConverter.DTO.Rates;

namespace CurrencyConverter.Services
{
    public interface IExchangeRatesService
    {
        public Task<Root> Rates();
    }
}