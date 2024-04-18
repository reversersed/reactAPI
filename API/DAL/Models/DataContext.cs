using System;
using System.Collections.Generic;
using API.DAL.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Models;

public partial class DataContext : IdentityDbContext<User>
{
    protected readonly IConfiguration configuration;

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    #region Constructor
    public DataContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasMany(x => x.Genres)
                .WithMany(x => x.Movies);
        });
        base.OnModelCreating(modelBuilder);
    }
}
