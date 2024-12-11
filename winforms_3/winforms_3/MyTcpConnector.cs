using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace winforms_3
{
    internal class MyTcpConnector
    {
        readonly Int32 port;
        readonly Thread thread;
        readonly Echo echo;
        public delegate void Echo(string msg);

        public MyTcpConnector(Int32 port, Echo echo)
        {
            this.port = port;
            this.echo = echo;
            thread = new Thread(Listen);
            thread.Start();
        }

        public void Send(String server, Int32 port, String message)
        {
            if (this.port == port) 
                return;

            try
            {
                NetworkStream stream;
                TcpClient client;

                using (client = new TcpClient(server, port))
                {
                    Byte[] buffer = Encoding.ASCII.GetBytes(message);
                    stream = client.GetStream();
                    stream.Write(buffer, 0, buffer.Length);

                    buffer = new Byte[4096];
                    Int32 bytes = stream.Read(buffer, 0, buffer.Length);
                }
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (SocketException)
            {
                return;
            }
        }

        private void Listen()
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                server.Start(); 

                while (true)
                {
                    TcpClient client;
                    using (client = server.AcceptTcpClient())
                    {
                        Byte[] buffer = new Byte[4096];
                        String data = String.Empty;

                        NetworkStream stream = client.GetStream();

                        int i;
                        while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            data = Encoding.ASCII.GetString(buffer, 0, i);
                            echo(data);

                            byte[] response = Encoding.ASCII.GetBytes("received");
                            stream.Write(response, 0, response.Length);
                        }
                    }
                }
            }
            catch (SocketException)
            {
                return;
            }
            finally
            {
                server.Stop();
            }
        }
    }
}