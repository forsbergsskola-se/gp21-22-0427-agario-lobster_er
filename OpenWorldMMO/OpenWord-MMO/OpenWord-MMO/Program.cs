using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OpenWord_MMO;

public static class OpenWordClient
{
    static void Main()
    {
        IPEndPoint serverIpEndPoint = new IPEndPoint(IPAddress.Loopback, 11000);
        IPEndPoint clientIpEndPoint = new IPEndPoint(IPAddress.Loopback, 11001);

        while (true)
        {
            UdpClient client = new UdpClient(clientIpEndPoint);

            Console.WriteLine("Send Your Message...");
            
            var stringInput = Console.ReadLine();

            if (stringInput != null)
            {
                var message = Encoding.ASCII.GetBytes(stringInput);
                client.Send(message, message.Length, serverIpEndPoint);

                client.Close();
            }
            else
            {
                return;
            }
        }
    }
}