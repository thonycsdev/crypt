using Crypt.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crypt.Repository.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Document);
            builder.HasOne(x => x.CreditCard);
            builder.Property(x => x.Value).IsRequired();
        }
    }
}
