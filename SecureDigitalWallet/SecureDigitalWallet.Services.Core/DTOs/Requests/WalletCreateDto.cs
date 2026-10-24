namespace SecureDigitalWallet.Services.Core.DTOs.Requests
{
    public class WalletCreateDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int CurrencyAccountId { get; set; }
    }
}
