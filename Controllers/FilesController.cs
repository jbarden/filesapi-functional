using FilesApi.DTOs;
using FilesApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly ILogger<FilesController> logger;

    public FilesController(ILogger<FilesController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] SearchParameters searchParameters)
    {
        logger.LogInformation("Starting search...SearchFolder: {SearchFolder}, CurrentPage: {CurrentPage}, ItemsPerPage: {ItemsPerPage}, SearchType: {SearchType}, SearchOption: {SearchOption}, SortOrder: {SortOrder}", searchParameters.SearchDirectory, searchParameters.CurrentPage, searchParameters.ItemsPerPage, searchParameters.SearchType, searchParameters.SearchOption, searchParameters.SortOrder);

        var files = Directory
                                            .GetFiles(searchParameters.SearchDirectory, "*.*", searchParameters.SearchOption)
                                            .ToFileInfo(searchParameters)
                                            .ConvertToDtos();

        return new OkObjectResult(files);
    }
}