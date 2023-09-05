using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilesApi;

public sealed class EnumSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// </summary>
    /// <param name="schema"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
        {
            return;
        }

        schema.Enum.Clear();
        Enum
            .GetNames(context.Type)
            .ToList()
            .ForEach(name => schema.Enum.Add(new OpenApiString($"{name}")));
        schema.Type = "string";
        schema.Format = string.Empty;
    }
}