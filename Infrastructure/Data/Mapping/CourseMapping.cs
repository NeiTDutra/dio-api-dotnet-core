using Course.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course.api.Infrastructure.Data.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Current>
    {
        public void Configure(EntityTypeBuilder<Current> builder)
        {
            builder.ToTable("tb_course");
            builder.HasKey(p => p.code);
            builder.Property(p => p.code).ValueGeneratedOnAdd();
            builder.Property(p => p.name);
            builder.Property(p => p.description);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.codeUser);

        }
    }
}
