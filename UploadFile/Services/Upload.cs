using UploadFile.Models;
using UploadFile.Services.IUploadFile;

namespace UploadFile.Services
{
    public class Upload : IUpload
    {
		private readonly PicturesContext _picturesContext;

        public Upload(PicturesContext picturesContext)
        {
            _picturesContext = picturesContext;
        }

        public async Task<object> DowloadFile(int id)
        {
            try
            {
                var file = await _picturesContext.Images.FindAsync(id);

                if (file != null) 
                {

                    return file;
                    //File(file.ImageData, file.ContentType, file.FileName);
                }

                return new { result = "" };
            }
            catch (Exception ex)
            {
                return new { result = ex.Message };
            }
        }

        public async Task<object> UploadFile(IFormFile formFile)
        {
			try
			{
				if(formFile != null || formFile.Length != 0)
				{
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        var image = new Image
                        {
                            ImageData = memoryStream.ToArray(),
                            FileName = formFile.FileName,
                            ContentType = formFile.ContentType

                        };

                        await _picturesContext.Images.AddAsync(image);
                        await _picturesContext.SaveChangesAsync();

                        return new { message = "Sikeres feltöltés." };
                    }
                }

                return new { message = "Sikertelen feltöltés." };

            }
			catch (Exception ex)
			{
                return new { message = ex.Message };
            }
        }
    }
}
