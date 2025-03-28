using Serilog;

namespace RubikCube.Core.Handlers;
public class BaseHandler
{
    private readonly ILogger _logger;

    public BaseHandler()
    {
        _logger = Log.ForContext(GetType());
    }

    protected void LogError(string message)
    {
        _logger.Error(message);
    }
}
