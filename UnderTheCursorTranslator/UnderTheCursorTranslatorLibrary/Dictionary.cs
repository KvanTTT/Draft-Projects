using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace UnderTheCursorTranslatorLibrary
{
	public class Dictionary
	{
		public static SerializableSortedList<string, TranscriptionTranslation> XdxfToSortedList(Stream stream)
		{
			var sortedList = new SerializableSortedList<string, TranscriptionTranslation>();
			var document = XDocument.Load(stream);
			var documentElements = document.Element("xdxf").Elements("ar");
			foreach (var element in documentElements)
			{
				var transcriptionTranslate = new TranscriptionTranslation
				{
					Transcription = element.Element("tr") == null ? string.Empty : element.Element("tr").Value,
					Translation = element.Value
				};

				sortedList.Add(element.Element("k").Value, transcriptionTranslate);
			}

			return sortedList;
		}

		public static Stream SortedListToXml(SerializableSortedList<string, TranscriptionTranslation> sortedList)
		{
			var stream = new MemoryStream(sortedList.Count * 10);
			var xmlWriter = XmlWriter.Create(stream);
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("root");
			sortedList.WriteXml(xmlWriter);
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();

			return stream;
		}

		public static Stream SortedListToBin(SerializableSortedList<string, TranscriptionTranslation> sortedList)
		{
			var stream = new MemoryStream(sortedList.Count * 10);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(stream, sortedList);
			return stream;
		}
	}
}
