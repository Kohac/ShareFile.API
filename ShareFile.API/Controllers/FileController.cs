using Microsoft.AspNetCore.Mvc;

namespace ShareFile.API.Controllers;
[Route("api/files")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
    private string? _filePath;

    public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
    }
    /// <summary>
    /// Get File
    /// </summary>
    /// <param name="id">Id of file to return</param>
    /// <returns>File</returns>
    [HttpGet("{id}")]
    public ActionResult GetFile([FromRoute]int id)
    {
        if(id > 50)
            _filePath = @"C:\temp\rules-of-hooks.pdf";
        else
            _filePath = @"C:\temp\SheetJSTableExport.xlsx";

        if (!System.IO.File.Exists(_filePath))
            return NotFound();
        var bytes = System.IO.File.ReadAllBytes(_filePath);

        if(!_fileExtensionContentTypeProvider.TryGetContentType(_filePath, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return File(bytes, contentType, Path.GetFileName(_filePath));
    }
}