using LockTerminal.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add SignalR
builder.Services.AddSignalR();

// Configure logging to show in console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Map SignalR hub
app.MapHub<LogHub>("/hubs/log");

// Root endpoint - show info
app.MapGet("/", () => new
{
    service = "LockTerminal",
    version = "1.0.0",
    description = "Terminal logging service via WebSocket",
    websocket = "/hubs/log",
    usage = "Connect to ws://localhost:5100/hubs/log and call Log(message) method"
});

// Display startup message
Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════╗");
Console.WriteLine("║        LOCK TERMINAL SERVICE           ║");
Console.WriteLine("╚════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine($"🚀 Started at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"🌐 WebSocket endpoint: ws://localhost:5100/hubs/log");
Console.WriteLine($"📡 HTTP info: http://localhost:5100/");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("✅ Waiting for connections...");
Console.ResetColor();
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
Console.WriteLine();

app.Run("http://localhost:5100");
