using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Program {
    static void Main(string[] arguments) {
        var endpoint = new IPEndPoint(
            // IP-Address: Used with IP-Protocol to find the right computer
            IPAddress.Loopback, // 127.0.0.1 
            // Port: Used with TCP / UDP Protocol to find the right program on a computer
            14411
        );
        var tcpListener = new TcpListener(endpoint);
        tcpListener.Start();
        
        while (true) {
            var tcpClient = tcpListener.AcceptTcpClient();
            // Send the password request
            var responseBuffer = Encoding.ASCII.GetBytes("What's the password?");
            tcpClient.GetStream().Write(responseBuffer, 0, responseBuffer.Length);
            
            // Read the message from the client
            byte[] buffer = new byte[100];
            // Remember, how many bytes we actually received
            var length = tcpClient.GetStream().Read(buffer, 0, 100);
            // Only parse the bytes that we have received into a string:
            // - the buffer has a size of 100. Most characters will be   (ASCII:00)
            // - only the bytes, that we've actually received will have a value
            var response = Encoding.ASCII.GetString(buffer, 0, length);
            // Compare the received password against our super-safe password :o)
            if (!response.Equals("123456")) {
                responseBuffer = Encoding.ASCII.GetBytes("Boo!");
                tcpClient.GetStream().Write(responseBuffer, 0, responseBuffer.Length);
                tcpClient.Close();
            } else {
                responseBuffer = Encoding.ASCII.GetBytes("Nice!");
                tcpClient.GetStream().Write(responseBuffer, 0, responseBuffer.Length);
                tcpClient.Close();
            }
        }
    }
}