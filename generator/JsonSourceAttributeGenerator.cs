using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Js2c.Generator;

/// <summary>
/// Generates the attribute that we used to decorate classes for the JSON model.
/// </summary>
[Generator]
public sealed class JsonSourceAttributeGenerator : IIncrementalGenerator {
  public void Initialize(IncrementalGeneratorInitializationContext context) =>
    context.RegisterPostInitializationOutput(
      context =>
        context.AddSource(
          $"{JsonSourceAttributeSource.Name}.g.cs",
          SourceText.From(JsonSourceAttributeSource.SourceCode, Encoding.UTF8)
        )
    );
}

/// <summary>
/// Source generator for the JSON attribute.  The attribute will take a parameter
/// which will be the JSON snippet we parse to generate the class.  Note that we
/// don't actually read the value from an instance and instead, we just read the
/// value from the arguments
/// </summary>
internal static class JsonSourceAttributeSource {
  public const string Namespace = "generator";
  public const string Name = "JsonSourceAttribute";
  public const string FullyQualifiedName = $"{Namespace}.{Name}";

  public const string SourceCode = """
using System;
using System.Reflection;

namespace Js2c.Generator;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class JsonSourceAttribute : Attribute {
  public JsonSourceAttribute(string json) {

  }
}
""";
}