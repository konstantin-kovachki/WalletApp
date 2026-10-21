using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureDigitalWallet.Data.Models;

namespace SecureDigitalWallet.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Models.WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.Property(t => t.Amount)
                .HasPrecision(18, 2);
        }
    }
}
