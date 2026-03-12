using RiverCitySyndicate.API.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace RiverCitySyndicate.API.Data.DbContexts;

public class RiverCitySyndicateDbContext : DbContext
{
    public RiverCitySyndicateDbContext(DbContextOptions<RiverCitySyndicateDbContext> options) : base(options)
    {
    }

    public DbSet<Show> Shows { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Video> Videos { get; set; }
}
