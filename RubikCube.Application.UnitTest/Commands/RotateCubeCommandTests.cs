using System.Linq.Expressions;
using RubikCube.Application.Services;
using RubikCube.Application.Commands.RotateCube;
using RubikCube.Application.UnitTest.Common;
using RubikCube.Application.Models;
using RubikCube.Domain.RubikCube;
using RubikCube.Core.Enumerations;
using FluentAssertions;
using Moq;
using Xunit;

namespace RubikCube.Application.UnitTest.Commands;
public class RotateCubeCommandTests
{
    private readonly Mock<IProcessCubeService> _processCubeServiceMock;
    private readonly RotateCubeHandler _handler;

    public RotateCubeCommandTests()
    {
        _processCubeServiceMock = new Mock<IProcessCubeService>();
        _handler = new RotateCubeHandler(_processCubeServiceMock.Object);
    }

    [Theory]
    [MemberData(nameof(CubeRotations))]
    public async Task WhenProvidedValidCommand_ShouldCallRotateMethod(string rotation)
    {
        //Arrange
        var command = new RotateCubeCommand { Rotation = rotation };

        _processCubeServiceMock.Setup(x => x.BuildCube(It.IsAny<CubeViewModel>()))
                               .Returns(UnitTestHelper.BuildInitialCube());

        //Act
        var result = await _handler.Handle(command, It.IsAny<CancellationToken>());

        //Assert
        _processCubeServiceMock.Verify(x => x.BuildCube(It.IsAny<CubeViewModel>()), Times.Once);
        _processCubeServiceMock.Verify(VerifyCubeRotation(rotation), Times.Once);

        result.Should().NotBeNull();
        result.Should().BeOfType<CubeViewModel>();
    }

    public static IEnumerable<object[]> CubeRotations() =>
        Enum.GetNames(typeof(CubeRotation))
            .Select(x => new[] { x });

    private static Expression<Action<IProcessCubeService>> VerifyCubeRotation(string rotation)
    {
        Expression<Action<IProcessCubeService>> verify = null!;

        switch (Enum.Parse<CubeRotation>(rotation))
        {
            case CubeRotation.FrontClockwise: verify = x => x.RotateFrontClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.FrontCounterClockwise: verify = x => x.RotateFrontCounterClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.BackClockwise: verify = x => x.RotateBackClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.BackCounterClockwise: verify = x => x.RotateBackCounterClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.UpClockwise: verify = x => x.RotateUpClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.UpCounterClockwise: verify = x => x.RotateUpCounterClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.DownClockwise: verify = x => x.RotateDownClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.DownCounterClockwise: verify = x => x.RotateDownCounterClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.LeftClockwise: verify = x => x.RotateLeftClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.LeftCounterClockwise: verify = x => x.RotateLeftCounterClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.RightClockwise: verify = x => x.RotateRightClockwise(It.IsAny<Cube>()); break;
            case CubeRotation.RightCounterClockwise: verify = x => x.RotateRightCounterClockwise(It.IsAny<Cube>()); break;
        }

        return verify;
    }
}
