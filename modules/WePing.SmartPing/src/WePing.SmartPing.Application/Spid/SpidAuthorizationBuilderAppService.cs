



namespace WePing.SmartPing.Spid;


public class SpidAuthorizationBuilderAppService : SmartPingAppService, ISpidAuthorizationBuilderAppService
{
    protected  SpidAuthorizationOptions SpidOptions {get;init; }

    protected  string Key { get; init; }

    public SpidAuthorizationBuilderAppService(IOptions< SpidAuthorizationOptions> options) => (SpidOptions,Key) = (options.Value,CreateKey(options.Value.Password));

    public virtual Task<SpidAuthorization> GetAsync() => Task.FromResult(Create());
    public virtual SpidAuthorization Get()=>Create();

    protected virtual SpidAuthorization Create()
    {
        var tm = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        return new SpidAuthorization /*(){Tm=tm,Tmc= GetHash(tm, Key) };*/ (tm, GetHash(tm, Key) );
    }
    protected virtual string CreateKey(string password)
    {
        var ccle = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(ccle).Replace("-", string.Empty).ToLower();
    }

    private string GetHash(string tm, string key)
    {
        UTF8Encoding encoding = new UTF8Encoding();

        Byte[] textBytes = encoding.GetBytes(tm);
        Byte[] keyBytes = encoding.GetBytes(key);

        Byte[] hashBytes;

        using (HMACSHA1 hash = new HMACSHA1(keyBytes))
            hashBytes = hash.ComputeHash(textBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

    }

    
}
