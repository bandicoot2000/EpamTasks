using System;
using System.Net.Sockets;
using System.Text;

namespace TCP_IP_Connection
{
    /// <summary>
    /// Client TCP/IP.
    /// </summary>
    public class Client
    {
        private TcpClient tcpClient;
        private string server;
        private int port;

        /// <summary>
        /// Massage handler.
        /// </summary>
        /// <param name="massage">Massage.</param>
        public delegate void MassageHandlerClient(ref string massage);
        /// <summary>
        /// Processes a received message.
        /// </summary>
        public event MassageHandlerClient ReceivingMessage; 

        /// <summary>
        /// Client name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="server">Ip.</param>
        /// <param name="port">Port.</param>
        /// <param name="name">Name.</param>
        public Client(string server, int port, string name)
        {
            this.server = server;
            this.port = port;
            Name = name;
        }

        /// <summary>
        /// Read massage from server.
        /// </summary>
        /// <returns>Massage.</returns>
        public string ReadMassage()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(server, port);

            byte[] data = new byte[256];
            StringBuilder massageBuild = new StringBuilder();
            NetworkStream stream = tcpClient.GetStream();

            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                massageBuild.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            string massage = massageBuild.ToString();

            ReceivingMessage(ref massage);

            Console.WriteLine(massage.ToString() + "  Сообщение которое получил клинт");

            stream.Close();
            tcpClient.Close();
            return massage;
        }

        /// <summary>
        /// Write massage to server.
        /// </summary>
        /// <param name="massage">Massage.</param>
        public void WriteMassage(string massage)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(server, port);

            NetworkStream stream = tcpClient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(massage + " // " + Name);

            stream.Write(data, 0, data.Length);
            stream.Close();
            tcpClient.Close();
        }

    }
}
