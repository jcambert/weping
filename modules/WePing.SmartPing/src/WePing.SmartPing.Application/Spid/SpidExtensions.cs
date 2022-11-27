using System.Runtime.CompilerServices;

using System.Collections.Generic;
using System.Linq;

[assembly: InternalsVisibleTo("WePing.SmartPing.Application.Tests")]
namespace WePing.SmartPing.Spid;

internal static  class SpidExtensions
{
    public static Dictionary<string, string> ToDictionnary<T>(this T o,bool ignoreIfNull=true)
        where T: IBaseSpidRequestQuery
    {
        var result = new Dictionary<string, string>();
        var props = o.GetType().GetProperties();
        props.ToList().ForEach(p =>
        {
            string key = p.Name.ToLower();
            string value = p.GetGetMethod().Invoke(o, null)?.ToString();
            if (value == null && !ignoreIfNull)
                result[key] = string.Empty;
            else if( value!=null)
                result[key] = value ;
        });
        return result;
    }
}
