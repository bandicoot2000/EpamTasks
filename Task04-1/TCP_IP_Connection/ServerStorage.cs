using System;
using System.Collections.Generic;

namespace TCP_IP_Connection
{
    /// <summary>
    /// Stores messages from clients.
    /// </summary>
    public class ServerStorage
    {
        private List<string> massages;

        /// <summary>
        /// Construcor ServerStorage.
        /// </summary>
        public ServerStorage()
        {
            massages = new List<string>();
        }

        /// <summary>
        /// Add massage in storage.
        /// </summary>
        /// <param name="massage">Massage.</param>
        /// <param name="clientName">Client name.</param>
        public void AddMassage(string massage, string clientName)
        {
            massages.Add(clientName + " //.// " + massage);
        }

        /// <summary>
        /// Get all client massages.
        /// </summary>
        /// <param name="client">Client name.</param>
        /// <returns>Massages.</returns>
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

        /// <summary>
        /// Return string object.
        /// </summary>
        /// <returns>String object.</returns>
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
