using System;
using ISerializeClasses;
using SerializationClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestSerializationClasses
{
    [TestClass]
    public class TestSerializer
    {
        [TestMethod]
        public void TestIntBinary()
        {
            Int32ISerializable int32ISerializable = new Int32ISerializable(10);
            Serializer<Int32ISerializable>.BinarySerialize("../../../IntBinaryTest", int32ISerializable);
            Assert.AreEqual(int32ISerializable, Serializer<Int32ISerializable>.BinaryDeserialize("../../../IntBinaryTest"));
        }
        [TestMethod]
        public void TestIntBinaryCollection()
        {
            List<Int32ISerializable> ints = new List<Int32ISerializable>();
            ints.Add(new Int32ISerializable(10));
            ints.Add(new Int32ISerializable(6));
            ints.Add(new Int32ISerializable(3));
            ints.Add(new Int32ISerializable(4));
            ints.Add(new Int32ISerializable(8));
            Serializer<Int32ISerializable>.BinarySerialize("../../../IntBinaryCollectionTest", ints);
            CollectionAssert.AreEqual(ints, (ICollection)Serializer<Int32ISerializable>.BinaryDeserializeCollection("../../../IntBinaryCollectionTest"));
        }
        [TestMethod]
        public void TestStudentBinary()
        {
            StudentTestISerializable student = new StudentTestISerializable("Name", "Test", DateTime.Now, 10);
            Serializer<StudentTestISerializable>.BinarySerialize("../../../StudentBinaryTest", student);
            Assert.AreEqual(student, Serializer<StudentTestISerializable>.BinaryDeserialize("../../../StudentBinaryTest"));
        }
        [TestMethod]
        public void TestStudentBinaryCollection()
        {
            List<StudentTestISerializable> students = new List<StudentTestISerializable>();
            students.Add(new StudentTestISerializable("Name5", "Test1", DateTime.Now, 10));
            students.Add(new StudentTestISerializable("Name4", "Test2", DateTime.Now, 6));
            students.Add(new StudentTestISerializable("Name3", "Test3", DateTime.Now, 5));
            students.Add(new StudentTestISerializable("Name2", "Test4", DateTime.Now, 8));
            students.Add(new StudentTestISerializable("Name1", "Test5", DateTime.Now, 9));
            Serializer<StudentTestISerializable>.BinarySerialize("../../../StudentBinaryCollectionTest", students);
            CollectionAssert.AreEqual(students, (ICollection)Serializer<StudentTestISerializable>.BinaryDeserializeCollection("../../../StudentBinaryCollectionTest"));
        }

        [TestMethod]
        public void TestIntJson()
        {
            Int32ISerializable int32ISerializable = new Int32ISerializable(10);
            Serializer<Int32ISerializable>.JSONSerialize("../../../IntJsonTest", int32ISerializable);
            Assert.AreEqual(int32ISerializable, Serializer<Int32ISerializable>.JSONDeserialize("../../../IntJsonTest"));
        }
        [TestMethod]
        public void TestIntJsonCollection()
        {
            List<Int32ISerializable> ints = new List<Int32ISerializable>();
            ints.Add(new Int32ISerializable(10));
            ints.Add(new Int32ISerializable(6));
            ints.Add(new Int32ISerializable(3));
            ints.Add(new Int32ISerializable(4));
            ints.Add(new Int32ISerializable(8));
            Serializer<Int32ISerializable>.JSONSerialize("../../../IntJsonCollectionTest", ints);
            CollectionAssert.AreEqual(ints, (ICollection)Serializer<Int32ISerializable>.JSONDeserializeCollection("../../../IntJsonCollectionTest"));
        }
        [TestMethod]
        public void TestStudentJson()
        {
            StudentTestISerializable student = new StudentTestISerializable("Name", "Test", DateTime.Now, 10);
            Serializer<StudentTestISerializable>.JSONSerialize("../../../StudentJsonTest", student);
            Assert.AreEqual(student, Serializer<StudentTestISerializable>.JSONDeserialize("../../../StudentJsonTest"));
        }
        [TestMethod]
        public void TestStudentJsonCollection()
        {
            List<StudentTestISerializable> students = new List<StudentTestISerializable>();
            students.Add(new StudentTestISerializable("Name5", "Test1", DateTime.Now, 10));
            students.Add(new StudentTestISerializable("Name4", "Test2", DateTime.Now, 6));
            students.Add(new StudentTestISerializable("Name3", "Test3", DateTime.Now, 5));
            students.Add(new StudentTestISerializable("Name2", "Test4", DateTime.Now, 8));
            students.Add(new StudentTestISerializable("Name1", "Test5", DateTime.Now, 9));
            Serializer<StudentTestISerializable>.JSONSerialize("../../../StudentJsonCollectionTest", students);
            CollectionAssert.AreEqual(students, (ICollection)Serializer<StudentTestISerializable>.JSONDeserializeCollection("../../../StudentJsonCollectionTest"));
        }
        [TestMethod]
        public void TestIntXml()
        {
            Int32ISerializable int32ISerializable = new Int32ISerializable(10);
            Serializer<Int32ISerializable>.XmlSerialize("../../../IntXmlTest.xml", int32ISerializable);
            Assert.AreEqual(int32ISerializable, Serializer<Int32ISerializable>.XmlDeserialize("../../../IntXmlTest.xml"));
        }
        [TestMethod]
        public void TestIntXmlCollection()
        {
            List<Int32ISerializable> ints = new List<Int32ISerializable>();
            ints.Add(new Int32ISerializable(10));
            ints.Add(new Int32ISerializable(6));
            ints.Add(new Int32ISerializable(3));
            ints.Add(new Int32ISerializable(4));
            ints.Add(new Int32ISerializable(8));
            Serializer<Int32ISerializable>.XmlSerialize("../../../IntXmlCollectionTest.xml", ints);
            CollectionAssert.AreEqual(ints, (ICollection)Serializer<Int32ISerializable>.XmlDeserializeCollection("../../../IntXmlCollectionTest.xml"));
        }
        [TestMethod]
        public void TestStudentXml()
        {
            StudentTestISerializable student = new StudentTestISerializable("Name", "Test", DateTime.Now, 10);
            Serializer<StudentTestISerializable>.XmlSerialize("../../../StudentXmlTest.xml", student);
            Assert.AreEqual(student, Serializer<StudentTestISerializable>.XmlDeserialize("../../../StudentXmlTest.xml"));
        }
        [TestMethod]
        public void TestStudentXmlCollection()
        {
            List<StudentTestISerializable> students = new List<StudentTestISerializable>();
            students.Add(new StudentTestISerializable("Name5", "Test1", DateTime.Now, 10));
            students.Add(new StudentTestISerializable("Name4", "Test2", DateTime.Now, 6));
            students.Add(new StudentTestISerializable("Name3", "Test3", DateTime.Now, 5));
            students.Add(new StudentTestISerializable("Name2", "Test4", DateTime.Now, 8));
            students.Add(new StudentTestISerializable("Name1", "Test5", DateTime.Now, 9));
            Serializer<StudentTestISerializable>.XmlSerialize("../../../StudentXmlCollectionTest.xml", students);
            CollectionAssert.AreEqual(students, (ICollection)Serializer<StudentTestISerializable>.XmlDeserializeCollection("../../../StudentXmlCollectionTest.xml"));
        }
    }
}
