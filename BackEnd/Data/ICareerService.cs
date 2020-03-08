using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICareerService
    {
        IEnumerable<Career> GetCareersByLocation(int locationId);

        Task<Career> AddCareer(Career career);

        Task<Career> DeactivateCareer(Guid careerId);

        Task<Career> UpdateCareer(Career career);

    }
}
