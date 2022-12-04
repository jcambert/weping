using System;
using System.Linq;
using System.Linq.Expressions;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;

namespace WePing.Girpe.Girpe;

public static class IQueryableExtensions
{

    public static IQueryable<Club> Filter(this IQueryable<Club> queryable, IBrowseClubQuery query)
    {
        var pred = query.GetPredicate();
        return queryable.Where(pred);
        /*
        var props=typeof(IBrowseClubQuery).GetProperties( );
        foreach (var prop in props.Where(p=>p.Name=="Number"))
        {
            var value=prop.GetValue(query);
            queryable=queryable.Filter<Club, int>(x => x.Number, FilterOperator.EQ, int.Parse( value.ToString()));
        }

        return queryable;*/
    }

    public static Expression<Func<Club, bool>> GetPredicate(this IBrowseClubQuery query)
    {
        return x => x.Number == query.Number 
        && (string.IsNullOrEmpty( query.Dep)?true:x.Departement==query.Dep)
        ;
    }
}
