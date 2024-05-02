using API.BLL.DTO;
using API.DAL.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Xml.Linq;

namespace API.BLL.Interfaces
{
    public interface IMovieManager
    {
        public Task<IEnumerable<MovieDTO>> GetMovies();
        public Task<MovieDTO?> GetMovie(int id);
        public Task<MovieDTO> CreateMovie(MovieDTO movie);
        public Task<bool> DeleteMovie(int id);
        public Task<MovieDTO?> UpdateMovie(MovieDTO movie);
        public Task<ReviewDTO> InsertReview(int movie, User user, ReviewDTO review);
        public Task<IEnumerable<GenreDTO>> GetGenres();
        public Task<GenreDTO?> AddGenre(GenreDTO genre);
        public Task<IEnumerable<MovieDTO>> GetByGenre(int genreid);
        public Task<IEnumerable<MovieDTO>> GetMoviesByFilter(string? name, int[]? genre);
        public Task<float?> RemoveReview(int id);
    }
}
