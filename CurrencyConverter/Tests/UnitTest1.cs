using CurrencyConverter.Controllers;
using CurrencyConverter.DTO;
using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using CurrencyConverter.Tools;
using FakeItEasy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using static CurrencyConverter.DTO.Rates;

namespace Tests
{
    [TestClass]
    public class ExchangeRatesControllerTests
    {
        [TestMethod]
        public void TenReaisToDollars()
        {
            var currency = new Currency();
            Root rates = new Root();

            rates.rates = new Rates();
            rates.rates.EUR = 1.00;
            rates.rates.BRL = 5.21;
            rates.rates.USD = 1.07;

            TransactionRequest tr = new TransactionRequest();
            tr.From = "BRL";
            tr.To = "USD";
            tr.FromValue = 10.0;

            var result = currency.Convert(rates, tr);

            Assert.IsTrue(result < 2.06 && result > 2.04);
        }

        [TestMethod]
        public async Task RequestToExchangeRateApi()
        {
            var exchangeRatesService = A.Fake<IExchangeRatesService>();
            var rates = await exchangeRatesService.Rates();
            Assert.IsNotNull(rates);
        }
    }
}
