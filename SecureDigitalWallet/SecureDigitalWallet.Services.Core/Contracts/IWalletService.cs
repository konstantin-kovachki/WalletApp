using SecureDigitalWallet.Services.Core.DTOs.Requests;
using SecureDigitalWallet.Services.Core.DTOs.Responses;

namespace SecureDigitalWallet.Services.Core.Contracts
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletDto>> GetAllWalletsAsync();

        Task<WalletDetailsDto?> GetWalletDetailsAsync(int id);

        Task<WalletDto?> GetWalletByIdAsync(int id);

        Task<IEnumerable<CurrencyAccountDto>> GetAllCurrencyAccountsAsync();

        Task<bool> WalletNumberExistsAsync(string walletNumber);

        Task<bool> CreateWalletAsync(WalletCreateDto dto);

        Task<bool> EditWalletAsync(WalletEditDto dto);

        Task<bool> DeleteWalletAsync(int id);
    }
}
