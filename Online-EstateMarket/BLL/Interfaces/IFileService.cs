
namespace Online_EstateMarket.BLL.Interfaces;

public interface IFileService
{
    string UploadImage(IFormFile image);

    void DeleteImage(string imageUrl);

    List<string> UploadMultipleImage(List<IFormFile> images);

    void DeleteMultipleImage(List<string> imageUrls);
}
