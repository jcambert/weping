using AutoMapper;
using System.Linq.Expressions;
using WeUtilities;

namespace WeAutoMapper;


public sealed class OnlyForMapping<TSource, TDestination>
{
    private readonly List<(PropertyInformation, PropertyInformation)> members = new();
    private readonly IMappingExpression<TSource, TDestination> mapper;

    public OnlyForMapping(IMappingExpression<TSource, TDestination> mapper)
    {
        this.mapper = mapper;
    }
    public OnlyForMapping<TSource, TDestination> For<TData>(Expression<Func<TSource, TData>> Source, Expression<Func<TDestination, TData>> Destination)
    {
        var propSource = HelperClass<TSource>.Property(Source);
        var propDest = HelperClass<TDestination>.Property(Destination);
        if (propSource == null || propDest == null)
            return this;
        mapper.ForMember(Destination, x => x.MapFrom(Source));
        members.Add((propSource, propDest));
        return this;
    }
    public IMappingExpression<TSource, TDestination> EndOnlyFor(bool ignoreUnmappings = true)
    {

        if (ignoreUnmappings)
            IgnoreUnmapped();
        return mapper;
    }
    private void IgnoreUnmapped()
    {
        List<string> sources = members.Select(x => x.Item2.Name).ToList();

        var notMapped = typeof(TDestination).GetProperties().Where(p => !sources.Contains(p.Name)).ToList();
        foreach (var member in notMapped)
        {
            mapper.ForMember(member.Name, opt => opt.Ignore());
        }
    }
}
