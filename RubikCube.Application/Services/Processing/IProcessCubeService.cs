using RubikCube.Application.Models;
using RubikCube.Domain.RubikCube;

namespace RubikCube.Application.Services;
public interface IProcessCubeService
{
    Cube BuildCube();
    Cube BuildCube(CubeViewModel cube);
    void RotateBackClockwise(Cube cube);
    void RotateBackCounterClockwise(Cube cube);
    void RotateFrontClockwise(Cube cube);
    void RotateFrontCounterClockwise(Cube cube);
    void RotateDownClockwise(Cube cube);
    void RotateDownCounterClockwise(Cube cube);
    void RotateUpClockwise(Cube cube);
    void RotateUpCounterClockwise(Cube cube);
    void RotateLeftClockwise(Cube cube);
    void RotateLeftCounterClockwise(Cube cube);
    void RotateRightClockwise(Cube cube);
    void RotateRightCounterClockwise(Cube cube);
}
