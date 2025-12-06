using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("LockTerminal Test Client");
Console.WriteLine("========================\n");

// Vytvoření připojení k LockTerminal serveru
var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5100/hubs/log")
    .WithAutomaticReconnect()
    .Build();

try
{
    Console.WriteLine("Connecting to LockTerminal...");
    await connection.StartAsync();
    Console.WriteLine("✅ Connected!\n");

    // Poslat několik testovacích zpráv
    await connection.InvokeAsync("Log", "Hello from test client!");
    await Task.Delay(500);

    await connection.InvokeAsync("Log", "This is a test message");
    await Task.Delay(500);

    await connection.InvokeAsync("Log", $"Current time: {DateTime.Now:HH:mm:ss}");
    await Task.Delay(500);

    // Interaktivní režim - uživatel může psát zprávy
    Console.WriteLine("\n✍️  Type messages to send (empty line to quit):\n");

    while (true)
    {
        Console.Write("> ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            break;
        }

        await connection.InvokeAsync("Log", input);
    }

    Console.WriteLine("\nDisconnecting...");
    await connection.StopAsync();
    Console.WriteLine("✅ Disconnected");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
    Console.WriteLine("\nMake sure LockTerminal server is running:");
    Console.WriteLine("  cd ~/Olbrasoft/LockTerminal");
    Console.WriteLine("  ./run.sh");
}
