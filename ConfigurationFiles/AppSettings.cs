namespace FilesApi.ConfigurationFiles;

public class AppSettings
{
    public Serilog Serilog { get; set; } = new();

    public Logging Logging { get; set; } = new();

    public string AllowedHosts { get; set; } = string.Empty;

    public string[] SupportedImageTypes { get; set; } = Array.Empty<string>();
}