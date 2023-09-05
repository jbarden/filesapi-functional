using FilesApi.DTOs;

namespace FilesApi.Extensions;

internal static class FileInfoExtensions
{
    internal static IEnumerable<AStarFileInfo> ConvertToDtos(this IEnumerable<FileInfo> files)
        => files.Select(AStarFileInfo.FromFileInfo).ToList();

    internal static IEnumerable<FileInfo> PaginateFileInfo(this IEnumerable<FileInfo> files,
        SearchParameters searchParameters) => files
        .Skip(SkipItemsCalculator(searchParameters.ItemsPerPage, searchParameters.CurrentPage))
        .Take(searchParameters.ItemsPerPage);

    internal static IEnumerable<FileInfo> SelectDuplicates(this IEnumerable<FileInfo> files, SearchType searchType) =>
        searchType switch
        {
            SearchType.Duplicates => files.GetDuplicates().SelectMany(f => f),
            _ => files
        };

    internal static IEnumerable<FileInfo> RemoveEmptyFiles(this IEnumerable<FileInfo> files) =>
        files.Where(file => file.Length > 0);

    internal static IEnumerable<FileInfo> OrderBySize(this IEnumerable<FileInfo> files, SortOrder sortOrder) =>
        sortOrder switch
        {
            SortOrder.SizeAscending => files.OrderBy(f => f.Length),
            SortOrder.SizeDescending => files.OrderByDescending(f => f.Length),
            _ => files
        };

    private static int SkipItemsCalculator(int itemsPerPage, int currentPage) => itemsPerPage * (currentPage - 1);

    private static IEnumerable<IGrouping<long, FileInfo>> GetDuplicates(this IEnumerable<FileInfo> files) =>
        files.GroupBy(file => file.Length)
            .Where(fileGroups => fileGroups.Count() > 1);
}