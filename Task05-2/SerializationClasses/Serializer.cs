using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationClasses
{
    /// <summary>
    /// Serialize class T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Serializer<T> where T : ISerializable
    {
        /// <summary>
        /// Binary serialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void BinarySerialize(string file, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.OpenOrCreate))
                formatter.Serialize(streamFile, data);
        }
        /// <summary>
        /// Binary serialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void BinarySerialize(string file, ICollection<T> data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.OpenOrCreate))
                formatter.Serialize(streamFile, data);
        }
        /// <summary>
        /// Binary deserialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Object T.</returns>
        public static T BinaryDeserialize(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.Open))
                return (T)formatter.Deserialize(streamFile); 
        }
        /// <summary>
        /// Binary deserialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Collection T.</returns>
        public static ICollection<T> BinaryDeserializeCollection(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            using (Stream streamFile = File.Open(file, FileMode.Open))
                return (ICollection<T>)formatter.Deserialize(streamFile);
        }




        /// <summary>
        /// Json serialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void JSONSerialize(string file, T data)
        {
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream);
                JsonSerializer.Serialize(jsonWriter, data);
                jsonWriter.Dispose();
            }
           
        }
        /// <summary>
        /// Json serialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void JSONSerialize(string file, ICollection<T> data)
        {
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream);
                JsonSerializer.Serialize(jsonWriter, data);
                jsonWriter.Dispose();
            }

        }
        /// <summary>
        /// Json deserialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Object T.</returns>
        public static T JSONDeserialize(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
                return (T)JsonSerializer.Deserialize(streamReader.ReadToEnd(), typeof(T));
        }
        /// <summary>
        /// Json deserialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Collection T.</returns>
        public static ICollection<T> JSONDeserializeCollection(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
                return (ICollection<T>)JsonSerializer.Deserialize(streamReader.ReadToEnd(), typeof(ICollection<T>));
        }



        /// <summary>
        /// Xml serialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void XmlSerialize(string file, T data)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
                xmlSerialize.Serialize(stream, data);
        }
        /// <summary>
        /// Xml serialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="data">Data.</param>
        public static void XmlSerialize(string file, ICollection<T> data)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<T>));
            using (Stream stream = File.Open(file, FileMode.OpenOrCreate))
                    xmlSerialize.Serialize(stream, data.ToList<T>());
        }
        /// <summary>
        /// Xml deserialize class T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Object T.</returns>
        public static T XmlDeserialize(string file)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            using (Stream stream = File.Open(file, FileMode.Open))
                return (T)xmlSerialize.Deserialize(stream);
        }
        /// <summary>
        /// Xml deserialize collection T.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Collection T.</returns>
        public static ICollection<T> XmlDeserializeCollection(string file)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<T>));
            using (Stream stream = File.Open(file, FileMode.Open))
                return (ICollection<T>)xmlSerialize.Deserialize(stream);
        }
    }
}
