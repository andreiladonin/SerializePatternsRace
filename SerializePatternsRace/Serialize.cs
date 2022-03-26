using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializePatternsRace
{
    public interface ISerialize<T>
    {
        void Serialize(string pathToSave, T type);
    }

    public class SerializeToJson<T> : ISerialize<T>
    {
        public void Serialize(string pathToSave, T type)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(type, options);

            using (var sw = new StreamWriter(pathToSave, false, Encoding.UTF8))
            {
                sw.Write(json);
            }
        }
    }

    public class SerializeToXml<T> : ISerialize<T>
    {
        public void Serialize(string pathToSave, T type)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(pathToSave, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, type);
            }
        }
    }
}

