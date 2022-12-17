using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public static class SyntaxExtensions
{

    public static string GetNamespaceFrom(this SyntaxNode s) =>
        s.Parent switch
        {
            NamespaceDeclarationSyntax namespaceDeclarationSyntax => namespaceDeclarationSyntax.Name.ToString(),
            FileScopedNamespaceDeclarationSyntax fnamespaceDeclarationSyntax => fnamespaceDeclarationSyntax.Name.ToString(),
            null => string.Empty, // or whatever you want to do
            _ => s.Parent.GetNamespaceFrom()
        };
}