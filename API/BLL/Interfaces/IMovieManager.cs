using API.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.BLL.Interfaces
{
    public interface IMovieManager
    {
        public Task<IEnumerable<MovieDTO>> GetMovies();
        public Task<MovieDTO?> GetMovie(int id);
        public Task<MovieDTO> CreateMovie(MovieDTO movie);
        public Task<bool> DeleteMovie(int id);
        public Task<MovieDTO?> UpdateMovie(MovieDTO movie);
    }
}
