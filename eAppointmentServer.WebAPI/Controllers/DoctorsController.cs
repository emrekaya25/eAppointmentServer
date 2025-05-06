using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.DeleteDoctor;
using eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : BaseController
{
    public DoctorsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("GetAllDoctors")]
    public async Task<IActionResult> GetAllDoctors(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return StatusCode(response.StatusCode,response);
    }

    [HttpPost("AddDoctor")]
    public async Task<IActionResult> AddDoctor(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return StatusCode(response.StatusCode,response);
    }

    [HttpPost("DeleteDoctor")]
    public async Task<IActionResult> DeleteDoctor(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);
        return StatusCode(response.StatusCode,response);
    }
}
