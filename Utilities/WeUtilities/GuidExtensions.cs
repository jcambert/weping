using System;

namespace WeUtilities;

public static class GuidExtensions
{
    public static bool IsNotSet(this Guid guid) => Guid.Empty == guid;
    public static bool IsSet(this Guid guid)=> !guid.IsNotSet();
}
