using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_IP_Connection
{
    /// <summary>
    /// Server TCP/IP.
    /// </summary>
    public class Server
    {
        private TcpListener tcpServer;

        /// <summary>
        /// Massage handler.
        /// </summary>
        /// <param name="massage">Massage.</param>
        /// <param name="clientName">Client name.</param>
        public delegate void MassageHandlerServer(string massage, string clientName);

        /// <summary>
        /// Processes a received message.
        /// </summary>
        public event MassageHandlerServer ReceivingMessage;

        /// <summary>
        /// Constructor Server.
        /// </summary>
        /// <param name="server">Ip.</param>
        /// <param name="port">Port.</param>
        public Server(string server, int port)
        {
            tcpServer = new TcpListener(IPAddress.Parse(server), port);
            tcpServer.Start();
        }

        /// <summary>
        /// Read massage from clients.
        /// </summary>
        /// <returns>Massage.</returns>
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

        /// <summary>
        /// Write massage to clients.
        /// </summary>
        /// <param name="massage">Massage.</param>
        public void WriteMassage(string massage)
        {
            TcpClient client = tcpServer.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(massage);
            stream.Write(data, 0, data.Length);
            stream.Close();
            client.Close();
        }

        /// <summary>
        /// Close server.
        /// </summary>
        public void Close()
        {
            tcpServer.Stop();
        }
    }
}
