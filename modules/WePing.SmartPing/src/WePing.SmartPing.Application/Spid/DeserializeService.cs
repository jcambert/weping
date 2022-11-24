using System.IO;
using System.Xml.Serialization;

namespace WePing.SmartPing.Spid;

public  class DeserializeService<T> :  IDeserializeService<T>
{
    public XmlSerializer Serializer { get; init; }
    public DeserializeService() => (Serializer) = (new XmlSerializer(typeof(T)));
    public T To(Stream data) => ((T)Serializer.Deserialize(data));
}
