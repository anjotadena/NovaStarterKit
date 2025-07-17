using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Logging;

public class SerilogAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;

    public SerilogAdapter(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message) => _logger.LogInformation(message);

    public void LogWarning(string message) => _logger.LogWarning(message);

    public void LogError(Exception exception, string message) => _logger.LogError(exception, message);
}
