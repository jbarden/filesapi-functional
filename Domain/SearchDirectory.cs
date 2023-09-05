namespace FilesApi.Domain;

public record SearchDirectory
{
    public string Value { get; set; } = string.Empty;

    public static implicit operator SearchDirectory(string value) => new() { Value = value };

    public static implicit operator string(SearchDirectory value) => value.Value;
}