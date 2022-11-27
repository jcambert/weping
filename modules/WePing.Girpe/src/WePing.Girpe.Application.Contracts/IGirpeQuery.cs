namespace WePing.Girpe;
public interface IBaseGirpeQuery
{

}
public interface IGirpeQuery:IBaseGirpeQuery
{
}

public abstract record GirpeResponse 
{
    public bool FromDatabase { get; set;}
}
