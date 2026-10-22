namespace SecureDigitalWallet.Services.Core.DTOs.Responses
{
    public class TransactionDto
    {
        public DateTime CreatedAt { get; set; }

        public string Type { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string? Description { get; set; }
    }
}
