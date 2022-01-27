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
            builder.Property(p => p.EmployeeId).ValueGeneratedNever();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.SecondName).IsRequired().HasMaxLength(50);
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

            builder.HasData(new EmployeeEntity[]
            {
                new EmployeeEntity { EmployeeId = 1, FirstName = "Vadim", SecondName = "Bilyi", HiredDate = new System.DateTime(2017, 3, 21), OfficeId = 1, TitleId = 1 },
                new EmployeeEntity { EmployeeId = 2, FirstName = "Dima", SecondName = "Menshacov", HiredDate = new System.DateTime(2017, 3, 21), OfficeId = 1, TitleId = 2 },
                new EmployeeEntity { EmployeeId = 3, FirstName = "Dima", SecondName = "Yampolski", HiredDate = new System.DateTime(2017, 3, 21), OfficeId = 1, TitleId = 2 },
                new EmployeeEntity { EmployeeId = 4, FirstName = "Lil", SecondName = "Vodil", HiredDate = new System.DateTime(2017, 3, 21), OfficeId = 1, TitleId = 2 }
            });
        }
    }
}
