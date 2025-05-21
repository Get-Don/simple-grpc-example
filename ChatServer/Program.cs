using Chat;
using ChatServer.Services;
using Grpc.Core;

namespace ChatServer;

internal class Program
{
    const int _port = 3000;

    static void Main(string[] args)
    {
        Server? rpcServer = null;

        try
        {
            rpcServer = new()
            {
                Services = { ChatService.BindService(new ChatServiceImpl()) },
                Ports = { new ServerPort("localhost", _port, ServerCredentials.Insecure) }
            };

            rpcServer.Start();

            Console.WriteLine("The server is listening on the port : " + _port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("The server failed to start : " + e.Message);
            throw;
        }
        finally
        {
            rpcServer?.ShutdownAsync().Wait();
        }
    }
}
