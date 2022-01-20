using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entity;

namespace Module4HW3.Configuration
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(p => p.EmployeeProjectId);
            builder.Property(p => p.EmployeeProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.Rate).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired().HasMaxLength(7);
            builder.Property(p => p.EmployeeId).IsRequired();
            builder.Property(p => p.ProjectId).IsRequired();

            builder.HasOne(p => p.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Employee)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
