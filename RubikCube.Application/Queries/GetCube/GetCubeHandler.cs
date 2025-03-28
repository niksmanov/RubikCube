using MediatR;
using RubikCube.Application.Models;
using RubikCube.Application.Services;
using RubikCube.Core.Handlers;

namespace RubikCube.Application.Queries.GetCube;
public class GetCubeHandler(IProcessCubeService processCubeService) : 
    BaseHandler, IRequestHandler<GetCubeQuery, CubeViewModel?>
{
    public async Task<CubeViewModel?> Handle(GetCubeQuery query, CancellationToken cancellationToken)
    {
        CubeViewModel? result = null;

        try
        {
            var cube = processCubeService.BuildCube();
            result = new CubeViewModel(cube);
        }
        catch (Exception ex)
        {
            LogError($"{ex.InnerException?.Message ?? ex.Message}");
        }

        return await Task.FromResult(result);
    }
}
