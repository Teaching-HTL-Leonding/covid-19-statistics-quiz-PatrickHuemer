using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStats.AccessData
{
    public class CovidStatsDataContext : DbContext
    {
        public CovidStatsDataContext(DbContextOptions<CovidStatsDataContext> options)
            : base(options)
        { }

        public DbSet<Bundesland> Bundeslands { get; set; }
        public DbSet<Bezirk> Bezirks { get; set; }
        public DbSet<Cases> Cases { get; set; }
    }
}
