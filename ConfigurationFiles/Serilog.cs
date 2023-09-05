namespace FilesApi.ConfigurationFiles;

public class Serilog
{
    public string[] Enrich { get; set; } = Array.Empty<string>();

    public Writeto[] WriteTo { get; set; } = Array.Empty<Writeto>();

    public Minimumlevel MinimumLevel { get; set; } = new();
}