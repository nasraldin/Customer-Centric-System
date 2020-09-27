using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatementService.Core.Entities;

namespace StatementService.Infrastructure.Persistence.Configurations
{
    public class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            builder.Property(e => e.IssueData).IsRequired();

            builder.Property(e => e.AccountId).IsRequired();
        }
    }
}
