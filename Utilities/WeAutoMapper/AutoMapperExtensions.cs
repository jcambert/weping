using WeAutoMapper;

namespace AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }

        public static OnlyForMapping<TSource, TDestination> Only<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapper)
        {
            return new OnlyForMapping<TSource, TDestination>(mapper);
        }
    }
}