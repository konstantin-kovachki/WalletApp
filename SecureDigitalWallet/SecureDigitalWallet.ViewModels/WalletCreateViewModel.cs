using System.ComponentModel.DataAnnotations;

namespace SecureDigitalWallet.ViewModels
{
    using static SecureDigitalWallet.GCommon.ValidationConstants;
    public class WalletCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a wallet name.")]
        [MaxLength(WalletNameMaxLength,
            ErrorMessage = "The wallet name can't be longer than {1} characters.")]
        public string Name { get; set; } = string.Empty;

        public int CurrencyAccountId { get; set; }

        public IEnumerable<CurrencyAccountViewModel> CurrencyAccounts { get; set; }
            = new List<CurrencyAccountViewModel>();
    }
}
