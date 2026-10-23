using Microsoft.EntityFrameworkCore;
using SecureDigitalWallet.Data;
using SecureDigitalWallet.Data.Models;
using SecureDigitalWallet.Services.Core.Contracts;
using SecureDigitalWallet.Services.Core.DTOs.Requests;
using SecureDigitalWallet.Services.Core.DTOs.Responses;

namespace SecureDigitalWallet.Services.Core
{
    public class WalletService : IWalletService
    {
        private readonly DigitalWalletDbContext dbContext;

        public WalletService(DigitalWalletDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateWalletAsync(WalletCreateDto dto)
        {
            CurrencyAccount? account = await dbContext.CurrencyAccounts
                .FindAsync(dto.CurrencyAccountId);

            if (account == null)
            {
                return false;
            }

            var wallet = new Wallet
            {
                Name = dto.Name,
                WalletNumber = dto.WalletNumber,
                CurrencyAccountId = account.Id,
                Currency = account.Currency,
                Balance = 0m,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Wallets.Add(wallet);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteWalletAsync(int id)
        {
            Wallet? wallet = await dbContext.Wallets.FindAsync(id);

            if (wallet == null)
            {
                return false;
            }

            dbContext.Wallets.Remove(wallet);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditWalletAsync(WalletEditDto dto)
        {
            Wallet? wallet = await dbContext.Wallets.FindAsync(dto.Id);

            if (wallet == null)
            {
                return false;
            }

            wallet.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CurrencyAccountDto>> GetAllCurrencyAccountsAsync()
        {
            return await dbContext.CurrencyAccounts
            .Select(c => new CurrencyAccountDto
            {
                Id = c.Id,
                Currency = c.Currency,
                Name = c.Name
            })
            .ToListAsync();
        }

        public async Task<IEnumerable<WalletDto>> GetAllWalletsAsync()
        {
            return await dbContext.Wallets
                .OrderByDescending(w => w.CreatedAt)
                .Select(w => new WalletDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    WalletNumber = w.WalletNumber,
                    Currency = w.Currency,
                    Balance = w.Balance,
                    CreatedAt = w.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<WalletDto>> GetLatestWalletsAsync(int count)
        {
            return await dbContext.Wallets
                 .OrderByDescending(w => w.CreatedAt)
                 .Take(count)
                 .Select(w => new WalletDto
                 {
                     Id = w.Id,
                     Name = w.Name,
                     WalletNumber = w.WalletNumber,
                     Currency = w.Currency,
                     Balance = w.Balance,
                     CreatedAt = w.CreatedAt
                 })
                 .ToListAsync();
        }

        public async Task<WalletDto?> GetWalletByIdAsync(int id)
        {
            Wallet? wallet = await dbContext.Wallets.FindAsync(id);

            if (wallet == null)
            {
                return null;
            }

            return new WalletDto
            {
                Id = wallet.Id,
                Name = wallet.Name,
                WalletNumber = wallet.WalletNumber,
                Currency = wallet.Currency,
                Balance = wallet.Balance,
                CreatedAt = wallet.CreatedAt
            };
        }

        public async Task<WalletDetailsDto?> GetWalletDetailsAsync(int id)
        {
            Wallet? wallet = await dbContext.Wallets
                .Include(w => w.Transactions)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (wallet == null)
            {
                return null;
            }

            return new WalletDetailsDto
            {
                Id = wallet.Id,
                Name = wallet.Name,
                WalletNumber = wallet.WalletNumber,
                Currency = wallet.Currency,
                Balance = wallet.Balance,
                CreatedAt = wallet.CreatedAt,
                Transactions = wallet.Transactions
               .OrderByDescending(t => t.CreatedAt)
               .Select(t => new TransactionDto
               {
                   CreatedAt = t.CreatedAt,
                   Type = t.TransactionType.ToString(),
                   Amount = t.Amount,
                   Description = t.Description
               })
               .ToList()
            };
        }

        public async Task<bool> WalletNumberExistsAsync(string walletNumber)
        {
            return await dbContext.Wallets
                .AnyAsync(w => w.WalletNumber == walletNumber);
        }
    }
}
