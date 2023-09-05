namespace FilesApi.DTOs;

public class SearchParameters
{
    public string SearchDirectory { get; set; } = @"c:\temp";

    public SearchType SearchType { get; set; }

    public SortOrder SortOrder { get; set; }

    public int ItemsPerPage { get; set; } = 50;

    public int CurrentPage { get; set; } = 1;

    public SearchOption SearchOption { get; set; }
}