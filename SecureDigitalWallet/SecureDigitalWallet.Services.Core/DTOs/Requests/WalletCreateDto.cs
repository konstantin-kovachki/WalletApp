namespace SecureDigitalWallet.Services.Core.DTOs.Requests
{
    public class WalletCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string WalletNumber { get; set; } = string.Empty;
        public int CurrencyAccountId { get; set; }
    }
}
