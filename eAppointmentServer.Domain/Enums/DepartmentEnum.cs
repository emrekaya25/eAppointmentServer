using Ardalis.SmartEnum;

namespace eAppointmentServer.Domain.Enums;

public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    public static readonly DepartmentEnum EmergencyDepartment = new("Acil Servis", 1);
    public static readonly DepartmentEnum Neurosurgery = new("Beyin ve Sinir Cerrahisi",2);
    public static readonly DepartmentEnum Endocrinology = new("Endokrinoloji",3);
    public static readonly DepartmentEnum Dermatology = new("Dermatoloji",4);
    public static readonly DepartmentEnum Cardiology = new("Kardiyoloji",5);
    public static readonly DepartmentEnum Neurology = new("Nöroloji", 6);
    public static readonly DepartmentEnum MentalHealth = new("Ruh Sağlığı ve Hastalıkları",7);
    public DepartmentEnum(string name, int value) : base(name, value)
    {
    }
}
