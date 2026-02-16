namespace UploadFile.Services.IUploadFile
{
    public interface IUpload
    {
        Task<object> UploadFile(IFormFile formFile);
        Task<object> DowloadFile(int id);
    }
}
