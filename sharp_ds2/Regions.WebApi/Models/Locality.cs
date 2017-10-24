using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Regions.WebApi.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Locality
    {        
        [JsonProperty]
        public int Id {get; set;}
         [JsonProperty]
        public int AreaId { get; set; }
        
         [JsonProperty]
        public string Name { get; set; }

         [JsonProperty]
        public string Type { get; set; }

         [JsonProperty]
        public int Population { get; set; }

        public virtual Area Area { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Locality>();

            e.ToTable("localities");

            e.HasKey(x => x.Id);

            e.Property(x => x.Id)
                .HasColumnName("locality_id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);
            
            e.Property(x => x.AreaId)
                .HasColumnName("area_id")
                .IsRequired(true);

            e.Property(x => x.Name)
                .HasColumnName("locality_name")
                .HasMaxLength(30);

            e.Property(x => x.Type)
                .HasColumnName("locality_type")
                .HasMaxLength(30);

            e.Property(x => x.Population)
                .HasColumnName("locality_population")
                .IsRequired(true);

             e.HasOne(x => x.Area)
                .WithMany(x => x.Localities)
                .HasForeignKey(x => x.AreaId);

        }
    }
}