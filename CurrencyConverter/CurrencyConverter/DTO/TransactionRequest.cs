namespace CurrencyConverter.DTO
{
    public class TransactionRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public double FromValue { get; set; }
    }
}