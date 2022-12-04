using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WeQueryableGeneratorExtensions
{
    [Generator]
    public class MapQueryToPredicateGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {

            var syntaxTrees = context.Compilation.SyntaxTrees;
            var handlers = syntaxTrees.Where(x => x.GetText().ToString().Contains("[Query]"));
            var source = new StringBuilder();
            List<string> usings = new ();

            foreach (var handler in handlers)
            {
                var usingDirectives = handler.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>();

                var classDeclarationSyntax = handler.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First();
                var classname = classDeclarationSyntax.Identifier.ToString();
                var generatedClassname = $"{classname}QueryMapper";

                var namespaceSyntax = handler.GetRoot().DescendantNodes().OfType<NamespaceDeclarationSyntax>().First();
               // usings.Add(namespaceSyntax);

            }



        }

        public void Initialize(GeneratorInitializationContext context)
        {
/*#if DEBUG
            if (!Debugger.IsAttached)
                Debugger.Launch();
#endif*/
        }
    }
}
