using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController : ControllerBase // Abstract yapıyoruz ki tek başına newlenemesin veya kullanılamasın inherit edilmek zorunda olsun.
{
    public readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
