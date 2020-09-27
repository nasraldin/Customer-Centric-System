using AccountService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.Number).IsRequired();

            builder.Property(e => e.Type).HasMaxLength(40);

            builder.Property(e => e.CustomerId).IsRequired();
        }
    }
}
