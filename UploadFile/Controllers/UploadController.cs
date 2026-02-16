using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly PicturesContext _picturesContext;

        public UploadController(PicturesContext picturesContext)
        {
            _picturesContext = picturesContext;
        }
    }
}
