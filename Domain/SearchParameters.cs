namespace FilesApi.Domain;

public class SearchParameters
{
    public SearchDirectory SearchDirectory { get; set; } = new();

    public override string ToString()
    {
        return SearchDirectory.Value;
    }
}