using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationClasses
{
    public static class Serializer<T> where T : ISerializable
    { 

        public static void BinarySerialize(string file, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.OpenOrCreate))
                formatter.Serialize(streamFile, data);
        }
        public static void BinarySerialize(string file, ICollection<T> data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.OpenOrCreate))
                formatter.Serialize(streamFile, data);
        }
        public static T BinaryDeserialize(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.Open))
                return (T)formatter.Deserialize(streamFile); 
        }
        public static ICollection<T> BinaryDeserializeCollection(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.Open))
                return (ICollection<T>)formatter.Deserialize(streamFile);
        }


        public static void JSONSerialize(string file, T data)
        {
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream);
                JsonSerializer.Serialize(jsonWriter, data);
                jsonWriter.Dispose();
            }
           
        }
        public static void JSONSerialize(string file, ICollection<T> data)
        {
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream);
                JsonSerializer.Serialize(jsonWriter, data);
                jsonWriter.Dispose();
            }

        }
        public static T JSONDeserialize(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
                return (T)JsonSerializer.Deserialize(streamReader.ReadToEnd(), typeof(T));
        }
        public static ICollection<T> JSONDeserializeCollection(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
                return (ICollection<T>)JsonSerializer.Deserialize(streamReader.ReadToEnd(), typeof(ICollection<T>));
        }



        public static void XmlSerialize(string file, T data)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
                xmlSerialize.Serialize(stream, data);
        }
        public static void XmlSerialize(string file, ICollection<T> data)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<T>));
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
                    xmlSerialize.Serialize(stream, data.ToList<T>());
        }
        public static T XmlDeserialize(string file)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            using (Stream stream = File.Open(file, FileMode.Open))
                return (T)xmlSerialize.Deserialize(stream);
        }
        public static ICollection<T> XmlDeserializeCollection(string file)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<T>));
            using (Stream stream = File.Open(file, FileMode.Open))
                return (ICollection<T>)xmlSerialize.Deserialize(stream);
        }



    }
}
