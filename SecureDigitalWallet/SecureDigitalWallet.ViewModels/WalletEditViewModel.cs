using System.ComponentModel.DataAnnotations;

namespace SecureDigitalWallet.ViewModels
{
    using static SecureDigitalWallet.GCommon.ValidationConstants;
    public class WalletEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a wallet name.")]
        [MaxLength(WalletNameMaxLength, 
            ErrorMessage = "The wallet name can't be longer than {1} characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
