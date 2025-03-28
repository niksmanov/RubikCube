using MediatR;
using RubikCube.Application.Models;

namespace RubikCube.Application.Queries.GetCube;
public class GetCubeQuery : IRequest<CubeViewModel?>
{ }
