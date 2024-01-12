using Assignment6.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private List<Movie> movies = new List<Movie>()
        {
           new Movie { Id = 1, Title = "Guntur Karam", Genre = "Action", ReleaseDate = new DateTime(2024, 1, 12) },
           new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseDate = new DateTime(2008, 7, 18) },
           new Movie { Id = 3, Title = "Money Heist", Genre = "Thriller", ReleaseDate = new DateTime(2021, 8, 9) },
        };
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movies;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = movies.Find(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
    

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult<Movie> CreateMovie(Movie newMovie)
        {
            newMovie.Id = movies.Count + 1;
            movies.Add(newMovie);

            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            var existingMovie = movies.Find(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.ReleaseDate = updatedMovie.ReleaseDate;

            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieToRemove = movies.Find(m => m.Id == id);

            if (movieToRemove == null)
            {
                return NotFound();
            }

            movies.Remove(movieToRemove);

            return NoContent();
        }
    }
}

