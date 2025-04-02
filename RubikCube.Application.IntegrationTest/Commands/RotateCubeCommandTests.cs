using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using RubikCube.Api.Controllers;
using RubikCube.Application.Commands.RotateCube;
using RubikCube.Application.Queries.GetCube;
using RubikCube.Core.Exceptions;
using RubikCube.Core.Enumerations;
using FluentAssertions;
using MediatR;
using Xunit;

namespace RubikCube.Test.Commands;
public class RotateCubeCommandTests(WebApplicationFactory<CubeController> factory) : 
    IClassFixture<WebApplicationFactory<CubeController>>
{
    [Fact]
    public async Task WhenProvidedInvalidRotation_ShouldThrowValidationException()
    {
        //Arrange
        using var scope = factory.Services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        const string NotValidRotation = "Not valid rotation";

        //Act
        var command = new RotateCubeCommand { Rotation = NotValidRotation };
        var exception = await Record.ExceptionAsync(async () => await mediator.Send(command));

        //Assert
        Assert.NotNull(exception);
        Assert.IsType<CubeValidationException>(exception);

        var validationException = (CubeValidationException)exception;
        validationException.Message.Should().Be($"'{NotValidRotation}' is not a valid rotation!");
    }

    [Theory]
    [MemberData(nameof(CubeRotations))]
    public async Task WhenProvidedValidCommand_ShouldRotateTheCube(string rotation)
    {
        //Arrange
        using var scope = factory.Services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var initialCube = (await mediator.Send(new GetCubeQuery()))!;

        //Act
        var command = new RotateCubeCommand
        {
            CurrentCubeState = initialCube,
            Rotation = rotation
        };

        var rotatedCube = await mediator.Send(command);

        //Assert
        rotatedCube.Should().NotBeNull();
        rotatedCube.Should().NotBeEquivalentTo(initialCube);
    }

    public static IEnumerable<object[]> CubeRotations() =>
        Enum.GetNames(typeof(CubeRotation))
            .Select(x => new[] { x });
}
