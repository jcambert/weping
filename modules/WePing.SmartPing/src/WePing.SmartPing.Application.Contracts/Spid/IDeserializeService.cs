using System.IO;

namespace WePing.SmartPing.Spid;

public interface IDeserializeService<T> 
{
    T To(Stream data);
}
