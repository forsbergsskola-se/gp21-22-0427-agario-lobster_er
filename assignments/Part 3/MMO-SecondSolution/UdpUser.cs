using System.Text;


//Client

namespace MMO_SecondSolution;

internal class UdpUser : UdpBase
{
    private UdpUser(){}

    public static UdpUser ConnectTo(string hostname, int port)
    {
        var connection = new UdpUser();
        connection.Client.Connect(hostname, port);
        return connection;
    }

    public void Send(string? message)
    {
        if (message != null)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length);
        }
    }

}