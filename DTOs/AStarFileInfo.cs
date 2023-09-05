namespace FilesApi.DTOs;

public class AStarFileInfo
{
    public string Name { get; set; } = string.Empty;

    public string Directory { get; set; } = string.Empty;

    public long Size { get; set; }

    public static AStarFileInfo FromFileInfo(FileInfo file) => new()
    { Name = file.Name, Directory = file.DirectoryName!, Size = file.Length };
}