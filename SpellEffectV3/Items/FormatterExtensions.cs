using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using System.Collections;

namespace SpellEffectV3.Items
{
    public static class FormatterExtensions
    {
        public static byte[] ToBinary(this object obj)
        {
            var formatter = new BinaryFormatter
                (null, new StreamingContext(StreamingContextStates.All));
            using (var stream = new MemoryStream())
            {
                formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter.Serialize(stream, obj);

                return stream.ToArray();
            }
        }

        public static T ToObject<T>(this byte[] bytes)
        {
            var formatter = new BinaryFormatter
                (null, new StreamingContext(StreamingContextStates.All));
            using (var stream = new MemoryStream(bytes))
            {
                formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T ToObject<T>(this byte[] bytes, SerializationBinder binder)
        {
            var formatter = new BinaryFormatter
                (null, new StreamingContext(StreamingContextStates.All));
            using (var stream = new MemoryStream(bytes))
            {
                formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter.Binder = binder;

                return (T)formatter.Deserialize(stream);
            }
        }

        public static string ToCSV(this IEnumerable enumerable, string separator)
        {
            var builder = new StringBuilder();
            var count = 0;
            foreach (var entity in enumerable)
            {
                builder.Append(entity);
                builder.Append(separator);
                count++;
            }
            if (count > 0)
                builder.Remove(builder.Length - separator.Length, separator.Length);
            return builder.ToString();
        }

        public static string ToCSV<T>(this IEnumerable<T> enumerable, string separator, Func<T, string> formatter)
        {
            var builder = new StringBuilder();
            int count = 0;
            foreach (var entity in enumerable)
            {
                builder.Append(formatter(entity));
                builder.Append(separator);
                count++;
            }
            if (count > 0)
                builder.Remove(builder.Length - separator.Length, separator.Length);

            return builder.ToString();
        }

        public static T[] FromCSV<T>(this string csvValue, string separator)
            where T : IConvertible
        {
            var result = new List<T>();
            int lastIndex = 0;
            int i = csvValue.IndexOf(separator, StringComparison.Ordinal);
            while (i >= 0 && i < csvValue.Length)
            {
                result.Add((T)Convert.ChangeType(csvValue.Substring(lastIndex, i - lastIndex), typeof(T)));
                lastIndex = i + separator.Length;
                i = csvValue.IndexOf(separator, lastIndex, StringComparison.Ordinal);
            }
            if (!string.IsNullOrEmpty(csvValue))
                result.Add(
                    (T)Convert.ChangeType(csvValue.Substring(lastIndex, csvValue.Length - lastIndex), typeof(T)));

            return result.ToArray();
        }

        public static T[] FromCSV<T>(this string csvValue, string separator, Func<string, T> converter)
        {
            var result = new List<T>();
            int lastIndex = 0;
            int i = csvValue.IndexOf(separator, StringComparison.Ordinal);
            while (i >= 0 && i < csvValue.Length)
            {
                result.Add(converter(csvValue.Substring(lastIndex, i - lastIndex)));
                lastIndex = i + separator.Length;
                i = csvValue.IndexOf(separator, lastIndex, StringComparison.Ordinal);
            }
            if (!string.IsNullOrEmpty(csvValue))
                result.Add(converter(csvValue.Substring(lastIndex, csvValue.Length - lastIndex)));
            return result.ToArray();
        }
    }
}
