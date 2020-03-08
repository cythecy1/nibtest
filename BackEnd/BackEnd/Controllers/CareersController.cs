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
    public class CareersController : ControllerBase
    {
        private readonly ILogger<CareersController> _logger;
        private readonly ICareerService careerService;

        public CareersController(ILogger<CareersController> logger, ICareerService careerService)
        {
            _logger = logger;
            this.careerService = careerService;
        }

        [HttpGet("byLocation")]
        public IEnumerable<Career> Get(int locationId)
        {
            return careerService.GetCareersByLocation(locationId);
        }
        /** Uncomment if you want to add careers
        [HttpPost]
        public async Task<Career> Post([FromBody]Career career)
        {
            return await careerService.AddCareer(career);
        }
        [HttpPut]
        public async Task<Career> Put([FromBody] Career career)
        {
            return await careerService.UpdateCareer(career);
        }

        [HttpDelete("{careerId}")]
        public async Task<Career> Delete(Guid careerId)
        {
            return await careerService.DeactivateCareer(careerId);
        }
        **/
    }
}
