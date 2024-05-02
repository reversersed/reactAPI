using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieManager movieManager;
        private readonly UserManager<User> userManager;
        private readonly IAccountManager accountManager;
        public MoviesController(IMovieManager movieManager, UserManager<User> userManager, IAccountManager accountManager)
        {
            this.movieManager = movieManager;
            this.userManager = userManager;
            this.accountManager = accountManager;
        }
        [HttpGet, Route("filtered")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovieFilter(string? name, string? genres)
        {
            List<int> genre = new();
            genres?.Split(",").ToList().ForEach(i => genre.Add(Int32.Parse(i)));

            return Ok(await movieManager.GetMoviesByFilter(name, genre.Count > 0 ? genre.ToArray() : null));
        }
        [HttpGet, Route("genre")]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetGenres()
        {
            return Ok(await movieManager.GetGenres());
        }
        [HttpPost, Route("genre")]
        public async Task<ActionResult<GenreDTO>> AddGenre([FromBody] string name)
        {
            if (name is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await movieManager.AddGenre(new GenreDTO { Name = name });
            if (response is null)
                return BadRequest(ModelState);
            return Ok(response);
        }
        //GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovie()
        {
            return Ok(await movieManager.GetMovies());
        }
        //GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await movieManager.GetMovie(id);
            if (movie == null)
                return NotFound();
            return Ok(new{ movie= movie, subscribed= await accountManager.isSubscribed(movie, HttpContext.User.Identity.Name)});
        }
        //DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var response = await movieManager.DeleteMovie(id);
            if (!response)
                return NotFound();
            return Ok();
        }
        //POST: api/Movies
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MovieDTO>> PublishMovie([FromBody] MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await movieManager.CreateMovie(movie);
            return CreatedAtAction("GetMovie", new { id = response.Id }, response);
        }
        [HttpGet, Route("bygenre/{id}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetByGenre(int id)
        {
            return Ok(await movieManager.GetByGenre(id));
        }
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MovieDTO?>> PutMovie(int id, MovieDTO movie)
        {
            if(id != movie.Id)
                return BadRequest();
            var response = await movieManager.UpdateMovie(movie);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost, Route("{id}/review")]
        [Authorize]
        public async Task<IActionResult> InsertReview(int id, [FromBody] ReviewDTO review)
        {
            if(review is null)
                return BadRequest(ModelState);
            var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                var response = await movieManager.InsertReview(id, user, review);
                var movie = await movieManager.GetMovie(id);
                return Ok(new {review = response, rating = movie.Rating});
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("review/{id}")]
        [Authorize]
        public async Task<ActionResult<float>> DeleteReview(int id)
        {
            return Ok(await movieManager.RemoveReview(id));
        }
    }
}
