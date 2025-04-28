using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;

internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patient");
        builder.Property(x => x.FirstName).HasColumnType("varchar(50)");
        builder.Property(x => x.LastName).HasColumnType("varchar(50)");
        builder.HasIndex(x => x.IdentityNumber).IsUnique();
        builder.Property(x => x.IdentityNumber).HasColumnType("varchar(11)");
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
        builder.Property(x => x.PhoneNumber).HasColumnType("varchar(11)");

        builder.Property(x => x.Gender).HasConversion(x => x!.Value, x => GenderEnum.FromValue(x)).HasColumnName("Gender"); // smartEnumların okunması içi böyle bir şey yapmamız gerekiyor.
    }
}