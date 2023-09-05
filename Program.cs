using FilesApi.ConfigurationFiles;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using Serilog;

namespace FilesApi;

public static class Program
{
    public static AppSettings AppSettings { get; set; } = new();

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => options.SchemaFilter<EnumSchemaFilter>());

    _ = builder.Services.AddOptions<AppSettings>()
            .Bind(builder.Configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        builder.Host
            .UseSerilog((context, loggerConfig) => loggerConfig
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {Message:lj}{NewLine}{Exception}")
            .ReadFrom.Configuration(context.Configuration));

        var app = builder.Build();

        AppSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}