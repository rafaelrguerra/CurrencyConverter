using CurrencyConverter.DTO;
using CurrencyConverter.Models;
using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using CurrencyConverter.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("v1/ExchangeRates")]
    public class ExchangeRatesController : Controller
    {
        private readonly IExchangeRatesService _exchangeRatesService;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;

        public ExchangeRatesController(IExchangeRatesService exchangeRatesService,
            ITransactionRepository transactionRepository,
            IUserRepository userRepository)
        {
            _exchangeRatesService = exchangeRatesService;
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Authorize]
        [Route("convert")]
        public async Task<ActionResult<double?>> Convert([FromBody] TransactionRequest request)
        {
            var rates = await _exchangeRatesService.Rates();

            var currency = new Currency();
            var toValue = currency.Convert(rates, request);

            if (toValue == null)
                return BadRequest(new { message = "Currency not available." });

            // save in database
            var userId = _userRepository.GetUserId(User.Identity.Name);
            var now = DateTime.UtcNow;
            var transaction = new Transaction
            {
                UserId = userId,
                FromCurrency = request.From,
                FromValue = request.FromValue,
                ToCurrency = request.To,
                UTCTransactionDateTime = now,
                ConversionRate = request.FromValue / (double)toValue
            };
            var transactionId = await _transactionRepository.Add(transaction);

            //generate response dto
            var response = new TransactionResponse
            {
                TransactionId = transactionId,
                UserId = userId,
                FromCurrency = request.From,
                FromValue = request.FromValue,
                ToCurrency = request.To,
                ToValue = (double)toValue,
                ConversionRate = request.FromValue / (double)toValue,
                UTCTransactionDateTime = now
            };

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllTransactions")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            var userId = _userRepository.GetUserId(User.Identity.Name);
            var transactions = await _transactionRepository.GetAllTransactions(userId);
            if (transactions.Count == 0)
                return Ok(new { message = "No transactions found." });
            return Ok(transactions);
        }
    }
}
