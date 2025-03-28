using MediatR;
using RubikCube.Application.Models;
using RubikCube.Application.Services;
using RubikCube.Core.Enumerations;
using RubikCube.Core.Exceptions;
using RubikCube.Core.Handlers;

namespace RubikCube.Application.Commands.RotateCube;
public class RotateCubeHandler(IProcessCubeService processCubeService) : 
    BaseHandler, IRequestHandler<RotateCubeCommand, CubeViewModel>
{
    public async Task<CubeViewModel> Handle(RotateCubeCommand command, CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(CubeRotation), command.Rotation))
            throw new CubeValidationException($"'{command.Rotation}' is not a valid rotation!");

        var cube = processCubeService.BuildCube(command.CurrentCubeState);

        switch (Enum.Parse<CubeRotation>(command.Rotation))
        {
            case CubeRotation.FrontClockwise: processCubeService.RotateFrontClockwise(cube); break;
            case CubeRotation.FrontCounterClockwise: processCubeService.RotateFrontCounterClockwise(cube); break;
            case CubeRotation.BackClockwise: processCubeService.RotateBackClockwise(cube); break;
            case CubeRotation.BackCounterClockwise: processCubeService.RotateBackCounterClockwise(cube); break;
            case CubeRotation.UpClockwise: processCubeService.RotateUpClockwise(cube); break;
            case CubeRotation.UpCounterClockwise: processCubeService.RotateUpCounterClockwise(cube); break;
            case CubeRotation.DownClockwise: processCubeService.RotateDownClockwise(cube); break;
            case CubeRotation.DownCounterClockwise: processCubeService.RotateDownCounterClockwise(cube); break;
            case CubeRotation.LeftClockwise: processCubeService.RotateLeftClockwise(cube); break;
            case CubeRotation.LeftCounterClockwise: processCubeService.RotateLeftCounterClockwise(cube); break;
            case CubeRotation.RightClockwise: processCubeService.RotateRightClockwise(cube); break;
            case CubeRotation.RightCounterClockwise: processCubeService.RotateRightCounterClockwise(cube); break;
            default: LogError($"Rotation '{command.Rotation}' is not supported!"); break;
        }

        return await Task.FromResult(new CubeViewModel(cube));
    }
}
