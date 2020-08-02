using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCP_IP_Connection;

namespace UnitTestTCP_IP_Connection
{
    [TestClass]
    public class UnitTestClient
    {
        [TestMethod]
        public void TestMethod()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100);

            client.MassageEvent += (ref string massage) =>
            {
                ClientConverter.ConvertMassage(ref massage);
            };

            Task.Run(() => { 
                server.WriteMassage("asd"); 
            });

            Assert.AreEqual("asd1", client.ReadMassage());
        }
    }
}
