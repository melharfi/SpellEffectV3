using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SpellEffectV3.Items
{
    public static class Deserialize
    {
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
    }
}
