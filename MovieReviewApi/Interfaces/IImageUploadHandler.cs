using MovieReviewApi.Enums;
using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IImageUploadHandler
    {
        public string UploadImage(IFormFile file, string user, ImageUploadType type);
    }
}
