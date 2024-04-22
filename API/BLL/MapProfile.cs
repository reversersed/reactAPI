using API.BLL.DTO;
using API.DAL.Models.Data;
using AutoMapper;

namespace API.BLL
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap()
                .ForMember(dst => dst.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dst => dst.Reviews, opt => opt.MapFrom(src => src.Reviews));
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            //CreateMap<MovieDTO, Movie>();
        }
    }
}
