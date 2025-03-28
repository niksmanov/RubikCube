namespace RubikCube.Core.Exceptions;
public class CubeValidationException : Exception
{
    public CubeValidationException(string? message) : base(message)
    { }
}
