using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace TimeServer;

public static class Program {
    static void Main(string[] arguments)
    {
        TcpListener? server = null;
        try
        {
            server = new TcpListener(11);

            server.Start();

            for (;;)
            {
                Console.WriteLine("Connecting...");

                TcpClient client = server.AcceptTcpClient();

                Console.WriteLine("Connected!");

                var response = DateTime.Now.ToString(CultureInfo.InvariantCulture);

                StreamWriter streamWriter = new StreamWriter(client.GetStream());
                streamWriter.WriteLine(response);

                Console.WriteLine("response: " + response);

                streamWriter.Close();
                client.Close();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e + " " + e.StackTrace);
            throw;
        }
        finally
        {
            server?.Stop();
        }
    }
}