using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISerializeClasses
{
    [Serializable]
    public class Int32ISerializable : ISerializable
    {
        public int Data { get; set; }

        public Int32ISerializable()
        {
            Data = 0;
        }

        public Int32ISerializable(int data)
        {
            Data = data;
        }

        public Int32ISerializable(SerializationInfo info, StreamingContext context)
        {
            Data = (int)info.GetValue("Data", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", Data);
        }

        public override bool Equals(object obj)
        {
            return obj is Int32ISerializable serialize &&
                   Data == serialize.Data;
        }

        public override int GetHashCode()
        {
            return -301143667 + Data.GetHashCode();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
