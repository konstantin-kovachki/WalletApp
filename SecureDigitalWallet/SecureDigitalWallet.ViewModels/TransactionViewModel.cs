namespace SecureDigitalWallet.ViewModels
{
    public class TransactionViewModel
    {
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
