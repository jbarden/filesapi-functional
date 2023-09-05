namespace FilesApi.ConfigurationFiles;

public class AppSettings
{
    public Serilog Serilog { get; set; }

    public Logging Logging { get; set; }

    public string AllowedHosts { get; set; }

    public string[] SupportedImageTypes { get; set; }
}