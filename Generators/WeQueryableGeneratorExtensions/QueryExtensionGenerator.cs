﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeQueryableGeneratorExtensions
{
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
    /*[Generator]*/
    public class QueryExtensionGenerator : ISourceGenerator
    {
        GeneratorQueryableData numerics = GeneratorQueryableData.NumericDatas;
        GeneratorQueryableData strings = GeneratorQueryableData.StringDatas;
        public void Execute(GeneratorExecutionContext context)
        {
            // Find the main method
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);
            var syntaxTree = context.Compilation.SyntaxTrees;

            string className = "QueryableExtensions";
            string source = $@"// <auto-generated/>
using System.Linq.Expressions;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
namespace WeUtilities
{{
public enum FilterOperator
{{
    EQ,
    NEQ,
    LT,
    GT,
    LTE,
    GTE,
    START_WITH,
    END_WITH,
    LIKE

}}
    public static class {className}{{
       {Generated()}
       {Main()}
       {Helpers()}
    }}
    
    internal sealed record PropertyInformation(PropertyInfo PropertyInfo, Type PropertyType, string Name);
    internal class HelperClass<T>
    {{
        public static PropertyInformation Property<TProp>(Expression<Func<T, TProp>> expression)
        {{
            var body = expression.Body as MemberExpression;

            if (body == null)
            {{
                throw new ArgumentException(""'expression' should be a member expression"");
            }}

            var propertyInfo = (PropertyInfo)body.Member;

            var propertyType = propertyInfo.PropertyType;
            var propertyName = propertyInfo.Name;

            return new PropertyInformation(propertyInfo, propertyType, propertyName);
        }}


    }}
}}

";

            context.AddSource($"{className}.g.cs", SourceText.From(source, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
/*
#if DEBUG
            if (!Debugger.IsAttached)
                Debugger.Launch();
#endif*/

        }


        private string Generated()
        {
            StringBuilder sb = new StringBuilder();

            Action<StringBuilder, GeneratorQueryableData> fn = (sn, data) =>
            {
                foreach (var type in data.Types)
                {
                    sb.AppendLine($"\tprivate static IQueryable<T> Filter{type.Item1.Name}<T>(\r\n       this IQueryable<T> qList,\r\n       Expression<Func<T, {type.Item2}>> property,\r\n       FilterOperator @operator,\r\n       {type.Item2.ToLower()} filterQuery)");
                    sb.AppendLine("\t\t=> @operator switch");
                    sb.AppendLine("\t\t\t{");
                    foreach (var @operator in data.Operators)
                    {
                        sb.AppendLine($"\t\t\t\tFilterOperator.{@operator.Item1.ToString()} => qList.Where(TranslateFilter(property, c => c {@operator.Item2} filterQuery)),");
                    }
                    sb.AppendLine("\t\t\t\t_ => qList");
                    sb.AppendLine("\t\t\t};");

                }
            };
            fn(sb, numerics);
            fn(sb, strings);
            //String
            //DateTime
            return sb.ToString();
        }

        private string Helpers()
        {
            return "private static Expression<Func<TEntity, bool>> TranslateFilter<TEntity, TProperty>(\r\n        Expression<Func<TEntity, TProperty>> prop,\r\n        Expression<Func<TProperty, bool>> filter)\r\n    {\r\n        var newFilterExpression = new Visitor<TEntity>(prop).Visit(filter);\r\n        return (Expression<Func<TEntity, bool>>)newFilterExpression;\r\n    }\r\n\r\n    private class Visitor<TEntity> : ExpressionVisitor\r\n    {\r\n        private readonly ParameterExpression _parameter;\r\n        private readonly Expression _body;\r\n        public Visitor(LambdaExpression prop)\r\n        {\r\n            _parameter = prop.Parameters[0];\r\n            _body = prop.Body;\r\n        }\r\n\r\n        // return the body of the property expression any time we encounter\r\n        // the parameter expression of the filter expression\r\n        protected override Expression VisitParameter(ParameterExpression node) => _body;\r\n\r\n        public override Expression Visit(Expression node)\r\n        {\r\n            if (node is LambdaExpression lamda)\r\n            {\r\n                // Visit the body of the filter lambda, replacing references to the string \r\n                // parameter with the body of the property expression\r\n                var newBody = this.Visit(lamda.Body);\r\n\r\n                // construct a new lambda expression with the new body and the original parameter\r\n                return Expression.Lambda<Func<TEntity, bool>>(newBody, _parameter);\r\n            }\r\n            return base.Visit(node);\r\n        }\r\n    }\r\n\r\n    private static bool IsNumeric(this Type type)\r\n    => Type.GetTypeCode(type) switch\r\n    {\r\n        TypeCode.Int16 or TypeCode.Int32 or\r\n        TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or\r\n        TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,\r\n        _ => false\r\n    };\r\n\r\n    private static bool IsString(this Type type)\r\n    => Type.GetTypeCode(type) switch\r\n    {\r\n        TypeCode.String => true,\r\n        _ => false\r\n    };\r\n\r\n    private static bool IsDateTime(this Type type)\r\n    => Type.GetTypeCode(type) switch\r\n    {\r\n        TypeCode.DateTime => true,\r\n        _ => false\r\n    };";
        }

        private string Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@" public static IQueryable<T> Filter<T, TPROP>(
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
        {");
            int counter = 0;
            foreach (var type in numerics.Types)
            {
                sb.AppendLine($"\t\t\tif({type.Item1.Name}.TryParse(filter,out {type.Item2} res{++counter}))");
                sb.AppendLine($"\t\t\t\treturn qList.Filter{type.Item1.Name}<T>(property as Expression<Func<T, {type.Item2}>>, @operator, res{counter});");
            }

            sb.AppendLine("\t\t}else if (is_string){");
            foreach (var type in strings.Types)
            {
                sb.AppendLine($"\t\t\treturn qList.Filter{type.Item1.Name}<T>(property as Expression<Func<T, {type.Item2}>>, @operator,filter);");
            }

            sb.AppendLine("}");

            sb.AppendLine("return qList;");

            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class GeneratorQueryableData
    {
        public GeneratorQueryableData(List<(FilterOperator, string)> operators, List<(Type, string)> types)
        {
            this.Operators = operators;
            this.Types = types;
        }


        public List<(FilterOperator, string)> Operators { get; }
        public List<(Type, string)> Types { get; }

        public static GeneratorQueryableData NumericDatas = new GeneratorQueryableData(
            new List<(FilterOperator, string)>() { (FilterOperator.EQ, "=="), (FilterOperator.NEQ, "!="), (FilterOperator.LT, "<"), (FilterOperator.GT, ">"), (FilterOperator.LTE, "<="), (FilterOperator.GTE, ">=") },
            new List<(Type, string)>() { (typeof(Int16), "short"), (typeof(Int32), "int"), (typeof(Int64), "long"), (typeof(UInt16), "ushort"), (typeof(UInt32), "uint"), (typeof(UInt64), "ulong"), (typeof(decimal), "decimal"), (typeof(double), "double"), (typeof(Single), "float") }
            );

        public static GeneratorQueryableData StringDatas = new GeneratorQueryableData(

            new List<(FilterOperator, string)>() { (FilterOperator.EQ, "=="), (FilterOperator.NEQ, "!="), (FilterOperator.START_WITH, "=="), (FilterOperator.END_WITH, "=="), (FilterOperator.LIKE, "==") },
            new List<(Type, string)>() { (typeof(string), "string") }
            );
    }
}
