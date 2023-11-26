using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace sockettest
{
    internal class Server
    {
        IPHostEntry host;
        IPAddress remoteAddress;
        IPEndPoint remoteEndPoint;

        Socket s_server;
        Socket s_socketCli;

        public Server(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            remoteAddress = host.AddressList[0];
            remoteEndPoint = new IPEndPoint(remoteAddress, port);
            //Console.WriteLine("Hello, World!");

            s_server = new Socket(remoteAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s_server.Bind(remoteEndPoint);
            s_server.Listen(10);
        }
        public void Start()
        {
            byte[] buffer = new byte[1024];
            string message;

            s_socketCli = s_server.Accept();
            s_socketCli.Receive(buffer);

            message = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(message);

        }
    }
}
