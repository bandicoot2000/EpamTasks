using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_IP_Connection
{
    public class ServerStorage
    {
        private List<string> massages;

        public ServerStorage()
        {
            massages = new List<string>();
        }

        public void AddMassage(string massage, string clientName)
        {
            massages.Add(clientName + " //.// " + massage);
        }

        public string[] GetMassagesForClient(string client)
        {
            List<string> massages = new List<string>();
            string[] massageParts = null;
            foreach (string massage in this.massages)
            {
                massageParts = massage.Split(new string[] { " //.// " }, StringSplitOptions.RemoveEmptyEntries);
                if (massageParts[0] == client) massages.Add(massageParts[1]);
            }
            return massages.ToArray();
        }

        public override string ToString()
        {
            string answer = "";
            foreach (string massage in massages)
            {
                answer += massage + "\n";
            }
            return answer;
        }
    }
}
