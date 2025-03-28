namespace RubikCube.Domain.RubikCube;
public class Cube
{
    public CubeSide FrontSide { get; private set; } = null!;
    public CubeSide BackSide { get; private set; } = null!;
    public CubeSide UpSide { get; private set; } = null!;
    public CubeSide DownSide { get; private set; } = null!;
    public CubeSide LeftSide { get; private set; } = null!;
    public CubeSide RightSide { get; private set; } = null!;


    public void SetFrontSide(CubeSide frontSide) => FrontSide = frontSide;
    public void SetBackSide(CubeSide backSide) => BackSide = backSide;
    public void SetUpSide(CubeSide upSide) => UpSide = upSide;
    public void SetDownSide(CubeSide downSide) => DownSide = downSide;
    public void SetLeftSide(CubeSide leftSide) => LeftSide = leftSide;
    public void SetRightSide(CubeSide rightSide) => RightSide = rightSide;
}
