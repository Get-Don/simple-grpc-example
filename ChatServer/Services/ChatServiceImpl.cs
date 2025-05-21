using Chat;
using ChatServer.Managers;
using Grpc.Core;
using System.Collections.Concurrent;
using static Chat.ChatService;

namespace ChatServer.Services
{
    class ChatServiceImpl : ChatServiceBase
    {
        private static readonly ConcurrentDictionary<string, Client> _clients = new();

        public override async Task<Google.Protobuf.WellKnownTypes.Empty> PostMessage(ChatMessage request, ServerCallContext context)
        {
            if (_clients.ContainsKey(request.Name.ToLower()))
            {
                Console.WriteLine($"[{request.Name}] {request.Message}");
                await BroadcastMessage(request);
            }

            return new Google.Protobuf.WellKnownTypes.Empty();
        }

        public override async Task StreamingMessage(ConnectRequest request, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {
            var clientKey = request.Name.ToLower();

            try
            {
                var client = new Client
                {
                    Name = request.Name,
                    StreamWriter = responseStream,
                    CancellationSource = CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken)
                };

                if (!_clients.TryAdd(clientKey, client))
                {
                    return;
                }

                Console.WriteLine($"Client connected. Name: " + request.Name);
                await Task.Delay(-1, client.CancellationSource.Token);       
            }
            catch (TaskCanceledException)
            {
                // 정상적인 클라이언트 종료 상황
            }
            catch (Exception e)
            {
                Console.WriteLine($"Connection error. Name: {request.Name}, Error: {e.ToString()}");
            }
            finally
            {
                if(_clients.TryRemove(clientKey, out var client))
                {
                    client.Dispose();
                    Console.WriteLine($"Client disconnected. Name: " + request.Name);                    
                }                
            }
        }

        private async Task BroadcastMessage(ChatMessage message)
        {
            foreach (var client in _clients)
            {
                try
                {
                    await client.Value.StreamWriter.WriteAsync(message);
                }
                catch (Exception ex)
                {
                    client.Value.CancellationSource.Cancel();
                    Console.WriteLine($"Failed to send message. Name: {client.Key}, Error: {ex.Message}");                        
                }
            }
        }
    }
}
