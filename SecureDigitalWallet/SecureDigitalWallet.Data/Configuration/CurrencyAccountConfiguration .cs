using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureDigitalWallet.Data.Models;

namespace SecureDigitalWallet.Data.Configuration
{
    public class CurrencyAccountConfiguration : IEntityTypeConfiguration<CurrencyAccount>
    {
        public void Configure(EntityTypeBuilder<CurrencyAccount> builder)
        {
            builder.HasData(
            new CurrencyAccount { Id = 1, Currency = "EUR", Name = "Euro" },
            new CurrencyAccount { Id = 2, Currency = "USD", Name = "US Dollar" },
            new CurrencyAccount { Id = 3, Currency = "BGN", Name = "Bulgarian Lev" },
            new CurrencyAccount { Id = 4, Currency = "GBP", Name = "British Pound" });
        }
    }
}
