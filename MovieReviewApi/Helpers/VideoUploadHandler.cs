using MovieReviewApi.Interfaces;

namespace MovieReviewApi.Helpers
{
    public class VideoUploadHandler : IVideoUploadHandler
    {
        public string UploadMovie(IFormFile file, string movie)
        {
            List<string> validExtensions = new List<string>
            {
                ".mp4",
                ".mkv"
            };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return $"Extension is not valid, valid extensions=>({string.Join(",", validExtensions)})";
            }

            long size = file.Length;
            if (size >= 500 * 1024 * 1024)
            {
                return "Maximum video size is 500mb";
            }

            string fileName = movie + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Movie");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return path;
        }
        
    }
}
