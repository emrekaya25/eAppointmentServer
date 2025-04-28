using Ardalis.SmartEnum;

namespace eAppointmentServer.Domain.Enums;

public sealed class GenderEnum : SmartEnum<GenderEnum>
{
    public static readonly GenderEnum Male = new("Male", 1);
    public static readonly GenderEnum Female = new("Female", 2);
    public GenderEnum(string name, int value) : base(name, value)
    {
    }
}
