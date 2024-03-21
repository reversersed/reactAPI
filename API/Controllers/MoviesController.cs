using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.DataAccess;
using API.DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieManager movieManager;
        public MoviesController(IMovieManager movieManager)
        {
            this.movieManager = movieManager;
        }
        //GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetMovie()
        {
            return movieManager.GetMovies().ToList();
        }
        //GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<MovieDTO> GetMovie(int id)
        {
            var movie = movieManager.GetMovie(id);
            if(movie == null)
                return NotFound();
            return movie;
        }
        //DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var response = movieManager.DeleteMovie(id);
            if(!response)
                return NotFound();
            return Ok();
        }
        //POST: api/Movies
        [HttpPost]
        public ActionResult<MovieDTO> PublishMovie(MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = movieManager.CreateMovie(movie);
            return CreatedAtAction("GetMovie", new { id = response.Id }, response);
        }
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, MovieDTO movie)
        {
            if(id != movie.Id)
                return BadRequest();
            var response = movieManager.UpdateMovie(movie);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
