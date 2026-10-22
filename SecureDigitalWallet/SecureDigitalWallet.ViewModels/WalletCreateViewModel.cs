using System.ComponentModel.DataAnnotations;

namespace SecureDigitalWallet.ViewModels
{
    using static SecureDigitalWallet.GCommon.ValidationConstants;
    public class WalletCreateViewModel
    {
        [Required]
        [MaxLength(WalletNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(WalletNumberMaxLength)]
        public string WalletNumber { get; set; } = string.Empty;

        public int CurrencyAccountId { get; set; }

        public IEnumerable<CurrencyAccountViewModel> CurrencyAccounts { get; set; }
            = new List<CurrencyAccountViewModel>();
    }
}
