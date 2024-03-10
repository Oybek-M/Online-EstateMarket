
namespace Online_EstateMarket.BLL.Services;


public class FileService(IWebHostEnvironment webHostEnvironment)
    : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;


    public string UploadImage(IFormFile image)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
        var imagePath = Path.Combine(wwwrootFolder + "/Images/", uniqueFileName);

        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            image.CopyTo(fileStream);
        }

        return $"~/Images/{uniqueFileName}";
    }

    public void DeleteImage(string imageUrl)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var imagePath = Path.Combine(wwwrootFolder, imageUrl.Replace("~/", ""));

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }
    }

    public List<string> UploadMultipleImage(List<IFormFile> images)
    {
        List<string> result = new List<string>();
        foreach (var image in images)
        {
            result.Add(UploadImage(image));
        }

        return result;
    }

    public void DeleteMultipleImage(List<string> imageUrls)
    {
        foreach (var imageUrl in imageUrls)
        {
            DeleteImage(imageUrl);
        }
    }
}