using RubikCube.Application.Services;
using RubikCube.Application.Queries.GetCube;
using RubikCube.Application.UnitTest.Common;
using RubikCube.Domain.RubikCube;
using FluentAssertions;
using Moq;
using Xunit;

namespace RubikCube.Application.UnitTest.Queries;
public class GetCubeQueryTests
{
    private readonly Mock<IProcessCubeService> _processCubeServiceMock;
    private readonly GetCubeHandler _handler;

    public GetCubeQueryTests()
    {
        _processCubeServiceMock = new Mock<IProcessCubeService>();
        _handler = new GetCubeHandler(_processCubeServiceMock.Object);
    }

    [Fact]
    public async Task WhenTheCubeDoesNotExist_ShouldReturnNull()
    {
        //Arrange
        _processCubeServiceMock.Setup(x => x.BuildCube())
                               .Returns(new Cube());

        //Act
        var result = await _handler.Handle(new GetCubeQuery(), It.IsAny<CancellationToken>());

        //Assert
        _processCubeServiceMock.Verify(x => x.BuildCube(), Times.Once);
        result.Should().BeNull();
    }

    [Fact]
    public async Task WhenTheCubeExist_ShouldCreateTheViewModel()
    {
        //Arrange
        var cube = UnitTestHelper.BuildInitialCube();

        _processCubeServiceMock.Setup(x => x.BuildCube())
                               .Returns(cube);

        //Act
        var result = await _handler.Handle(new GetCubeQuery(), It.IsAny<CancellationToken>());

        //Assert
        _processCubeServiceMock.Verify(x => x.BuildCube(), Times.Once);
        result.Should().NotBeNull();
    }
}
