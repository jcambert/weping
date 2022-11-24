using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WePing.SmartPing.Spid;

public class SpidEndPointsOptions
{
    public string EndPoint { get; set; }

    public Dictionary<string, string> Api { get; set; }

    public string GetApi(string point) => EndPoint + string.Format(Api["endpoint"], Api[point]);

    public string this[string name]
    {
        get
        {
            string res;
            try
            {
                res = GetApi(name) ?? "";
                // if (res == "")
                //    _logger.LogWarning($"This SpidOption was not defined in spid section in appsetting.json:{name}");
            }
            catch (Exception e)
            {
                var message = $"This SpidOption was not defined in spid section in appsetting.json:{name}  -> {e.Message}";
                //_logger.LogError(message);
                throw new Exception(message);
            }
            return res;
        }
    }
}


public class SpidRequestOptions
{

    public SpidRequestOptions()
    {
       
    }
    /// <summary>
    /// Set Http LifeTime in seconds
    /// </summary>
    public double HttpLifetime { get; set; } = 5 * 60; // 5 Minutes


    /// <summary>
    /// Retry count on http request failure
    /// </summary>
    public int RetryCount { get; set; } = 5;



    

}
