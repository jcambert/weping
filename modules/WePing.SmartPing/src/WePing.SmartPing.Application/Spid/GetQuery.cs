namespace WePing.SmartPing.Spid;

public class GetQuery:IGetQuery
{
    public IBaseSpidRequestQuery Query { get; set; }

    public string EndPoint { get; set; }
}
