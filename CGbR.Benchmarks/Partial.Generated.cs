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
    public partial class Partial
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
                var size = 18;
                // Add size for collections and strings
                size += Name.Length;
                size += DecimalNumbers.Count * 8;
                size += SomeNumbers.Count() * 8;
  
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
            // Convert Id
            // Convert Price
            // Convert Name
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)Name.Length), 0, bytes, index, 2);
            index += 2;
            // Convert DecimalNumbers
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)DecimalNumbers.Count), 0, bytes, index, 2);
            index += 2;
            // Convert SomeNumbers
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((short)SomeNumbers.Count()), 0, bytes, index, 2);
            index += 2;
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public Partial FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Partial FromBytes(byte[] bytes, ref int index)
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

            writer.Append("\"Id\":");
            writer.Append(Id.ToString(CultureInfo.InvariantCulture));
    
            writer.Append(",\"Price\":");
            writer.Append(Price.ToString(CultureInfo.InvariantCulture));
    
            writer.Append(",\"Name\":");
            writer.Append(string.Format("\"{0}\"", Name));
    
            writer.Append(",\"DecimalNumbers\":");
            if (DecimalNumbers == null)
                writer.Append("null");
            else
            {
                writer.Append('[');
                foreach (var value in DecimalNumbers)
                {
            		writer.Append(value.ToString(CultureInfo.InvariantCulture));
                    writer.Append(',');
                }
                writer.Append(']');
            }
    
            writer.Append(",\"SomeNumbers\":");
            if (SomeNumbers == null)
                writer.Append("null");
            else
            {
                writer.Append('[');
                foreach (var value in SomeNumbers)
                {
            		writer.Append(value.ToString(CultureInfo.InvariantCulture));
                    writer.Append(',');
                }
                writer.Append(']');
            }
    
            writer.Append('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public Partial FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public Partial FromJson(JsonReader reader)
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
                    case "Id":
                        reader.Read();
                        Id = Convert.ToInt64(reader.Value);
                        break;

                    case "Price":
                        reader.Read();
                        Price = Convert.ToSingle(reader.Value);
                        break;

                    case "Name":
                        reader.Read();
                        Name = Convert.ToString(reader.Value);
                        break;

                    case "DecimalNumbers":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var decimalnumbers = new List<double>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            decimalnumbers.Add(Convert.ToDouble(reader.Value));
                        DecimalNumbers = decimalnumbers;
                        break;

                    case "SomeNumbers":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var somenumbers = new List<ulong>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            somenumbers.Add(Convert.ToUInt64(reader.Value));
                        SomeNumbers = somenumbers;
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}