namespace WePing.SmartPing.Spid;

public interface IGetQuery:ISpidRequestQuery
{
    IBaseSpidRequestQuery Query { get; set; }
    string EndPoint { get; set; }
}

