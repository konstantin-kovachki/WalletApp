using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureDigitalWallet.Data.Models
{
    using static SecureDigitalWallet.GCommon.ValidationConstants;
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(WalletNameMaxLength)]
        public string Name { get; set; } = string.Empty;

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

        public List<WalletTransaction> Transactions { get; set; }
            = new List<WalletTransaction>();
    }
}
