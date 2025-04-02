using RubikCube.Core.Constants;
using RubikCube.Core.Enumerations;
using RubikCube.Domain.RubikCube;

namespace RubikCube.Application.UnitTest.Common;
public static class UnitTestHelper
{
    public static Cube BuildInitialCube()
    {
        var cube = new Cube();

        cube.SetUpSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));
        cube.SetDownSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));
        cube.SetLeftSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));
        cube.SetRightSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));
        cube.SetFrontSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));
        cube.SetBackSide(new CubeSide(new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE]));

        return cube;
    }
}
