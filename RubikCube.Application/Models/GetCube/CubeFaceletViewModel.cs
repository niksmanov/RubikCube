namespace RubikCube.Application.Models;
public class CubeFaceletViewModel
{
    public int Column { get; set; }
    public int Row { get; set; }
    public string Color { get; set; } = null!;
}
