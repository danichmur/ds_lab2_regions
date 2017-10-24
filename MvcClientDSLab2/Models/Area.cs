using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MvcClientDSLab2.Models
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
        [JsonProperty]       
        public HashSet<Locality> Localities { get; set; }
            = new HashSet<Locality>();
    }
}