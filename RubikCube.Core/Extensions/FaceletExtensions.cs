using RubikCube.Core.Enumerations;

namespace RubikCube.Core.Extensions;
public static class FaceletExtensions
{
    public static Dictionary<(int, int), CubeColor> ExtractData(this CubeColor[,] facelets)
    {
        var result = new Dictionary<(int, int), CubeColor>(facelets.Length);

        for (int row = 0; row < facelets.GetLength(0); row++)
        {
            for (int col = 0; col < facelets.GetLength(1); col++)
            {
                result.Add((row, col), facelets[row, col]);
            }
        }

        return result;
    }
}
