using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Regions.WebApi.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Region
    {        
        [JsonProperty]
        public int Id {get; set;}

        [JsonProperty]
        public string Name { get; set; }
        
        [JsonProperty]
        public string Capital { get; set; }
        
        [JsonProperty]
        public HashSet<Area> Areas { get; set; }
            = new HashSet<Area>();

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Region>();
            
            e.ToTable("regions");
            
            e.HasKey(x => x.Id);
            
            e.Property(x => x.Id)
                .HasColumnName("region_id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);
            
            e.Property(x => x.Name)
                .HasColumnName("region_name")
                .HasMaxLength(30)
                .IsRequired(true);
            
            e.Property(x => x.Capital)
                .HasColumnName("region_capital")
                .HasMaxLength(30)
                .IsRequired(true);

            e.HasMany(x => x.Areas)
                .WithOne(x => x.Region)
                .HasForeignKey(x => x.RegionId);
        }
    }
}