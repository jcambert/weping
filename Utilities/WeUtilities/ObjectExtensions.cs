namespace WeUtilities;

public static class ObjectExtensions
{
    public static bool IsNull<T>(this T o)
        where T : class
        => o == null;
    public static bool IsNotNull<T>(this T o)
        where T : class
        => !o.IsNull();

    public static void ThrowIf<T, TException>(this T o, Func<T, bool> predicate, Func<T,TException> ex)
        where T : class
        where TException : Exception
    {
        if (predicate(o))
            throw ex(o );
    }
    public static void ThrowIfNull<T, TException>(this T o, Func<T,TException> ex)
        where T : class
        where TException : Exception
    => o.ThrowIf(x => x.IsNull(), ex);

}
