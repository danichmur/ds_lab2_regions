using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Regions.WebApi.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Area
    {        
        [JsonProperty]
        public int Id {get; set;}

        [JsonProperty]
        public int RegionId {get; set;}
        
        [JsonProperty]
        public string Name { get; set; }
        public virtual Region Region { get; set; }
       
        [JsonProperty]
        public HashSet<Locality> Localities { get; set; }
            = new HashSet<Locality>();
            
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Area>();

            e.ToTable("areas");

            e.HasKey(x => x.Id);

            e.Property(x => x.Id)
                .HasColumnName("area_id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);
            
            e.Property(x => x.RegionId)
                .HasColumnName("region_id")
                .IsRequired(true);

            e.Property(x => x.Name)
                .HasColumnName("area_name")
                .HasMaxLength(30);

             e.HasOne(x => x.Region)
                .WithMany(x => x.Areas)
                .HasForeignKey(x => x.RegionId);

            e.HasMany(x => x.Localities)
                .WithOne(x => x.Area)
                .HasForeignKey(x => x.AreaId);
        }
    }
}