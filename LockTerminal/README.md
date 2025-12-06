# LockTerminal

Terminal logging service pro příjem a zobrazení textových zpráv přes WebSocket.

## Spuštění

```bash
cd ~/Olbrasoft/LockTerminal
./run.sh
```

Nebo přímo:

```bash
cd ~/Olbrasoft/LockTerminal/src/LockTerminal
dotnet run
```

## Použití

### Server

Služba běží na `http://localhost:5100` a WebSocket endpoint je na `ws://localhost:5100/hubs/log`.

### Připojení klienta (C#)

```csharp
using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5100/hubs/log")
    .Build();

await connection.StartAsync();

// Poslat zprávu do terminálu
await connection.InvokeAsync("Log", "Hello from client!");

await connection.StopAsync();
```

### Připojení klienta (JavaScript)

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5100/hubs/log")
    .build();

await connection.start();

// Poslat zprávu do terminálu
await connection.invoke("Log", "Hello from JavaScript!");

await connection.stop();
```

### Připojení klienta (curl - HTTP test)

```bash
curl http://localhost:5100/
```

## Funkce

- **Log(string message)** - Pošle textovou zprávu, která se zobrazí v terminálu
- Barevný výstup v terminálu
- Zobrazení časových razítek
- Zobrazení ID klienta
- Logování připojení a odpojení klientů

## Výstup v terminálu

```
╔════════════════════════════════════════╗
║        LOCK TERMINAL SERVICE           ║
╚════════════════════════════════════════╝

🚀 Started at: 2025-11-26 20:30:00
🌐 WebSocket endpoint: ws://localhost:5100/hubs/log
📡 HTTP info: http://localhost:5100/

✅ Waiting for connections...
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

[20:30:15.123] ✅ Client connected: a1b2c3d4
[20:30:16.456] [a1b2c3d4] Hello from client!
[20:30:20.789] ❌ Client disconnected: a1b2c3d4
```

## Port

Výchozí port je **5100**. Můžete ho změnit v `Program.cs` na řádku:

```csharp
app.Run("http://localhost:5100");
```
