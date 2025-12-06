using Microsoft.AspNetCore.SignalR;

namespace LockTerminal.Hubs;

/// <summary>
/// SignalR Hub for receiving and logging text messages.
/// Clients can connect via WebSocket and send text to be logged in the terminal.
/// </summary>
public class LogHub : Hub
{
    private readonly ILogger<LogHub> _logger;

    public LogHub(ILogger<LogHub> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Receives text message from client and logs it to the terminal.
    /// </summary>
    /// <param name="message">Text message to log.</param>
    public async Task Log(string message)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        var clientId = Context.ConnectionId.Substring(0, 8);

        // Log to console with colors
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"[{timestamp}] ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"[{clientId}] ");
        Console.ResetColor();
        Console.WriteLine(message);

        // Also log via ILogger
        _logger.LogInformation("[{ClientId}] {Message}", clientId, message);

        await Task.CompletedTask;
    }

    public override async Task OnConnectedAsync()
    {
        var clientId = Context.ConnectionId.Substring(0, 8);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Client connected: {clientId}");
        Console.ResetColor();

        _logger.LogInformation("Client connected: {ClientId}", clientId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var clientId = Context.ConnectionId.Substring(0, 8);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ❌ Client disconnected: {clientId}");
        Console.ResetColor();

        _logger.LogInformation("Client disconnected: {ClientId}", clientId);
        await base.OnDisconnectedAsync(exception);
    }
}
