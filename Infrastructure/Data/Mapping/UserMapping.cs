using Course.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course.api.Infrastructure.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");
            builder.HasKey(p => p.code);
            builder.Property(p => p.code).ValueGeneratedOnAdd();
            builder.Property(p => p.name);
            builder.Property(p => p.email);
            builder.Property(p => p.password);
        }
    }
}
