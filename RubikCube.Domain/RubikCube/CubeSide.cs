using RubikCube.Core.Enumerations;

namespace RubikCube.Domain.RubikCube;
public class CubeSide(CubeColor[,] facelets)
{
    public CubeColor[,] Facelets { get; private set; } = facelets;

    public void SetFacelets(CubeColor[,] facelets) => Facelets = facelets;
    public void SetFacelet(int row, int col, CubeColor color) => Facelets[row, col] = color;
    public CubeColor GetFacelet(int row, int col) => Facelets[row, col];
}
