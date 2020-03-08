using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface ILocationService
    {
        
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
    }
}
