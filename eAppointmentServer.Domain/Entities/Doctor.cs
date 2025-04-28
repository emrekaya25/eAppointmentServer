using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Domain.Entities;

public sealed class Doctor
{
    public Doctor()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DepartmentEnum Department { get; set; } = DepartmentEnum.EmergencyDepartment; // Default Value
    public IEnumerable<Appointment>? Appointments { get; set; }
}
