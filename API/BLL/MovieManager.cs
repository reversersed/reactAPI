using API.BLL.DTO;
using API.BLL.Interfaces;
using API.DAL.DataAccess.Interfaces;
using API.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.BLL
{
    public class MovieManager : IMovieManager
    {
        private IMovieRepository movieRepository { get; }
        private IMapper mapper { get; }
        public MovieManager(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }
        public async Task<MovieDTO> CreateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = await movieRepository.CreateMovie(entity);
            return mapper.Map<MovieDTO>(response);
        }

        public async Task<bool> DeleteMovie(int id)
        {
            return await movieRepository.DeleteMovie(id);
        }

        public async Task<MovieDTO?> GetMovie(int id)
        {
            var response = await movieRepository.GetMovie(id);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }

        public async Task<IEnumerable<MovieDTO>> GetMovies()
        {
            var response = await movieRepository.GetMovie();
            return mapper.Map<IEnumerable<MovieDTO>>(response);
        }

        public async Task<MovieDTO?> UpdateMovie(MovieDTO movie)
        {
            var entity = mapper.Map<Movie>(movie);
            var response = await movieRepository.UpdateMovie(entity);
            if (response == null)
                return null;
            return mapper.Map<MovieDTO>(response);
        }
    }
}
