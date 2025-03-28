using RubikCube.Application.Models;
using RubikCube.Core.Constants;
using RubikCube.Core.Enumerations;
using RubikCube.Domain.RubikCube;

namespace RubikCube.Application.Services;
public class ProcessCubeService : IProcessCubeService
{
    public Cube BuildCube()
    {
        var result = new Cube();

        result.SetUpSide(BuildCubeSide(CubeColor.White));
        result.SetDownSide(BuildCubeSide(CubeColor.Yellow));
        result.SetLeftSide(BuildCubeSide(CubeColor.Orange));
        result.SetRightSide(BuildCubeSide(CubeColor.Red));
        result.SetFrontSide(BuildCubeSide(CubeColor.Green));
        result.SetBackSide(BuildCubeSide(CubeColor.Blue));

        return result;
    }

    public Cube BuildCube(CubeViewModel cube)
    {
        var result = new Cube();

        result.SetUpSide(BuildCubeSide(cube.UpSide));
        result.SetDownSide(BuildCubeSide(cube.DownSide));
        result.SetLeftSide(BuildCubeSide(cube.LeftSide));
        result.SetRightSide(BuildCubeSide(cube.RightSide));
        result.SetFrontSide(BuildCubeSide(cube.FrontSide));
        result.SetBackSide(BuildCubeSide(cube.BackSide));

        return result;
    }

    private static CubeSide BuildCubeSide(CubeSideViewModel cubeSide)
    {
        var facelets = new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE];

        foreach (var item in cubeSide.Facelets)
        {
            Enum.TryParse(item.Color, out CubeColor enumValue);
            facelets[item.Row, item.Column] = enumValue;
        }

        return new CubeSide(facelets);
    }

    private static void RotateClockwise(CubeSide side)
    {
        var rowSize = side.Facelets.GetLength(0);
        var colSize = side.Facelets.GetLength(1);

        var tempFacelets = new CubeColor[rowSize, colSize];

        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                tempFacelets[col, 2 - row] = side.Facelets[row, col];
            }
        }

        side.SetFacelets(tempFacelets);
    }

    private static CubeSide BuildCubeSide(CubeColor color)
    {
        var facelets = new CubeColor[CubeConstants.DEFAULT_CUBE_SIZE, CubeConstants.DEFAULT_CUBE_SIZE];

        for (int row = 0; row < CubeConstants.DEFAULT_CUBE_SIZE; row++)
        {
            for (int col = 0; col < CubeConstants.DEFAULT_CUBE_SIZE; col++)
            {
                facelets[row, col] = color;
            }
        }

        return new CubeSide(facelets);
    }

    private static CubeColor[] GetRow(CubeSide side, int row) =>
        [ side.GetFacelet(row, 0),
          side.GetFacelet(row, 1),
          side.GetFacelet(row, 2) ];

    private static void SetRow(CubeSide side, int row, CubeColor[] rowColors)
    {
        side.SetFacelet(row, 0, rowColors[0]);
        side.SetFacelet(row, 1, rowColors[1]);
        side.SetFacelet(row, 2, rowColors[2]);
    }

    private static CubeColor[] GetColumn(CubeSide side, int col) =>
        [ side.GetFacelet(0, col),
          side.GetFacelet(1, col),
          side.GetFacelet(2, col) ];

    private static void SetColumn(CubeSide side, int col, CubeColor[] colColors)
    {
        side.SetFacelet(0, col, colColors[0]);
        side.SetFacelet(1, col, colColors[1]);
        side.SetFacelet(2, col, colColors[2]);
    }

    #region Cube sides rotation

    #region Front side
    public void RotateFrontClockwise(Cube cube)
    {
        RotateClockwise(cube.FrontSide);

        var row = GetRow(cube.UpSide, 2);
        SetRow(cube.UpSide, 2, GetColumn(cube.LeftSide, 2).Reverse().ToArray());
        SetColumn(cube.LeftSide, 2, GetRow(cube.DownSide, 0));
        SetRow(cube.DownSide, 0, GetColumn(cube.RightSide, 0).Reverse().ToArray());
        SetColumn(cube.RightSide, 0, row);
    }

    public void RotateFrontCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateFrontClockwise(cube);
        }
    }
    #endregion

    #region Back side
    public void RotateBackClockwise(Cube cube)
    {
        RotateClockwise(cube.BackSide);

        var row = GetRow(cube.UpSide, 0);
        SetRow(cube.UpSide, 0, GetColumn(cube.RightSide, 2));
        SetColumn(cube.RightSide, 2, GetRow(cube.DownSide, 2).Reverse().ToArray());
        SetRow(cube.DownSide, 2, GetColumn(cube.LeftSide, 0));
        SetColumn(cube.LeftSide, 0, row.Reverse().ToArray());
    }

    public void RotateBackCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateBackClockwise(cube);
        }
    }
    #endregion

    #region Up side
    public void RotateUpClockwise(Cube cube)
    {
        RotateClockwise(cube.UpSide);

        var row = GetRow(cube.FrontSide, 0);
        SetRow(cube.FrontSide, 0, GetRow(cube.RightSide, 0));
        SetRow(cube.RightSide, 0, GetRow(cube.BackSide, 0));
        SetRow(cube.BackSide, 0, GetRow(cube.LeftSide, 0));
        SetRow(cube.LeftSide, 0, row);
    }

    public void RotateUpCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateUpClockwise(cube);
        }
    }
    #endregion

    #region Down side
    public void RotateDownClockwise(Cube cube)
    {
        RotateClockwise(cube.DownSide);

        var row = GetRow(cube.FrontSide, 2);
        SetRow(cube.FrontSide, 2, GetRow(cube.LeftSide, 2));
        SetRow(cube.LeftSide, 2, GetRow(cube.BackSide, 2));
        SetRow(cube.BackSide, 2, GetRow(cube.RightSide, 2));
        SetRow(cube.RightSide, 2, row);
    }

    public void RotateDownCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateDownClockwise(cube);
        }
    }
    #endregion

    #region Left side
    public void RotateLeftClockwise(Cube cube)
    {
        RotateClockwise(cube.LeftSide);

        var row = GetColumn(cube.UpSide, 0);
        SetColumn(cube.UpSide, 0, GetColumn(cube.BackSide, 2).Reverse().ToArray());
        SetColumn(cube.BackSide, 2, GetColumn(cube.DownSide, 0).Reverse().ToArray());
        SetColumn(cube.DownSide, 0, GetColumn(cube.FrontSide, 0));
        SetColumn(cube.FrontSide, 0, row);
    }

    public void RotateLeftCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateLeftClockwise(cube);
        }
    }
    #endregion

    #region Right side
    public void RotateRightClockwise(Cube cube)
    {
        RotateClockwise(cube.RightSide);

        var row = GetColumn(cube.UpSide, 2);
        SetColumn(cube.UpSide, 2, GetColumn(cube.FrontSide, 2));
        SetColumn(cube.FrontSide, 2, GetColumn(cube.DownSide, 2));
        SetColumn(cube.DownSide, 2, GetColumn(cube.BackSide, 0).Reverse().ToArray());
        SetColumn(cube.BackSide, 0, row.Reverse().ToArray());
    }

    public void RotateRightCounterClockwise(Cube cube)
    {
        for (int i = 0; i < 3; i++)
        {
            RotateRightClockwise(cube);
        }
    }
    #endregion

    #endregion
}
