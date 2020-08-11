using System;
using System.Runtime.Serialization;

namespace ISerializeClasses
{
    /// <summary>
    /// Int32 and ISerializable.
    /// </summary>
    [Serializable]
    public class Int32ISerializable : ISerializable
    {
        /// <summary>
        /// Int32 number.
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        /// Create Int32ISerializable object.
        /// </summary>
        public Int32ISerializable()
        {
            Data = 0;
        }

        /// <summary>
        /// Create Int32ISerializable object. 
        /// </summary>
        /// <param name="data">Int32 number.</param>
        public Int32ISerializable(int data)
        {
            Data = data;
        }
        /// <summary>
        /// Create Int32ISerializable object. 
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Context.</param>
        public Int32ISerializable(SerializationInfo info, StreamingContext context)
        {
            Data = (int)info.GetValue("Data", typeof(int));
        }
        /// <summary>
        /// Get object data.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", Data);
        }
        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Int32ISerializable serialize &&
                   Data == serialize.Data;
        }
        /// <summary>
        /// Get object hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return -301143667 + Data.GetHashCode();
        }
        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>Result.</returns>
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
