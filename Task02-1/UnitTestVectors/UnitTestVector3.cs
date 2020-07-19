using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vectors;

namespace UnitTestVectors
{
    [TestClass]
    public class UnitTestVector3
    {
        [TestMethod]
        public void VectorSumTest()
        {
            Vector3 vector_1;
            Vector3 vector_2;
            for (int x1 = 0; x1 < 10; x1++)
            {
                for (int y1 = 0; y1 < 10; y1++)
                {
                    for (int z1 = 0; z1 < 10; z1++)
                    {
                        for (int x2 = 0; x2 < 10; x2++)
                        {
                            for (int y2 = 0; y2 < 10; y2++)
                            {
                                for (int z2 = 0; z2 < 10; z2++)
                                {
                                    vector_1 = new Vector3(x1, y1, z1);
                                    vector_2 = new Vector3(x2, y2, z2);
                                    Assert.AreEqual(new Vector3(x1 + x2, y1 + y2, z1 + z2), vector_1 + vector_2);
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void VectorDefTest()
        {
            Vector3 vector_1;
            Vector3 vector_2;
            for (int x1 = 0; x1 < 10; x1++)
            {
                for (int y1 = 0; y1 < 10; y1++)
                {
                    for (int z1 = 0; z1 < 10; z1++)
                    {
                        for (int x2 = 0; x2 < 10; x2++)
                        {
                            for (int y2 = 0; y2 < 10; y2++)
                            {
                                for (int z2 = 0; z2 < 10; z2++)
                                {
                                    vector_1 = new Vector3(x1, y1, z1);
                                    vector_2 = new Vector3(x2, y2, z2);
                                    Assert.AreEqual(new Vector3(x1 - x2, y1 - y2, z1 - z2), vector_1 - vector_2);
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void VectorValueTest()
        {
            Vector3 vector_1;
            for (int x1 = 0; x1 < 10; x1++)
            {
                for (int y1 = 0; y1 < 10; y1++)
                {
                    for (int z1 = 0; z1 < 10; z1++)
                    {
                        for (int value = 0; value < 100; value++)
                        {
                            vector_1 = new Vector3(x1, y1, z1);
                            Assert.AreEqual(new Vector3(x1 * value, y1 * value, z1 * value), vector_1 * value);
                        }
                    }
                }
            }
        }


        [TestMethod]
        public void VectorVectorTest()
        {
            Vector3 vector_1;
            Vector3 vector_2;
            for (int x1 = 0; x1 < 10; x1++)
            {
                for (int y1 = 0; y1 < 10; y1++)
                {
                    for (int z1 = 0; z1 < 10; z1++)
                    {
                        for (int x2 = 0; x2 < 10; x2++)
                        {
                            for (int y2 = 0; y2 < 10; y2++)
                            {
                                for (int z2 = 0; z2 < 10; z2++)
                                {
                                    vector_1 = new Vector3(x1, y1, z1);
                                    vector_2 = new Vector3(x2, y2, z2);
                                    Assert.AreEqual((x1 * x2) + (y1 * y2) + (z1 * z2), vector_1 * vector_2);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
