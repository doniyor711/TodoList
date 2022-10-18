using TodoList.WebApi.Helpers;

namespace TodoList.WebApi.Services
{
    public class FileService
    {
        private readonly string _basePath = String.Empty;
        private const string _imagesFolderName = "images";
        public FileService(IWebHostEnvironment env)
        {
            _basePath = env.WebRootPath;
        }
        
        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string filename = ImageHelper.MakeImageName(image.FileName);
            string partPath = Path.Combine(_imagesFolderName, filename);
            string path = Path.Combine(_basePath, partPath);
            await image.CopyToAsync(new FileStream(path, FileMode.Create));
            return partPath;
        }
    }
}
