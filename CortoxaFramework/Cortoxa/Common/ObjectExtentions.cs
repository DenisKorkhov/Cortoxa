using System.IO;
using System.Xml.Serialization;

namespace Cortoxa.Common
{
    public static class ObjectExtentions
    {
        public static string Serialize<T>(this T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, value);
                return textWriter.ToString();
            }
        }

        public static void Serialize<T>(this T value, Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, value);
        }

        public static T Deserialize<T>(this string value)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var textReader = new StringReader(value))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }

        public static T Deserialize<T>(this Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}