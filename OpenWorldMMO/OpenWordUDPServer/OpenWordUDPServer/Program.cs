using System.Net;
using System.Net.Sockets;
using System.Text;

   
IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 100011);
    
UdpClient server = new UdpClient(endpoint);

byte[] getBytes = new byte[200];
string messages = "";

try
{
    while (true) 
    {
        IPEndPoint? clientEndpoint = default;
        
        byte[] response = server.Receive(ref clientEndpoint);
        
        string msg = Encoding.ASCII.GetString(response);
        if (msg.Length > 50)
        {
            Console.WriteLine("Invalid input!");
        }
        else
        {
            Console.WriteLine($"Received from: {clientEndpoint} message: {msg}");

            messages = $"{messages} {msg}";
            messages = messages.Trim();

            getBytes = Encoding.ASCII.GetBytes(messages);
        }

        Console.WriteLine(messages);
        server.Send(getBytes, getBytes.Length, clientEndpoint);
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
        


