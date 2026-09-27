using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;
using SecureDigitalWallet.Models;

namespace SecureDigitalWallet.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.Property(t => t.Amount)
                .HasPrecision(18, 2);
        }
    }
}
