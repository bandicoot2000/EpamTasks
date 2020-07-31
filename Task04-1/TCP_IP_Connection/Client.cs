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


        public delegate void MassageHandler(string massage);
        public event MassageHandler MassageEvent; 

        public Client(string server, int port)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(server, port);
        }

        public void ReadMassage()
        {
            byte[] data = new byte[256];
            StringBuilder massage = new StringBuilder();
            NetworkStream stream = tcpClient.GetStream();

            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                massage.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable); 

            stream.Close();
        }

        public void WriteMassage(string massage)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(massage);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }

        public void Close()
        {
            tcpClient.Close();
        }
    }
}
