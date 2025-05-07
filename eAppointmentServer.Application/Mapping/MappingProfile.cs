using AutoMapper;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Application.Features.Patients.UpdatePatient;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Doctor
        CreateMap<UpdateDoctorCommand, Doctor>()
            .ForMember(dest => dest.Department, src =>
            {
                src.MapFrom(x => DepartmentEnum.FromValue(x.DepartmentValue));
            });
        CreateMap<Doctor, UpdateDoctorCommand>()
            .ForMember(dest => dest.DepartmentValue, src =>
            {
                src.MapFrom(x => DepartmentEnum.FromValue(x.Department));
            });

        //Patient
        CreateMap<UpdatePatientCommand, Patient>()
            .ForMember(dest => dest.Gender, src =>
            {
                src.MapFrom(x => GenderEnum.FromValue(x.GenderValue));
            });
        CreateMap<Patient, UpdatePatientCommand>()
            .ForMember(dest => dest.GenderValue, src =>
            {
                src.MapFrom(x => GenderEnum.FromValue(x.Gender));
            });
    }
}
