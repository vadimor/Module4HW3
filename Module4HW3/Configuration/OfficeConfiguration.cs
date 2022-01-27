using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.OfficeId).ValueGeneratedNever();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(100);

            builder.HasData(new OfficeEntity { OfficeId = 1, Location = "Berislav", Title = "D5" });
        }
    }
}
