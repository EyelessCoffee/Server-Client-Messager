using System.Net;
using System.Net.Sockets;
using System.Text;

Server server = new Server();

class Server
{
    TcpListener server;
    TcpClient client;

    public Server() => OpenServer();

    void OpenServer()
    {
        // create a new TcpListener
        server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Server started. Waiting for a connection...");
        // wait for client
        client = server.AcceptTcpClient();
        Console.WriteLine("Client connected!");
        ListenForMessage();
    }

    void ListenForMessage()
    {
        // get the stream from the client and get the Byte read
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);

        // decode the message
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Received: {message}");
        File.AppendAllText("Message.txt", $"{DateTime.Now} : {message}{Environment.NewLine}");
        
        Console.WriteLine("Server Closed");
        return;
    }
}





