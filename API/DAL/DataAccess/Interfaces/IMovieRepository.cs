using API.BLL.DTO;
using API.DAL.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.DAL.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetMovie();
        public Task<Movie?> GetMovie(int id);
        public Task<Movie> CreateMovie(Movie movie);
        public Task<bool> DeleteMovie(int id);
        public Task<Movie?> UpdateMovie(Movie movie);
        public Task<Review> InsertReview(Review review);
        public Task<IEnumerable<Genre>> GetAllGenre();
        public Task<Genre?> AddGenre(Genre genre);
    }
}
