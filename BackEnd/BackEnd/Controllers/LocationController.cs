using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<CareersController> _logger;
        private readonly ILocationService locationService;

        public LocationController(ILogger<CareersController> logger, ILocationService locationService)
        {
            _logger = logger;
            this.locationService = locationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Location>> Get()
        {
            return await locationService.GetLocationsAsync();
        }

        [HttpGet("{locationId}")]
        public async Task<Location> Get(int locationId)
        {
            return await locationService.GetLocationByIdAsync(locationId);
        }


    }
}
