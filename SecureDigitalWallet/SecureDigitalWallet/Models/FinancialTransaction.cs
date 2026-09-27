using SecureDigitalWallet.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace SecureDigitalWallet.Models
{
    using static Common.EntityValidation;
    public class FinancialTransaction
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(TransactionDescriptionMaxLength)]
        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public TransactionType MyProperty { get; set; }

        [ForeignKey(nameof(Wallet))]
        public int WalletId { get; set; }

        public Wallet? Wallet { get; set; }

    }
}
