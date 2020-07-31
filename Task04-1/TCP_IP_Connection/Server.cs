using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_IP_Connection
{
    public class Server
    {
        private TcpListener tcpServer;


        public delegate void MassageHandler(string massage);
        public event MassageHandler MassageEvent;

        public Server(string server, int port)
        {
            tcpServer = new TcpListener(IPAddress.Parse(server), port);
            tcpServer.Start();
        }

        public void ReadMassage()
        {
            try
            {
                TcpClient client = tcpServer.AcceptTcpClient();
                byte[] data = new byte[256];
                StringBuilder massage = new StringBuilder();
                NetworkStream stream = client.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    massage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                stream.Close();
                client.Close();
            }
            catch(Exception e)
            {

            }
        }

        public void WriteMassage(string massage)
        {
            try
            {
                TcpClient client = tcpServer.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(massage);
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Close();
            }
            catch(Exception e)
            {

            }
        }

        public void Close()
        {
            tcpServer.Stop();
        }
    }
}
