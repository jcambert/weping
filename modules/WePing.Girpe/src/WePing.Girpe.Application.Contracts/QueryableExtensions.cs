using System.Linq.Expressions;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace WePing.Girpe;

public enum FilterOperator
{
    EQ,
    NEQ,
    LT,
    GT,
    LTE,
    GTE,
    START_WITH,
    END_WITH,
    LIKE

}


public static class QueryableExtensions
{

    private static IQueryable<T> FilterInt16<T>(
       this IQueryable<T> qList,
       Expression<Func<T, short>> property,
       FilterOperator @operator,
       short filterQuery)
  => @operator switch
  {
      FilterOperator.EQ => qList.Where(TranslateFilter(property, c => c == filterQuery)),
      FilterOperator.NEQ => qList.Where(TranslateFilter(property, c => c != filterQuery)),
      FilterOperator.LT => qList.Where(TranslateFilter(property, c => c < filterQuery)),
      FilterOperator.GT => qList.Where(TranslateFilter(property, c => c > filterQuery)),
      FilterOperator.LTE => qList.Where(TranslateFilter(property, c => c <= filterQuery)),
      FilterOperator.GTE => qList.Where(TranslateFilter(property, c => c >= filterQuery)),
      _ => qList
  };

    private static IQueryable<T> FilterInt32<T>(
        this IQueryable<T> qList,
        Expression<Func<T, int>> property,
        FilterOperator @operator,
        int filterQuery)
   => @operator switch
   {
       FilterOperator.EQ => qList.Where(TranslateFilter(property, c => c == filterQuery)),
       FilterOperator.NEQ => qList.Where(TranslateFilter(property, c => c != filterQuery)),
       FilterOperator.LT => qList.Where(TranslateFilter(property, c => c < filterQuery)),
       FilterOperator.GT => qList.Where(TranslateFilter(property, c => c > filterQuery)),
       FilterOperator.LTE => qList.Where(TranslateFilter(property, c => c <= filterQuery)),
       FilterOperator.GTE => qList.Where(TranslateFilter(property, c => c >= filterQuery)),
       _ => qList
   };

    private static IQueryable<T> FilterUInt16<T>(
       this IQueryable<T> qList,
       Expression<Func<T, ushort>> property,
       FilterOperator @operator,
       short filterQuery)
  => @operator switch
  {
      FilterOperator.EQ => qList.Where(TranslateFilter(property, c => c == filterQuery)),
      FilterOperator.NEQ => qList.Where(TranslateFilter(property, c => c != filterQuery)),
      FilterOperator.LT => qList.Where(TranslateFilter(property, c => c < filterQuery)),
      FilterOperator.GT => qList.Where(TranslateFilter(property, c => c > filterQuery)),
      FilterOperator.LTE => qList.Where(TranslateFilter(property, c => c <= filterQuery)),
      FilterOperator.GTE => qList.Where(TranslateFilter(property, c => c >= filterQuery)),
      _ => qList
  };

    public static IQueryable<T> Filter<T, TPROP>(
       this IQueryable<T> qList,
       Expression<Func<T, TPROP>> property,
       FilterOperator @operator,
       TPROP filterQuery)
    {
       

        var propertyInfo = HelperClass<T>.Property(property);
        var is_numeric = propertyInfo.PropertyType.IsNumeric();
        var is_string = propertyInfo.PropertyType.IsString();


        if (filterQuery == null)
            return qList;


        var filter = filterQuery.ToString();

        if (is_numeric)
        {
            if (Int16.TryParse(filter, out short res0))
                return qList.FilterInt16<T>(property as Expression<Func<T, short>>, @operator, res0);
            if (Int32.TryParse(filter, out int res1))
                return qList.FilterInt32<T>(property as Expression<Func<T, int>>, @operator, res1);
            if (UInt16.TryParse(filter, out ushort res2))
                return qList.FilterUInt16<T>(property as Expression<Func<T, ushort>>, @operator, res0);
        }else if (is_string)
        {
            
            //return qList.FilterString<T>(property as Expression<Func<T, ushort>>, @operator, filter);
        }


        return qList;
    }
    public static IQueryable<T> Filter<T>(
        this IQueryable<T> qList,
        Expression<Func<T, string>> property,
        string filterQuery)
    {

        return qList;
    }

    private static Expression<Func<TEntity, bool>> TranslateFilter<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> prop,
        Expression<Func<TProperty, bool>> filter)
    {
        var newFilterExpression = new Visitor<TEntity>(prop).Visit(filter);
        return (Expression<Func<TEntity, bool>>)newFilterExpression;
    }

    private class Visitor<TEntity> : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        private readonly Expression _body;
        public Visitor(LambdaExpression prop)
        {
            _parameter = prop.Parameters[0];
            _body = prop.Body;
        }

        // return the body of the property expression any time we encounter
        // the parameter expression of the filter expression
        protected override Expression VisitParameter(ParameterExpression node) => _body;

        public override Expression Visit(Expression node)
        {
            if (node is LambdaExpression lamda)
            {
                // Visit the body of the filter lambda, replacing references to the string 
                // parameter with the body of the property expression
                var newBody = this.Visit(lamda.Body);

                // construct a new lambda expression with the new body and the original parameter
                return Expression.Lambda<Func<TEntity, bool>>(newBody, _parameter);
            }
            return base.Visit(node);
        }
    }

    private static bool IsNumeric(this Type type)
    => Type.GetTypeCode(type) switch
    {
        TypeCode.Int16 or TypeCode.Int32 or
        TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or
        TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
        _ => false
    };

    private static bool IsString(this Type type)
    => Type.GetTypeCode(type) switch
    {
        TypeCode.String => true,
        _ => false
    };

    private static bool IsDateTime(this Type type)
    => Type.GetTypeCode(type) switch
    {
        TypeCode.DateTime => true,
        _ => false
    };
}

public sealed record PropertyInformation(PropertyInfo PropertyInfo, Type PropertyType, string Name);
internal class HelperClass<T>
{
    public static PropertyInformation Property<TProp>(Expression<Func<T, TProp>> expression)
    {
        var body = expression.Body as MemberExpression;

        if (body == null)
        {
            throw new ArgumentException("'expression' should be a member expression");
        }

        var propertyInfo = (PropertyInfo)body.Member;

        var propertyType = propertyInfo.PropertyType;
        var propertyName = propertyInfo.Name;

        return new PropertyInformation(propertyInfo, propertyType, propertyName);
    }


}