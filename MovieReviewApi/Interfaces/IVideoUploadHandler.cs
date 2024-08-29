namespace MovieReviewApi.Interfaces
{
    public interface IVideoUploadHandler
    {
        public string UploadMovie(IFormFile file, String movie);
    }
}
