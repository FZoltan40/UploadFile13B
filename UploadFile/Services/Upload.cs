using UploadFile.Services.IUploadFile;

namespace UploadFile.Services
{
    public class Upload : IUpload
    {
        public async Task<object> UploadFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
