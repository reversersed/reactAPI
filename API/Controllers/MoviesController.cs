﻿using API.BLL.DTO;
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
        private IMovieManager movieManager;
        private UserManager<User> userManager;
        public MoviesController(IMovieManager movieManager, UserManager<User> userManager)
        {
            this.movieManager = movieManager;
            this.userManager = userManager;
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
            if(movie == null)
                return NotFound();
            return movie;
        }
        //DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var response = await movieManager.DeleteMovie(id);
            if(!response)
                return NotFound();
            return Ok();
        }
        //POST: api/Movies
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MovieDTO>> PublishMovie(MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await movieManager.CreateMovie(movie);
            return CreatedAtAction("GetMovie", new { id = response.Id }, response);
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
                return Ok(response);
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
    }
}
