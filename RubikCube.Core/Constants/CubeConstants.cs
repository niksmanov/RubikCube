namespace RubikCube.Core.Constants;
public static class CubeConstants
{
    public const int DEFAULT_CUBE_SIZE = 3;

    public const string CUBE_CACHE_KEY = "Cube";
    public static readonly DateTime CUBE_CACHE_TIME = DateTime.UtcNow.AddDays(1);
}
