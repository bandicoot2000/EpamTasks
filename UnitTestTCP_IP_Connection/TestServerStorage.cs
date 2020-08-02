using TCP_IP_Connection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTCP_IP_Connection
{
    [TestClass]
    public class TestServerStorage
    {
        [TestMethod]
        public void TestGetMassagesForClient_0()
        {
            ServerStorage serverStorage = new ServerStorage();
            serverStorage.AddMassage("Massage1", "Client1");
            serverStorage.AddMassage("Massage2", "Client1");
            serverStorage.AddMassage("Massage3", "Client1");
            serverStorage.AddMassage("Massage4", "Client1");
            serverStorage.AddMassage("Massage5", "Client2");
            serverStorage.AddMassage("Massage6", "Client3");
            string[] expected =
            {
                "Massage1",
                "Massage2",
                "Massage3",
                "Massage4"
            };
            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client1"));
        }
        [TestMethod]
        public void TestGetMassagesForClient_1()
        {
            ServerStorage serverStorage = new ServerStorage();
            serverStorage.AddMassage("Massage1", "Client1");
            serverStorage.AddMassage("Massage2", "Client1");
            serverStorage.AddMassage("Massage3", "Client1");
            serverStorage.AddMassage("Massage4", "Client1");
            serverStorage.AddMassage("Massage5", "Client2");
            serverStorage.AddMassage("Massage6", "Client3");
            string[] expected =
            {
                "Massage5"
            };
            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client2"));
        }
        [TestMethod]
        public void TestGetMassagesForClient_2()
        {
            ServerStorage serverStorage = new ServerStorage();
            serverStorage.AddMassage("Massage1", "Client1");
            serverStorage.AddMassage("Massage2", "Client1");
            serverStorage.AddMassage("Massage3", "Client1");
            serverStorage.AddMassage("Massage4", "Client1");
            serverStorage.AddMassage("Massage5", "Client2");
            serverStorage.AddMassage("Massage6", "Client3");
            string[] expected =
            {
                "Massage6"
            };
            CollectionAssert.AreEqual(expected, serverStorage.GetMassagesForClient("Client3"));
        }
        [TestMethod]
        public void TestToString()
        {
            ServerStorage serverStorage = new ServerStorage();
            serverStorage.AddMassage("Massage1", "Client1");
            serverStorage.AddMassage("Massage2", "Client1");
            serverStorage.AddMassage("Massage3", "Client1");
            serverStorage.AddMassage("Massage4", "Client1");
            serverStorage.AddMassage("Massage5", "Client2");
            serverStorage.AddMassage("Massage6", "Client3");
            string expected = "Client1 //.// Massage1\n" +
                "Client1 //.// Massage2\n" +
                "Client1 //.// Massage3\n" +
                "Client1 //.// Massage4\n" +
                "Client2 //.// Massage5\n" +
                "Client3 //.// Massage6\n";
            Assert.AreEqual(expected, serverStorage.ToString());
        }
    }
}
