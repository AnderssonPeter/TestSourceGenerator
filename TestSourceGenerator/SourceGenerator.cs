using System;
using System.Text;
using System.Xml.Linq;
using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace TestSourceGenerator;

[Generator]
public class SourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {

        var builder = new StringBuilder(1024);

        builder.AppendLine(@$"using System;
namespace {context.Compilation.Assembly.ContainingNamespace?.Name ?? context.Compilation.Assembly.Name};
static class AssemblyInformation {{
    public static string Name = ""{context.Compilation.AssemblyName}"";
    public static string HumanizedName = ""{context.Compilation.AssemblyName.Humanize()}"";
}}
");

        context.AddSource("test", SourceText.From(builder.ToString(), Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context)
    {

    }
}
