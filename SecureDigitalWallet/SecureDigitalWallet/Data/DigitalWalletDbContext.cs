using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureDigitalWallet.Models;
using System.Transactions;

namespace SecureDigitalWallet.Data
{
    public class DigitalWalletDbContext : IdentityDbContext
    {
        public DigitalWalletDbContext(DbContextOptions<DigitalWalletDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<CurrencyAccount> CurrencyAccounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeo(DigitalWalletDbContext).Assembly)
        }
}
