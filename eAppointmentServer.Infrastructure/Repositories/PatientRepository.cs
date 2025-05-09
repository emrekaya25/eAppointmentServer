﻿using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories.GenericRepositories;

namespace eAppointmentServer.Infrastructure.Repositories;

public sealed class PatientRepository : Repository<Patient, ApplicationDbContext> , IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {

    }
}