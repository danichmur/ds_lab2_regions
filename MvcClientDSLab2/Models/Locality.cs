using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MvcClientDSLab2.Models
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

    }
}