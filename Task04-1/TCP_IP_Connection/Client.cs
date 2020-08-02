using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_IP_Connection
{
    public class Client
    {
        private TcpClient tcpClient;
        private string server;
        private int port;

        public delegate void MassageHandler(ref string massage);
        public event MassageHandler ReceivingMessage; 

        public string Name { get; private set; }

        public Client(string server, int port, string name)
        {
            this.server = server;
            this.port = port;
            Name = name;
        }

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
