/*
 * This code was generated by the CGbR generator on 18.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using CGbR.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CGbR.GeneratorTests
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class ByteProperties
    {
        #region BinarySerializer

        private static Encoding _encoder = new UTF8Encoding();

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 3;
                // Add size for collections and strings
                size += Bytes.Length;
  
                return size;              
            }
        }

        /// <summary>
        /// Convert object to bytes
        /// </summary>
        public byte[] ToBytes()
        {
            var index = 0;
            var bytes = new byte[Size];

            return ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert SingleByte
            bytes[index] = SingleByte;
            index += 1;
            // Convert Bytes
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Bytes == null ? 0 : Bytes.Length), bytes, index);
            index += 2;
            if (Bytes != null)
            {
            	Buffer.BlockCopy(Bytes, 0, bytes, index, Bytes.Length);
            	index += Bytes.Length;
            }
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public ByteProperties FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public ByteProperties FromBytes(byte[] bytes, ref int index)
        {
            // Read SingleByte
            SingleByte = bytes[index];
            index += 1;
            // Read Bytes
            var bytesLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempBytes = new byte[bytesLength];
            for (var i = 0; i < bytesLength; i++)
            {
            	var value = bytes[index];
            	index += 1;
                tempBytes[i] = value;
            }
            Bytes = tempBytes;

            return this;
        }

        
        #endregion

        #region JsonSerializer

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public string ToJson()
        {
            var builder = new StringBuilder();
            using(var writer = new StringWriter(builder))
            {
                IncludeJson(writer);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(TextWriter writer)
        {
            writer.Write('{');

            writer.Write("\"SingleByte\":");
            writer.Write(SingleByte.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Bytes\":");
            if (Bytes == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Bytes)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public ByteProperties FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public ByteProperties FromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                // Break on EndObject
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                // Only look for properties
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                switch ((string) reader.Value)
                {
                    case "SingleByte":
                        reader.Read();
                        SingleByte = Convert.ToByte(reader.Value);
                        break;

                    case "Bytes":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var bytes = new List<byte>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            bytes.Add(Convert.ToByte(reader.Value));
                        Bytes = bytes.ToArray();
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}