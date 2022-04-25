using System;

namespace CurrencyConverter.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FromCurrency { get; set; }
        public double FromValue { get; set; }
        public string ToCurrency { get; set; }
        public double ConversionRate { get; set; }
        public DateTime UTCTransactionDateTime { get; set; }
    }
}