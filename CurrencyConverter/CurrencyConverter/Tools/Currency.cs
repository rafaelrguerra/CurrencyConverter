using CurrencyConverter.DTO;
using System;
using static CurrencyConverter.DTO.Rates;

namespace CurrencyConverter.Tools
{
    public class Currency
    {
        public double? Convert(Root rates, TransactionRequest request)
        {
            try
            {
                var fromCurrency = (double?)rates.rates.GetType().GetProperty(request.From).GetValue(rates.rates, null);
                var toCurrency = (double?)rates.rates.GetType().GetProperty(request.To).GetValue(rates.rates, null);

                if (fromCurrency == null || toCurrency == null)
                    return null;

                var euros = request.FromValue / fromCurrency;

                var toValue = euros * toCurrency;

                return toValue;
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }
    }
}