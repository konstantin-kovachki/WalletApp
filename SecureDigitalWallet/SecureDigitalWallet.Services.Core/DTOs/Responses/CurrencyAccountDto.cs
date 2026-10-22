namespace SecureDigitalWallet.Services.Core.DTOs.Responses
{
    public class CurrencyAccountDto
    {
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
