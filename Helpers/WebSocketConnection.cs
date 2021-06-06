using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChirpServer.Helpers
{
    public class WebSocketConnection
    {
        private readonly WebSocket _ws;
        private readonly byte[] _buffer;

        public WebSocketConnection(WebSocket rawWebSocket, int bufferSize=1024)
        {
            _ws = rawWebSocket;
            _buffer = new byte[bufferSize];
        }

        public async Task<string> ReceiveString()
        {
            var result = await _ws.ReceiveAsync(new ArraySegment<byte>(_buffer), CancellationToken.None);
            if (result.CloseStatus.HasValue)
            {
                throw new WebSocketException("Websocket closed");
            }
            return Encoding.UTF8.GetString(_buffer).Substring(0, result.Count);
        }

        public async Task SendString(string message)
        {
            var responseBytes = Encoding.UTF8.GetBytes(message);
            await _ws.SendAsync(new ArraySegment<byte>(responseBytes, 0, responseBytes.Length),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }

        public async Task SendObject<T>(T obj)
        {
            await SendString(JsonSerializer.Serialize(obj));
        }

        public async Task Close(WebSocketCloseStatus status=WebSocketCloseStatus.NormalClosure, string description="")
        {
            await _ws.CloseAsync(status, description, CancellationToken.None);
        }
    }
}
