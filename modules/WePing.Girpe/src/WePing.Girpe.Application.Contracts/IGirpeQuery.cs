

namespace WePing.Girpe;
public interface IBaseGirpeQuery
{

}
public interface IGirpeQuery<TResponse>:IBaseGirpeQuery, IRequest<TResponse>
    where TResponse : class
{
}

public abstract record GirpeResponse 
{
    public bool FromDatabase { get; set;}
}
