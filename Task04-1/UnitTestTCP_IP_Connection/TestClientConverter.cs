using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCP_IP_Connection;

namespace UnitTestTCP_IP_Connection
{
    [TestClass]
    public class TestClientConverter
    {
        [TestMethod]
        public void TestConvertMassageToRus_0()
        {
            string actual = "asdasdasd";
            string expected = "асдасдасд";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestConvertMassageToRus_1()
        {
            string actual = "asda SHHsdasdN";
            string expected = "асда ЩсдасдН";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestConvertMassageToRus_2()
        {
            string actual = "asdas фыdasd AAA GGG";
            string expected = "асдас фыдасд ААА ГГГ";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestConvertMassageToEng_0()
        {
            string expected = "asdasdasd";
            string actual = "асдасдасд";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestConvertMassageToEng_1()
        {
            string expected = "asda SHHsdasdN";
            string actual = "асда ЩсдасдН";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestConvertMassageToEng_2()
        {
            string expected = "asdas lldasd AAA GGG";
            string actual = "асдас llдасд ААА ГГГ";
            ClientConverter.ConvertMassage(ref actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
