using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Helpers
{
    public class ImageUploadHandler : IImageUploadHandler
    {
        public string UploadImage(IFormFile file, string username)
        {
            List<string> validExtensions = new List<string>
            {
                ".jpg",
                ".png"
            };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return $"Extension is not valid, valid extensions=>({string.Join(",", validExtensions)})";
            }

            long size = file.Length;
            if (size > 5 * 1024 * 1024)
            {
                return "Maximum image size is 5mbs";
            }

            string fileName = username + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "User");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return path;
        }
    }
}
