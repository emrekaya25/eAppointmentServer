using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Domain.Entities;

public sealed class Patient
{
    public Patient()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public GenderEnum? Gender { get; set; } = GenderEnum.NoChoice;
    public IEnumerable<Appointment>? Appointments { get; set; }
    public string IdentityNumber { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Town { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
