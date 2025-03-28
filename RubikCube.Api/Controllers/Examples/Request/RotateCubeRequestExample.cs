using RubikCube.Core.Enumerations;
using Swashbuckle.AspNetCore.Filters;

namespace RubikCube.Api.Controllers.Examples.Request;
public class RotateCubeRequestExample : IExamplesProvider<string>
{
    public string GetExamples()
    {
        var rotations = Enum.GetNames(typeof(CubeRotation));
        var random = new Random();

        return rotations[random.Next(rotations.Length)];
    }
}
