namespace SecureDigitalWallet.Services.Core.DTOs.Responses
{
    public class WalletDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string WalletNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
