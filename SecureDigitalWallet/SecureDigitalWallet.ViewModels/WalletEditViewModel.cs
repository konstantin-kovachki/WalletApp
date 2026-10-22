using System.ComponentModel.DataAnnotations;

namespace SecureDigitalWallet.ViewModels
{
    using static SecureDigitalWallet.GCommon.ValidationConstants;
    public class WalletEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(WalletNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}
