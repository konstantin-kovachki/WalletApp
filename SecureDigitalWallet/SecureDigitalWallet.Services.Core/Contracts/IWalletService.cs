using SecureDigitalWallet.Services.Core.DTOs.Requests;
using SecureDigitalWallet.Services.Core.DTOs.Responses;

namespace SecureDigitalWallet.Services.Core.Contracts
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletDto>> GetAllWalletsAsync(string userId);

        Task<IEnumerable<WalletDto>> GetLatestWalletsAsync(int count, string userId);

        Task<WalletDetailsDto?> GetWalletDetailsAsync(int id, string userId);

        Task<WalletDto?> GetWalletByIdAsync(int id, string userId);

        Task<IEnumerable<CurrencyAccountDto>> GetAllCurrencyAccountsAsync();

        Task<bool> CreateWalletAsync(WalletCreateDto dto);

        Task<bool> EditWalletAsync(WalletEditDto dto);

        Task<bool> DeleteWalletAsync(int id, string userId);
    }
}
