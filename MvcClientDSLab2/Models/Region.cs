using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MvcClientDSLab2.Models
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
    }
}