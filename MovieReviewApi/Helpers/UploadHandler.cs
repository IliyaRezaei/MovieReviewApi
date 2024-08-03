using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Models;

namespace MovieReviewApi.Helpers
{
    public class UploadHandler : IUploadHandler
    {
        public string UploadPersonImage(IFormFile file, Person person)
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

            string fileName = person.Fullname + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Person");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            person.ImageUrl = path;
            return $"Person Image successfully saved {fileName}";
        }

        public string UploadUserImage(IFormFile file, User user)
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
            if (size > 5* 1024 * 1024)
            {
                return "Maximum image size is 5mbs";
            }

            string fileName = user.Username + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Uploads","User");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            user.ImageUrl = path;
            return $"User Image successfully saved {fileName}";
        }


        public string UploadMovieTrailer(IFormFile file, Movie movie)
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
            if (size >= 500 * 1024*1024)
            {
                return "Maximum video size is 500mb";
            }

            string fileName = movie.Title + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Movie");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            movie.MovieTrailerUrl = path;
            return $"Movie Trailer successfully saved {fileName}";
        }
        
    }
}
