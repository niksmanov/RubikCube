namespace RubikCube.Application.Models;
public class CubeViewModel
{
    public CubeSideViewModel FrontSide { get; set; } = null!;
    public CubeSideViewModel BackSide { get; set; } = null!;
    public CubeSideViewModel UpSide { get; set; } = null!;
    public CubeSideViewModel DownSide { get; set; } = null!;
    public CubeSideViewModel LeftSide { get; set; } = null!;
    public CubeSideViewModel RightSide { get; set; } = null!;

    public CubeViewModel()
    { }

    public CubeViewModel(Domain.RubikCube.Cube cube)
    {
        FrontSide = new CubeSideViewModel(cube.FrontSide);
        BackSide = new CubeSideViewModel(cube.BackSide);
        UpSide = new CubeSideViewModel(cube.UpSide);
        DownSide = new CubeSideViewModel(cube.DownSide);
        LeftSide = new CubeSideViewModel(cube.LeftSide);
        RightSide = new CubeSideViewModel(cube.RightSide);
    }
}
