using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Regions.WebApi.Models;

namespace Regions.WebApi.Infrastructure
{
    public class RegionsContext : DbContext 
    {
        public RegionsContext()
        {  }

        public RegionsContext(DbContextOptions<RegionsContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;userid=root;pwd=12Danich;port=3306;database=regions_webapi;sslmode=none;CHARSET=utf8;");
        }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Locality> Localities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            Region.OnModelCreating(modelBuilder);
            Area.OnModelCreating(modelBuilder);
            Locality.OnModelCreating(modelBuilder);
        }
    }

}