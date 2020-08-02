using TCP_IP_Connection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTestTCP_IP_Connection
{
    [TestClass]
    public class TestClientServer
    {
        [TestMethod]
        public void TestReadMassageClient_0()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100, "Client1");

            client.ReceivingMessage += (ref string massage) =>
            {
                ClientConverter.ConvertMassage(ref massage);
            };

            Task.Run(() => {
                server.WriteMassage("asd");
                server.Close();
            });

            Assert.AreEqual("асд", client.ReadMassage());
        }

        [TestMethod]
        public void TestReadMassageClient_1()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100, "Client1");

            client.ReceivingMessage += (ref string massage) =>
            {
                ClientConverter.ConvertMassage(ref massage);
            };

            Task.Run(() => {
                server.WriteMassage("прнШ");
                server.Close();
            });

            Assert.AreEqual("prnSH", client.ReadMassage());
        }

        [TestMethod]
        public void TestReadMassageClient_2()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100, "Client1");

            client.ReceivingMessage += (ref string massage) =>
            {
                ClientConverter.ConvertMassage(ref massage);
            };

            Task.Run(() => {
                server.WriteMassage("asd");
                server.WriteMassage("асд");
                server.Close();
            });

            string[] expected =
            {
                "асд",
                "asd"
            };

            string[] actual = new string[2];
            actual[0] = client.ReadMassage();
            actual[1] = client.ReadMassage();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReadMassageServer_0()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100, "Client1");
            ServerStorage serverStorage = new ServerStorage();

            server.ReceivingMessage += (string massage, string clientName) =>
            {
                serverStorage.AddMassage(massage, clientName);
            };

            Task.Run(() => {
                client.WriteMassage("asd");
                client.WriteMassage("sss");
                client.WriteMassage("ddd");
            });

            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.Close();

            string[] expected =
            {
                "asd",
                "sss",
                "ddd"
            };


            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client1"));
        }

        [TestMethod]
        public void TestReadMassageServer_1()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client1 = new Client("127.0.0.1", 100, "Client1");
            Client client2 = new Client("127.0.0.1", 100, "Client2");
            ServerStorage serverStorage = new ServerStorage();

            server.ReceivingMessage += (string massage, string clientName) =>
            {
                serverStorage.AddMassage(massage, clientName);
            };

            Task.Run(() => {
                client1.WriteMassage("asd");
                client1.WriteMassage("sss");
                client1.WriteMassage("ddd");
                client2.WriteMassage("ааа");
                client2.WriteMassage("ввв");
                client2.WriteMassage("ыыы");
            });

            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.Close();

            string[] expected =
            {
                "ааа",
                "ввв",
                "ыыы"
            };


            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client2"));
        }

        [TestMethod]
        public void TestReadMassageServer_2()
        {
            Server server = new Server("127.0.0.1", 100);
            Client client = new Client("127.0.0.1", 100, "Client1");
            ServerStorage serverStorage = new ServerStorage();

            server.ReceivingMessage += (string massage, string clientName) =>
            {
                serverStorage.AddMassage(massage, clientName);
            };

            Task.Run(() => {
                client.WriteMassage("asd");
                client.WriteMassage("sss");
                client.WriteMassage("ddd");
            });

            server.ReadMassage();
            server.ReadMassage();
            server.ReadMassage();
            server.Close();

            string[] expected = { };


            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client2"));
        }
    }
}
