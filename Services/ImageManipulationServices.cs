namespace PestFree.Services
{
  public interface IFileService
  {
    Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions);
    void DeleteFile(string fileNameWithExtensions);
  }
  public class ImageManipulationServices(IWebHostEnvironment environment) :IFileService
  {
    public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions)
    {
      if (imageFile == null) {
        throw new ArgumentNullException(nameof(imageFile));
      }

      var contentPath = environment.ContentRootPath;
      var path = Path.Combine(contentPath, "Images/Company");

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      var ext = Path.GetExtension(imageFile.FileName);
      if (!allowedFileExtensions.Contains(ext))
      {
        throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed");
      }

      var fileName = $"{Guid.NewGuid().ToString()}{ext}";
      var fileNameWithPath = Path.Combine(path, fileName);
      using var stream = new FileStream(fileNameWithPath, FileMode.Create);
      await imageFile.CopyToAsync(stream);
      return fileName;

    }
    public void DeleteFile(string fileNameWithExtensions)
    {
      if (string.IsNullOrEmpty(fileNameWithExtensions))
      {
        throw new ArgumentNullException(nameof(fileNameWithExtensions));
      }
      var contentPath = environment.ContentRootPath;
      var path = Path.Combine(contentPath, $"Images/Company", fileNameWithExtensions);

      if (!File.Exists(path))
      {
        throw new FileNotFoundException($"Invalid file path");
      }
      File.Delete(path);

    }


  }
}
