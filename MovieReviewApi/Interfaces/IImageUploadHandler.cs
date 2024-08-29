using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IImageUploadHandler
    {
        public string UploadImage(IFormFile file, String username);

    }
}
