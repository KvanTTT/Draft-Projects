using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("sortedList")]
[Serializable]
public class SerializableSortedList<TKey, TValue> : SortedList<TKey, TValue>, IXmlSerializable
{
	#region IXmlSerializable Members

	public System.Xml.Schema.XmlSchema GetSchema()
	{
		return null;
	}

	public void ReadXml(System.Xml.XmlReader reader)
	{
		XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
		XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

		bool wasEmpty = reader.IsEmptyElement;
		reader.Read();

		if (wasEmpty)
			return;

		var isKeySimpleType = typeof(TKey).IsEnum || typeof(TKey).IsValueType || typeof(TKey) == typeof(string);
		while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
		{
			reader.ReadStartElement("item");

			reader.ReadStartElement("key");
			TKey key = default(TKey);
			if (isKeySimpleType)
			{
				if (typeof(TKey) == typeof(string))
				{
					Object t = reader.GetAttribute("key_value");
					key = (TKey)t;
				}
			}
			else
				key = (TKey)valueSerializer.Deserialize(reader);
			reader.ReadEndElement();

			reader.ReadStartElement("value");
			TValue value = (TValue)valueSerializer.Deserialize(reader);
			reader.ReadEndElement();

			this.Add(key, value);

			reader.ReadEndElement();
			reader.MoveToContent();
		}
		reader.ReadEndElement();
	}

	public void WriteXml(System.Xml.XmlWriter writer)
	{
		XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
		XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

		var namespaces = new XmlSerializerNamespaces();
		namespaces.Add(string.Empty, string.Empty);

		var isKeySimpleType = typeof(TKey).IsEnum || typeof(TKey).IsValueType || typeof(TKey) == typeof(string);
		foreach (TKey key in this.Keys)
		{
			writer.WriteStartElement("item");

			writer.WriteStartElement("key");
			if (isKeySimpleType)
				writer.WriteAttributeString("key_value", key.ToString());
			else
				keySerializer.Serialize(writer, key, namespaces);
			writer.WriteEndElement();

			writer.WriteStartElement("value");
			TValue value = this[key];
			valueSerializer.Serialize(writer, value, namespaces);
			writer.WriteEndElement();

			writer.WriteEndElement();
		}
	}

	#endregion
}
