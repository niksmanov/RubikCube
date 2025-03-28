using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using RubikCube.Application.Queries.GetCube;
using RubikCube.Core.Controllers;
using RubikCube.Application.Models;
using RubikCube.Core.Constants;
using RubikCube.Application.Commands.RotateCube;
using RubikCube.Api.Controllers.Examples.Request;
using RubikCube.Api.Controllers.Examples.Response;

namespace RubikCube.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CubeController(IMemoryCache cache, IMediator mediator) : BaseController(mediator)
{
    [HttpGet("get-cube")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetCubeResponseExample))]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CubeViewModel))]
    public async Task<IActionResult> GetCube()
    {
        var result = await SendRequest(new GetCubeQuery());

        if (result == null)
            return NotFound();

        cache.Set(CubeConstants.CUBE_CACHE_KEY, result, CubeConstants.CUBE_CACHE_TIME);
        return Ok(result);
    }

    [HttpPut("rotate-cube")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerRequestExample(typeof(string), typeof(RotateCubeRequestExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetCubeResponseExample))]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CubeViewModel))]
    public async Task<IActionResult> RotateCube([FromBody] string rotation)
    {
        var cube = cache.Get(CubeConstants.CUBE_CACHE_KEY) as CubeViewModel;

        if (cube == null)
            cube = await SendRequest(new GetCubeQuery());

        var command = new RotateCubeCommand
        {
            Rotation = rotation,
            CurrentCubeState = cube!
        };

        var result = await SendRequest(command);

        if (result == null)
            return NotFound();

        cache.Set(CubeConstants.CUBE_CACHE_KEY, result, CubeConstants.CUBE_CACHE_TIME);
        return Ok(result);
    }
}

