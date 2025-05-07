using eAppointmentServer.Application.Features.Patients.CreatePatient;
using eAppointmentServer.Application.Features.Patients.DeletePatient;
using eAppointmentServer.Application.Features.Patients.GetAllPatient;
using eAppointmentServer.Application.Features.Patients.UpdatePatient;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : BaseController
{
    public PatientsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("GetAllPatients")]
    public async Task<IActionResult> GetAllPatients(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return StatusCode(response.StatusCode,response);
    }

    [HttpPost("AddPatient")]
    public async Task<IActionResult> AddPatient(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return StatusCode(response.StatusCode,response);
    }

    [HttpPost("DeletePatient")]
    public async Task<IActionResult> DeletePatient(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode,response);
    }

    [HttpPost("UpdatePatient")]
    public async Task<IActionResult> UpdatePatient(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode,response);
    }
}
