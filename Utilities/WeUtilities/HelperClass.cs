using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace WeUtilities
{


    public sealed record PropertyInformation(PropertyInfo PropertyInfo, Type PropertyType, string Name);
    public class HelperClass<T>
    {

        public static PropertyInformation Property<TProp>(Expression<Func<T, TProp>> expression)
        {
            {
                var body = expression.Body as MemberExpression;

                if (body == null)
                {
                    {
#if DEBUG
                        Debugger.Break();
#endif
                        throw new ArgumentException("'expression' should be a member expression");
                    }
                }

                var propertyInfo = (PropertyInfo)body.Member;

                var propertyType = propertyInfo.PropertyType;
                var propertyName = propertyInfo.Name;

                return new PropertyInformation(propertyInfo, propertyType, propertyName);
            }
        }


    }
}

