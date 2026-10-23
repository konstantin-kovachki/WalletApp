using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureDigitalWallet.Data.Models;

namespace SecureDigitalWallet.Data.Configuration
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.Property(w => w.Balance)
                .HasPrecision(18, 2);

            builder.HasIndex(w => w.WalletNumber)
           .IsUnique();

            builder.HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
