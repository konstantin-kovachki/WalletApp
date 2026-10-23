namespace SecureDigitalWallet.Services.Core.DTOs.Requests
{
    public class WalletEditDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
