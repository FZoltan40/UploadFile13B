using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFile.Models;
using UploadFile.Services.IUploadFile;

namespace UploadFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private readonly IUpload upload;

        public UploadController(IUpload upload)
        {
            this.upload = upload;
        }

        [HttpPost]
        public async Task<ActionResult<object>> UploadFile(IFormFile formFile)
        {
            var up = await upload.UploadFile(formFile);

            if (up != null)
            {
                return Ok(up);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> DownloadFile(int id)
        {
            var file = await upload.DowloadFile(id) as Image;

            if (file != null)
            {
                return File(file.ImageData, file.ContentType, file.FileName);
            }

            return BadRequest();
        }
    }
}
