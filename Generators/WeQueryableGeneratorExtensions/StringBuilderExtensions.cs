using System;
using System.Text;

internal static class StringBuilderExtensions
{
    public static StringBuilder AppendLine(this StringBuilder builder, int count)
    {
        for (int i = 0; i < count; i++)
        {
            builder.AppendLine();
        }
        return builder;
    }
    public static StringBuilder AppendLine(this StringBuilder builder, int tab, string text)
    => builder.AddIndent(tab).AppendLine(text);

    public static StringBuilder AddIndent(this StringBuilder builder, int indent)
        => indent <= 0 ? builder : builder.Append(new string('\t', indent));
    public static StringBuilder OpenBrace(this StringBuilder builder, int indent)
    => builder.AppendLine(indent, "{");
    public static StringBuilder CloseBrace(this StringBuilder builder, int indent)
    => builder.AppendLine(indent, "}");
    public static StringBuilder Comment(this StringBuilder builder, int indent, string comment = "")
    {
        if (string.IsNullOrEmpty(comment))
            builder.AppendLine(indent, "/// <summary>");
        else
            builder.AppendLine(indent, $"/// {comment}");
        return builder;
    }
    public static StringBuilder Comment(this StringBuilder builder, string comment = "") => builder.Comment(0, comment);


    public static string FormatPredicate(this (string, string) item, string queryName)
    {

        if (string.Equals(item.Item1, "string", StringComparison.CurrentCultureIgnoreCase))
            return $"(string.IsNullOrEmpty( {queryName}.{item.Item2})?true:{queryName}.{item.Item2}==x.{item.Item2})";
        if(string.Equals(item.Item1, "guid", StringComparison.CurrentCultureIgnoreCase))
            return $"(Guid.Empty== {queryName}.{item.Item2}?true:{queryName}.{item.Item2}==x.{item.Item2})";
        return string.Empty;
    }
}
