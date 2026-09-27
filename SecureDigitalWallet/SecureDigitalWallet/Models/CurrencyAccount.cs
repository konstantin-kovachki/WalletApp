using System.ComponentModel.DataAnnotations;

namespace SecureDigitalWallet.Models
{
    using static Common.EntityValidation;

    public class CurrencyAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CurrencyMaxLength)]
        public string Currency { get; set; } = null!;

        [Required]
        [MaxLength(CurrencyNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
