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

        public delegate void MassageHandlerServer(string massage, string clientName);
        public event MassageHandlerServer ReceivingMessage;

        public Server(string server, int port)
        {
            tcpServer = new TcpListener(IPAddress.Parse(server), port);
            tcpServer.Start();
        }

        public string ReadMassage()
        {
            TcpClient client = tcpServer.AcceptTcpClient();
           
            byte[] data = new byte[256];
            StringBuilder massageBuild = new StringBuilder();
            NetworkStream stream = client.GetStream();

            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                massageBuild.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            string[] massage = massageBuild.ToString().Split(new string[] { " // " }, StringSplitOptions.RemoveEmptyEntries);

            ReceivingMessage(massage[0], massage[1]);

            stream.Close();
            client.Close();
            return massage[0];
        }

        public void WriteMassage(string massage)
        {
            TcpClient client = tcpServer.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(massage);
            stream.Write(data, 0, data.Length);
            stream.Close();
            client.Close();
        }

        public void Close()
        {
            tcpServer.Stop();
        }
    }
}
