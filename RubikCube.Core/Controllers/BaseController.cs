using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RubikCube.Core.Controllers;

public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected Task<T> SendRequest<T>(IRequest<T> request)
    {
        return mediator.Send(request, HttpContext.RequestAborted);
    }
}
