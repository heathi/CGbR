/*
 * This code was generated by the CGbR generator on 20.04.2016. Any manual changes will be lost on the next build.
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
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert Id
            GeneratorByteConverter.Include(Id, bytes, index);
            index += 8;
            // Convert Price
            GeneratorByteConverter.Include(Price, bytes, index);
            index += 4;
            // Convert Name
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Name == null ? 0 : Name.Length), bytes, index);
            index += 2;
            if (Name != null)
            {
            	Buffer.BlockCopy(_encoder.GetBytes(Name), 0, bytes, index, Name.Length);
            	index += Name.Length;
            }
            // Convert DecimalNumbers
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(DecimalNumbers == null ? 0 : DecimalNumbers.Count), bytes, index);
            index += 2;
            if (DecimalNumbers != null)
            {
                for(var i = 0; i < DecimalNumbers.Count; i++)
                {
                    var value = DecimalNumbers[i];
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 8;
                }
            }
            // Convert SomeNumbers
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(SomeNumbers == null ? 0 : SomeNumbers.Count()), bytes, index);
            index += 2;
            if (SomeNumbers != null)
            {
                foreach(var value in SomeNumbers)
                {
            		GeneratorByteConverter.Include(value, bytes, index);
            		index += 8;
                }
            }
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
            // Read Id
            Id = BitConverter.ToInt64(bytes, index);
            index += 8;
            // Read Price
            Price = BitConverter.ToSingle(bytes, index);
            index += 4;
            // Read Name
            var nameLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            Name = _encoder.GetString(bytes, index, nameLength);
            index += nameLength;
            // Read DecimalNumbers
            var decimalnumbersLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempDecimalNumbers = new List<double>(decimalnumbersLength);
            for (var i = 0; i < decimalnumbersLength; i++)
            {
            	var value = BitConverter.ToDouble(bytes, index);
            	index += 8;
                tempDecimalNumbers.Add(value);
            }
            DecimalNumbers = tempDecimalNumbers;
            // Read SomeNumbers
            var somenumbersLength = BitConverter.ToUInt16(bytes, index);
            index += 2;
            var tempSomeNumbers = new List<ulong>(somenumbersLength);
            for (var i = 0; i < somenumbersLength; i++)
            {
            	var value = BitConverter.ToUInt64(bytes, index);
            	index += 8;
                tempSomeNumbers.Add(value);
            }
            SomeNumbers = tempSomeNumbers;

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

            writer.Write("\"Id\":");
            writer.Write(Id.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Price\":");
            writer.Write(Price.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Name\":");
            writer.Write(string.Format("\"{0}\"", Name));
    
            writer.Write(",\"DecimalNumbers\":");
            if (DecimalNumbers == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in DecimalNumbers)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"SomeNumbers\":");
            if (SomeNumbers == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in SomeNumbers)
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