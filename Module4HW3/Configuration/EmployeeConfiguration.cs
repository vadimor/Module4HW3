using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.EmployeeId);
            builder.Property(p => p.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.HiredDate).IsRequired().HasMaxLength(7);
            builder.Property(p => p.DateOfBirth).HasColumnType("date");
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();
            builder.HasOne(p => p.Office)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Title)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
