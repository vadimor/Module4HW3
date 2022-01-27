using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.Configuration
{
    public class TitleConfiguration : IEntityTypeConfiguration<TitleEntity>
    {
        public void Configure(EntityTypeBuilder<TitleEntity> builder)
        {
            builder.ToTable("Title").HasKey(p => p.TitleId);
            builder.Property(p => p.TitleId).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new TitleEntity[]
            {
                new TitleEntity { TitleId = 1, Name = "CEO" },
                new TitleEntity { TitleId = 2, Name = "Programmer" }
            });
        }
    }
}
