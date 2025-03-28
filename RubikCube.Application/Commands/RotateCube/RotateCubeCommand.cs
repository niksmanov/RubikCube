using MediatR;
using RubikCube.Application.Models;

namespace RubikCube.Application.Commands.RotateCube;
public class RotateCubeCommand : IRequest<CubeViewModel>
{
    public string Rotation { get; set; } = null!;
    public CubeViewModel CurrentCubeState { get; set; } = null!;
}
