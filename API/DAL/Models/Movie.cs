using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Models;

[Table("movies")]
public class Movie
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

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

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
