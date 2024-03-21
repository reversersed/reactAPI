using API.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.BLL.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public float? Rating { get; set; }
        public int? Year { get; set; }
        public string? Cover { get; set; }
        public string? Url { get; set; }
        public string? Tagline { get; set; }
        public string? Director { get; set; }
        public string? Screenwriter { get; set; }
        public string? Producer { get; set; }
        public string? Videographer { get; set; }
        public string? Composer { get; set; }
        public string? Drawer { get; set; }
        public string? Montage { get; set; }
        public int? Budget { get; set; }
        public int? Collected { get; set; }
        public DateOnly? Premier { get; set; }
        public int? Age { get; set; }
        public ICollection<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
    }
}
