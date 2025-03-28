using RubikCube.Application.Models;
using RubikCube.Core.Constants;
using RubikCube.Core.Enumerations;
using Swashbuckle.AspNetCore.Filters;

namespace RubikCube.Api.Controllers.Examples.Response;

public class GetCubeResponseExample : IExamplesProvider<CubeViewModel>
{
    public CubeViewModel GetExamples()
    {
        var colors = Enum.GetNames(typeof(CubeColor));
        var random = new Random();

        return new()
        {
            FrontSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
            BackSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
            UpSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
            DownSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
            LeftSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
            RightSide = new()
            {
                Facelets = new[] {
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                    new CubeFaceletViewModel {
                        Color = colors[random.Next(colors.Length)],
                        Row = random.Next(CubeConstants.DEFAULT_CUBE_SIZE),
                        Column = random.Next(CubeConstants.DEFAULT_CUBE_SIZE)
                    },
                }
            },
        };
    }
}
