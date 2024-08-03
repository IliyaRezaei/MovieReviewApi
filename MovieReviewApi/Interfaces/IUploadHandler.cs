using MovieReviewApi.Models;

namespace MovieReviewApi.Interfaces
{
    public interface IUploadHandler
    {
        public string UploadUserImage(IFormFile file, User user);
        public string UploadPersonImage(IFormFile file, Person person);

        public string UploadMovieTrailer(IFormFile file, Movie movie);
    }
}
