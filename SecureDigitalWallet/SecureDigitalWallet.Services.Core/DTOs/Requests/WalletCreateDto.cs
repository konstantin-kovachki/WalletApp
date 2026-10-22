namespace SecureDigitalWallet.Services.Core.DTOs.Requests
{
    public class WalletCreateDto
    {
        public string WalletNumber { get; set; } = string.Empty;
        public int CurrencyAccountId { get; set; }
        public decimal Balance { get; set; }
    }
}
