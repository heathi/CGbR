/*
 * This code was generated by the CGbR generator on 29.05.2016. Any manual changes will be lost on the next build.
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
    public partial class DifferentCollections : IByteSerializable
    {
        #region BinarySerializer

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 10;
                // Add size for collections and strings
                size += Integers == null ? 0 : Integers.Count() * 4;
                size += Doubles == null ? 0 : Doubles.Count * 8;
                size += Longs == null ? 0 : Longs.Length * 8;
                size += Times == null ? 0 : Times.Count * 8;
                size += Names == null ? 0 : Names.Sum(s => s.Length + 2);
  
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
        void IByteSerializable.ToBytes(byte[] bytes, ref int index)
        {
            ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert Integers
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Integers == null ? 0 : Integers.Count()), bytes, ref index);
            if (Integers != null)
            {
                foreach(var value in Integers)
                {
            		GeneratorByteConverter.Include(value, bytes, ref index);
                }
            }
            // Convert Doubles
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Doubles == null ? 0 : Doubles.Count), bytes, ref index);
            if (Doubles != null)
            {
                for(var i = 0; i < Doubles.Count; i++)
                {
                    var value = Doubles[i];
            		GeneratorByteConverter.Include(value, bytes, ref index);
                }
            }
            // Convert Longs
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Longs == null ? 0 : Longs.Length), bytes, ref index);
            if (Longs != null)
            {
                for(var i = 0; i < Longs.Length; i++)
                {
                    var value = Longs[i];
            		GeneratorByteConverter.Include(value, bytes, ref index);
                }
            }
            // Convert Times
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Times == null ? 0 : Times.Count), bytes, ref index);
            if (Times != null)
            {
                for(var i = 0; i < Times.Count; i++)
                {
                    var value = Times[i];
            		GeneratorByteConverter.Include(value.ToBinary(), bytes, ref index);
                }
            }
            // Convert Names
            // Two bytes length information for each dimension
            GeneratorByteConverter.Include((ushort)(Names == null ? 0 : Names.Count), bytes, ref index);
            if (Names != null)
            {
                foreach(var value in Names)
                {
            		GeneratorByteConverter.Include(value, bytes, ref index);
                }
            }
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public DifferentCollections FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        void IByteSerializable.FromBytes(byte[] bytes, ref int index)
        {
            FromBytes(bytes, ref index);
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public DifferentCollections FromBytes(byte[] bytes, ref int index)
        {
            // Read Integers
            var integersLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempIntegers = new List<int>(integersLength);
            for (var i = 0; i < integersLength; i++)
            {
            	var value = GeneratorByteConverter.ToInt32(bytes, ref index);
                tempIntegers.Add(value);
            }
            Integers = tempIntegers;
            // Read Doubles
            var doublesLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempDoubles = new List<double>(doublesLength);
            for (var i = 0; i < doublesLength; i++)
            {
            	var value = GeneratorByteConverter.ToDouble(bytes, ref index);
                tempDoubles.Add(value);
            }
            Doubles = tempDoubles;
            // Read Longs
            var longsLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempLongs = new long[longsLength];
            for (var i = 0; i < longsLength; i++)
            {
            	var value = GeneratorByteConverter.ToInt64(bytes, ref index);
                tempLongs[i] = value;
            }
            Longs = tempLongs;
            // Read Times
            var timesLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempTimes = new List<DateTime>(timesLength);
            for (var i = 0; i < timesLength; i++)
            {
            	var value = DateTime.FromBinary(GeneratorByteConverter.ToInt64(bytes, ref index));
                tempTimes.Add(value);
            }
            Times = tempTimes;
            // Read Names
            var namesLength = GeneratorByteConverter.ToUInt16(bytes, ref index);
            var tempNames = new List<string>(namesLength);
            for (var i = 0; i < namesLength; i++)
            {
            	var value = GeneratorByteConverter.GetString(bytes, ref index);
                tempNames.Add(value);
            }
            Names = tempNames;

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

            writer.Write("\"Integers\":");
            if (Integers == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Integers)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Doubles\":");
            if (Doubles == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Doubles)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Longs\":");
            if (Longs == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Longs)
                {
            		writer.Write(value.ToString(CultureInfo.InvariantCulture));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Times\":");
            if (Times == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Times)
                {
            		//value.IncludeJson(writer);
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"Names\":");
            if (Names == null)
            {
                writer.Write("null");
            }
            else
            {
                writer.Write('[');
                foreach (var value in Names)
                {
            		writer.Write(string.Format("\"{0}\"", value));
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public DifferentCollections FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public DifferentCollections FromJson(JsonReader reader)
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
                    case "Integers":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var integers = new List<int>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            integers.Add(Convert.ToInt32(reader.Value));
                        Integers = integers;
                        break;

                    case "Doubles":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var doubles = new List<double>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            doubles.Add(Convert.ToDouble(reader.Value));
                        Doubles = doubles;
                        break;

                    case "Longs":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var longs = new List<long>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            longs.Add(Convert.ToInt64(reader.Value));
                        Longs = longs.ToArray();
                        break;

                    case "Times":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var times = new List<DateTime>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            //times.Add(new DateTime().FromJson(reader));
                        Times = times;
                        break;

                    case "Names":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var names = new List<string>();
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            names.Add(Convert.ToString(reader.Value));
                        Names = names;
                        break;

                }
            }

            return this;
        }

        
        #endregion

        #region Cloneable

        /// <summary>
        /// Method to create a deep or shallow copy of this object
        /// </summary>
        public DifferentCollections Clone(bool deep)
        {
            var copy = new DifferentCollections();
            if (deep)
            {
                // In a deep clone the references are cloned 
                var tempIntegers = new List<int>(Integers.Count());
                foreach (var value in Integers)
                {
                    tempIntegers.Add(value);
                }
                copy.Integers = tempIntegers;
                var tempDoubles = new List<double>(Doubles.Count);
                for (var i = 0; i < Doubles.Count; i++)
                {
                    var value = Doubles[i];
                    tempDoubles[i] = value;
                }
                copy.Doubles = tempDoubles;
                var tempLongs = new long[Longs.Length];
                for (var i = 0; i < Longs.Length; i++)
                {
                    var value = Longs[i];
                    tempLongs[i] = value;
                }
                copy.Longs = tempLongs;
                var tempTimes = new List<DateTime>(Times.Count);
                for (var i = 0; i < Times.Count; i++)
                {
                    var value = Times[i];
                    //Can not clone it - just copy it
                    tempTimes[i] = value;
                }
                copy.Times = tempTimes;
                var tempNames = new List<string>(Names.Count);
                foreach (var value in Names)
                {
                    tempNames.Add(value);
                }
                copy.Names = tempNames;
            }
            else
            {
                // In a shallow clone only references are copied
                copy.Integers = Integers; 
                copy.Doubles = Doubles; 
                copy.Longs = Longs; 
                copy.Times = Times; 
                copy.Names = Names; 
            }
            return copy;
        }

        
        #endregion

    }
}