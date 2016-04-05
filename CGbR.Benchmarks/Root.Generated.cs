/*
 * This code was generated by the CGbR generator on 05.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CGbR.Benchmarks
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class Root
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
                var size = 20;
                // Add size for collections and strings
                size += Description.Length;
                size += PartialsList.Sum(entry => entry.Size);
                size += PartialsArray.Sum(entry => entry.Size);
  
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
            // Convert Number
            // Convert Price
            // Convert Description
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)Description.Length), 0, bytes, index, 2);
            index += 2;
            // Convert PartialsList
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)PartialsList.Count), 0, bytes, index, 2);
            index += 2;
            // Convert PartialsArray
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)PartialsArray.Length), 0, bytes, index, 2);
            index += 2;
            // Convert SmallNumber
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public Root FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Root FromBytes(byte[] bytes, ref int index)
        {
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
            IncludeJson(builder);
            return builder.ToString();
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(StringBuilder writer)
        {
            writer.Append('{');

            writer.Append("\"Number\":");
            writer.Append(Number.ToString(CultureInfo.InvariantCulture));
    
            writer.Append(",\"Price\":");
            writer.Append(Price.ToString(CultureInfo.InvariantCulture));
    
            writer.Append(",\"Description\":");
            writer.Append(string.Format("\"{0}\"", Description));
    
            writer.Append(",\"PartialsList\":");
            if (PartialsList == null)
                writer.Append("null");
            else
            {
                writer.Append('[');
                foreach (var value in PartialsList)
                {
            		value.IncludeJson(writer);
                    writer.Append(',');
                }
                writer.Append(']');
            }
    
            writer.Append(",\"PartialsArray\":");
            if (PartialsArray == null)
                writer.Append("null");
            else
            {
                writer.Append('[');
                foreach (var value in PartialsArray)
                {
            		value.IncludeJson(writer);
                    writer.Append(',');
                }
                writer.Append(']');
            }
    
            writer.Append(",\"SmallNumber\":");
            writer.Append(SmallNumber.ToString(CultureInfo.InvariantCulture));
    
            writer.Append('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public Root FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public Root FromJson(JsonReader reader)
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
                    case "Number":
                        reader.Read();
                        Number = Convert.ToInt32(reader.Value);
                        break;

                    case "Price":
                        reader.Read();
                        Price = Convert.ToDouble(reader.Value);
                        break;

                    case "Description":
                        reader.Read();
                        Description = Convert.ToString(reader.Value);
                        break;

                    case "SmallNumber":
                        reader.Read();
                        SmallNumber = Convert.ToUInt16(reader.Value);
                        break;

                    case "PartialsList":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialslist = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialslist.Add(new Partial().FromJson(reader));
                        PartialsList = partialslist;
                        break;

                    case "PartialsArray":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialsarray = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialsarray.Add(new Partial().FromJson(reader));
                        PartialsArray = partialsarray.ToArray();
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}