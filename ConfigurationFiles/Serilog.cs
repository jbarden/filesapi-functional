namespace FilesApi.ConfigurationFiles;

public class Serilog
{
    public string[] Enrich { get; set; }
    public Writeto[] WriteTo { get; set; }
    public Minimumlevel MinimumLevel { get; set; }
}