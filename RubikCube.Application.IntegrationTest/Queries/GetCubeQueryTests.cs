using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using RubikCube.Api.Controllers;
using RubikCube.Application.Queries.GetCube;
using RubikCube.Core.Constants;
using RubikCube.Core.Enumerations;
using FluentAssertions;
using MediatR;
using Xunit;

namespace RubikCube.Test.Queries;
public class GetCubeQueryTests(WebApplicationFactory<CubeController> factory) : 
    IClassFixture<WebApplicationFactory<CubeController>>
{
    [Fact]
    public async Task WhenProvidedValidQuery_ShouldCreateTheCube()
    {
        //Arrange
        const int FaceletsCount = CubeConstants.DEFAULT_CUBE_SIZE * CubeConstants.DEFAULT_CUBE_SIZE;
        using var scope = factory.Services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        //Act
        var query = new GetCubeQuery();
        var result = await mediator.Send(query);

        //Assert
        result.Should().NotBeNull();

        result.UpSide.Facelets.Should().HaveCount(FaceletsCount);
        result.UpSide.Facelets.All(x => x.Color == CubeColor.White.ToString()).Should().BeTrue();

        result.BackSide.Facelets.Should().HaveCount(FaceletsCount);
        result.BackSide.Facelets.All(x => x.Color == CubeColor.Blue.ToString()).Should().BeTrue();

        result.DownSide.Facelets.Should().HaveCount(FaceletsCount);
        result.DownSide.Facelets.All(x => x.Color == CubeColor.Yellow.ToString()).Should().BeTrue();

        result.FrontSide.Facelets.Should().HaveCount(FaceletsCount);
        result.FrontSide.Facelets.All(x => x.Color == CubeColor.Green.ToString()).Should().BeTrue();

        result.LeftSide.Facelets.Should().HaveCount(FaceletsCount);
        result.LeftSide.Facelets.All(x => x.Color == CubeColor.Orange.ToString()).Should().BeTrue();

        result.RightSide.Facelets.Should().HaveCount(FaceletsCount);
        result.RightSide.Facelets.All(x => x.Color == CubeColor.Red.ToString()).Should().BeTrue();
    }
}
