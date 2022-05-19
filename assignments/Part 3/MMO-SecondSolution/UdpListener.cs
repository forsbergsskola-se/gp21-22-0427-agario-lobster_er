using System.Net;
using System.Net.Sockets;
using System.Text;

//Server
namespace MMO_SecondSolution;

internal class UdpListener : UdpBase
{
    public UdpListener() : this(new IPEndPoint(IPAddress.Any,32123))
    {
    }

    private UdpListener(IPEndPoint endpoint)
    {
        Client = new UdpClient(endpoint);
    }

    public void Reply(string message,IPEndPoint endpoint)
    {
        var datagram = Encoding.ASCII.GetBytes(message);
        Client.Send(datagram, datagram.Length,endpoint);
    }

    public void Send(byte[] getBytes, int getBytesLength, IPEndPoint clientEndpoint)
    {
        throw new NotImplementedException();
    }
}