using CovidStats.AccessData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStats.Controllers
{
    [ApiController]
    [Route("api")]
    public class CovidStatsController
    {
        private readonly CovidStatsDataContext context;

        public CovidStatsController(CovidStatsDataContext context)
        {
            this.context = context;
        }

        [HttpPost]

    }
}
