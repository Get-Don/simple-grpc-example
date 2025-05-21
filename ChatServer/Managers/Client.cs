using Chat;
using Grpc.Core;

namespace ChatServer.Managers;

class Client : IDisposable
{
    public string Name { get; set; }
    public IServerStreamWriter<ChatMessage> StreamWriter { get; set; }
    public CancellationTokenSource CancellationSource { get; set; }

    public void Dispose()
    {
        CancellationSource?.Dispose();
    }
}
