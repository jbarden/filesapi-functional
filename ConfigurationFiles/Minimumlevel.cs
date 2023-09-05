namespace FilesApi.ConfigurationFiles;

public class Minimumlevel
{
    public string Default { get; set; } = string.Empty;

    public Override Override { get; set; } = new();
}