using System;

namespace CurrencyConverter.DTO
{
    public class TransactionResponse
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string FromCurrency { get; set; }
        public double FromValue { get; set; }
        public string ToCurrency { get; set; }
        public double ToValue { get; set; }
        public double ConversionRate { get; set; }
        public DateTime UTCTransactionDateTime { get; set; }
    }
}
