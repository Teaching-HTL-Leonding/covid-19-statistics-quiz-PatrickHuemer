using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidStats.AccessData
{
    public class Bundesland
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Bezirk> Bezirke { get; set; }

        public Cases Cases { get; set; }
    }

    public class Bezirk
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public Bundesland Bundesland { get; set; }

        [JsonIgnore]
        public List<Cases> Cases { get; set; }
    }

    public class Cases
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public Bezirk Bezirk { get; set; }

        public int Population { get; set; }

        public int Infections { get; set; }
        public int Deaths { get; set; }
        public int WeeklyIncidents { get; set; }
    }


    
}
