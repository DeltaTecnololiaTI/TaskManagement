using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class TaskFilesController : ControllerBase
{
    private readonly S3Service _s3Service;

    public TaskFilesController(S3Service s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost("{taskId}/upload")]
    public async Task<IActionResult> UploadFile(int taskId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Arquivo inválido.");

        using (var stream = file.OpenReadStream())
        {
            var fileName = $"{taskId}/{file.FileName}";
            var fileUrl = await _s3Service.UploadFileAsync(stream, fileName);

            // Aqui você pode associar o fileUrl à tarefa no banco de dados
            return Ok(new { FileUrl = fileUrl });
        }
    }
}

