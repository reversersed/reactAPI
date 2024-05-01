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
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<Subscribtion> Subscribtions { get; set; }
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
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(x => x.Subscriptions).WithOne(i => i.User);
            entity.HasMany(x => x.Replenishments).WithOne(i => i.User);
        });
        base.OnModelCreating(modelBuilder);
    }
}
