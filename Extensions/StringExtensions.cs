using FilesApi.DTOs;

namespace FilesApi.Extensions;

internal static class StringExtensions
{
    public static IEnumerable<FileInfo> ToFileInfo(this IEnumerable<string> files, SearchParameters searchParameters) =>
        files
            .FilterBySearchType(searchParameters.SearchType)
            .OrderByName(searchParameters.SortOrder)
            .ConvertToFileInfo()
            .RemoveEmptyFiles()
            .OrderBySize(searchParameters.SortOrder)
            .SelectDuplicates(searchParameters.SearchType)
            .PaginateFileInfo(searchParameters);

    private static IEnumerable<string> FilterBySearchType(this IEnumerable<string> files, SearchType searchType) =>
        searchType switch
        {
            SearchType.Images => files.Where(file => file.IsImage()),
            _ => files
        };

    private static IEnumerable<string> OrderByName(this IEnumerable<string> files, SortOrder sortOrder) =>
        sortOrder switch
        {
            SortOrder.NameAscending => files.OrderBy(f => f),
            SortOrder.NameDescending => files.OrderByDescending(f => f),
            _ => files
        };

    private static IEnumerable<FileInfo> ConvertToFileInfo(this IEnumerable<string> files) =>
        files.Select(file => new FileInfo(file));

    private static bool IsImage(this string fileInfo) =>
        Array.Exists(Program.AppSettings.SupportedImageTypes, extension => fileInfo.EndsWith(extension, StringComparison.OrdinalIgnoreCase));
}