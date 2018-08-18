using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
    public static class Loader
    {
        public static object DeserializeObject(string Str, Type T)
        {
            XmlSerializer Serializer = new XmlSerializer(T);
            MemoryStream MS = new MemoryStream(Encoding.UTF8.GetBytes(Str));
            object Result = Serializer.Deserialize(MS);
            MS.Close();
            return Result;
        }

        public static List<FloatShape> DeserializeWorld(string XMLFile)
        {
            List<FloatShape> Result = new List<FloatShape>();
            XDocument Doc = XDocument.Load(XMLFile);
            foreach (XElement Elem in Doc.Root.Elements())
            {
                if (Elem.Name == "FloatRect")
                    Result.Add(DeserializeObject(Elem.ToString(), typeof(FloatRect)) as FloatRect);
                else
                    if (Elem.Name == "FloatCircle")
                        Result.Add(DeserializeObject(Elem.ToString(), typeof(FloatCircle)) as FloatCircle);
                    else
                        if (Elem.Name == "FloatPolygon")
                            Result.Add(DeserializeObject(Elem.ToString(), typeof(FloatPolygon)) as FloatPolygon);
                        else
                            if (Elem.Name == "FloatLine")
                                Result.Add(DeserializeObject(Elem.ToString(), typeof(FloatLine)) as FloatLine);
            }
            return Result;
        }

        static void SerializeObject(XmlWriter Writer, Object Obj)
        {
			/*
            MemoryStream MS = new MemoryStream();
            XmlSerializer Serializer = new XmlSerializer(Obj.GetType());
            Serializer.Serialize(MS, Obj);
            string str = Encoding.Default.GetString(MS.ToArray());
            str = str.Remove(0, 23);
            int ind = str.IndexOf("xmlns");
            str = str.Remove(ind, str.LastIndexOf(@"XMLSchema") + 12 - ind - 1) + Environment.NewLine;
            Writer.WriteRaw(str);
		  * */
        }

        public static void SerializeWorld(string XMLFile, List<FloatShape> Bodies)
        {
            /*XmlWriterSettings Settings = new XmlWriterSettings();
            Settings.Indent = true;
            Settings.IndentChars = "    ";
            XmlWriter Writer = XmlWriter.Create(XMLFile, Settings);

            Writer.WriteStartDocument();
            Writer.WriteStartElement("Bodies");
            Writer.WriteRaw(Environment.NewLine);

            Bodies.ForEach(Body => SerializeObject(Writer, Body));

            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();*/
        }
    }
}
