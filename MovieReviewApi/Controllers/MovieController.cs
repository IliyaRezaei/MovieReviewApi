using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Dto;
using MovieReviewApi.Interfaces;
using MovieReviewApi.Mappers;

namespace MovieReviewApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IVideoUploadHandler _videoUploadHandler;


        public MovieController(IMovieRepository movieRepository, 
            IGenreRepository genreRepository, 
            IPersonRepository personRepository,
            IVideoUploadHandler videoUploadHandler)
        {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
            _personRepository = personRepository;
            _videoUploadHandler = videoUploadHandler;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll()
        {
            return Ok(_movieRepository.GetAll().ToDto());
        }

        
        [HttpGet("byId/{id}")]
        public ActionResult<MovieDto> GetById([FromRoute] int id)
        {
            if (!_movieRepository.MovieExistById(id))
            {
                return NotFound("Invalid Index");
            }
            return _movieRepository.GetMovieById(id).ToDto();
        }

        [HttpGet("byName/{name}")]
        public ActionResult<MovieDto> GetByName([FromRoute] string name)
        {
            if (!_movieRepository.MovieExistByName(name))
            {
                return NotFound("Invalid Name");
            }
            return _movieRepository.GetMovieByName(name).ToDto();
        }

        [HttpPost]
        public IActionResult Create(MovieDto dto)
        {
            if (!ModelState.IsValid || dto.Id != 0)
            {
                return BadRequest("Model is not valid");
            }
            if (!_movieRepository.Create(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            // url of the created object
            return Created("", "Successfully Created");
        }

        [HttpPost("genre/")]
        public IActionResult AddMovieGenre([FromQuery]int movieId, [FromQuery] int genreId)
        {
            if (!_genreRepository.GenreExistById(genreId)) 
            {
                return NotFound("Invalid Index");
            }
            if(!_movieRepository.AddMovieGenre(movieId, genreId))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "genre successfully added to the movie");
        }

        [HttpPost("AddMovieActor/")]
        public IActionResult AddMovieActor([FromQuery] int movieId, [FromQuery] int actorId)
        {
            if (!_personRepository.PersonExistById(actorId))
            {
                return NotFound("Invalid Index");
            }
            if (!_movieRepository.AddMovieActor(movieId, actorId))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("", "actor successfully added to the movie");
        }

        [HttpPost("AddMovieDirector/")]
        public IActionResult AddMovieDirector([FromQuery] int movieId, [FromQuery] int directorId)
        {
            if (!_personRepository.PersonExistById(directorId))
            {
                return NotFound("Invalid Index");
            }
            if (!_movieRepository.AddMovieDirector(movieId, directorId))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return Created("","director successfully added to the movie");
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            if (_movieRepository.MovieExistById(id))
            {
                NotFound("Invalid Index");
            }
            dto.Id = id;
            if (!_movieRepository.Update(dto.ToModel()))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound("Invalid Index");
            }
            if (!_movieRepository.Delete(movie))
            {
                return BadRequest("Something went wrong while saving the changes");
            }
            return NoContent();
        }


        [HttpPost("UploadTrailer")]
        [RequestSizeLimit(500 * 1024 * 1024)]
        public IActionResult UploadMovieTrailer(IFormFile file, int movieId)
        {
            if (!_movieRepository.MovieExistById(movieId))
            {
                return NotFound("Invalid Index");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            var movie = _movieRepository.GetMovieById(movieId);
            movie.MovieTrailerUrl = _videoUploadHandler.UploadMovie(file, movie.Title);
            if (!_movieRepository.Save())
            {
                return BadRequest("Something went wrong");
            }
            return Ok(movie.MovieTrailerUrl);
        }
    }
}
