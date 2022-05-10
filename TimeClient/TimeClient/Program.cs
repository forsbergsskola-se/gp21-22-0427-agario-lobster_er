using System.Net.Sockets;

/*var tcpClient = new TcpClient();
Console.WriteLine("Connecting to server...");
tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 12244));
Console.WriteLine("Connected.");

var stream = tcpClient.GetStream();
var streamReader = new StreamReader(stream);
var streamWriter = new StreamWriter(stream);
streamWriter.AutoFlush = true;

Console.WriteLine(streamReader.ReadLine());
streamWriter.WriteLine(Console.ReadLine());
Console.WriteLine(streamReader.ReadLine());*/

namespace TimeClient;

public class DaytimeClient : TcpClient
{
    private DaytimeClient(string host)
    {
        base.Connect(host, 13);
    }
    
    public static void Main(string[] args)
    {
        DaytimeClient? dtReceiver = null;
        StreamReader? streamReader = null;

        try
        {
            var host = args.Length == 1 ? args[0] : "127.0.0.1";

            dtReceiver = new DaytimeClient(host);

            streamReader = new StreamReader(dtReceiver.GetStream());

            var returnData = streamReader.ReadToEnd();
            Console.WriteLine("Time is " + ": " + returnData + "at " + host);

        }
        catch (Exception e)
        {
            Console.WriteLine(e + " " + e.StackTrace);
        }
        finally
        {
            if(streamReader != null) 
                streamReader.Close();
            if (dtReceiver != null)
            {
                dtReceiver.Close();
            }
        }

    }
    
}