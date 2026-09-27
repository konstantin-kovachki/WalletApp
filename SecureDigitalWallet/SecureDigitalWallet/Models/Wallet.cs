using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureDigitalWallet.Models
{
    using static Common.EntityValidation;
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(WalletNumberMaxLength)]
        public string WalletNumber { get; set; } = null!;

        [Required]
        [MaxLength(WalletCurrencyMaxLength)]
        public string Currency { get; set; } = null!;

        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(CurrencyAccount))]
        public int CurrencyAccountId { get; set; }

        public CurrencyAccount? CurrencyAccount { get; set; }


    }
}
