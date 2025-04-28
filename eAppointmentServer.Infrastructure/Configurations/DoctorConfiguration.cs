using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctor");
        builder.Property(x => x.FirstName).HasColumnType("varchar(50)");

        builder.Property(x => x.Department).HasConversion(x => x.Value, x => DepartmentEnum.FromValue(x)).HasColumnName("Department");

        //builder.HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
    }
}