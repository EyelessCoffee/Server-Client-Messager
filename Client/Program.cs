using System.Net.Sockets;
using System.Text;

Client client = new();

client.SendMessageToServer();

class Client
{
    TcpClient client;
    public Client() => ConnectToServer();

    void ConnectToServer()
    {
        // create client from server port
        Console.WriteLine("Connecting to server...");
        client = new TcpClient("127.0.0.1", 5000);
        Console.WriteLine("Connected!");
    }

    public void SendMessageToServer()
    {
        if(client == null) return;

        // get message
        Console.WriteLine("Send a message to the server!");
        string message = Console.ReadLine() ?? "";

        // write the encoded message to the network stream
        NetworkStream stream = client.GetStream();
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);

        Console.WriteLine("Message sent!");
        Console.WriteLine("Client Closed");
    }
}




