using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Data
{
    public class FileBasedCareerService : ICareerService
    {
        private static readonly List<Career> _careers = new List<Career>();
        private string CareerFilePath { get; set; }

        public FileBasedCareerService(string careerFilePath)
        {
            this.CareerFilePath = careerFilePath;
            _ = ReloadCareersJson();
        }


        private async Task ReloadCareersJson()
        {
            await File.ReadAllTextAsync(CareerFilePath).ContinueWith(ant => {
                if(ant.IsFaulted)
                {
                    var e = ant.Exception;
                    //TODO: do something with the exception here
                }
                var ienumCareers = JsonConvert.DeserializeObject<IEnumerable<Career>>(ant.Result);
                _careers.Clear();
                foreach (var career in ienumCareers)
                {
                    _careers.Add(career);
                }
            }, TaskContinuationOptions.ExecuteSynchronously);


        }
        private async Task WriteCareersJson()
        {
            
            var careerString = JsonConvert.SerializeObject(_careers);
            await File.WriteAllTextAsync(CareerFilePath, careerString).ConfigureAwait(true);
        }

        public async Task<Career> AddCareer(Career career)
        {
            var newCareer = new Career()
            {
                Id = Guid.NewGuid(),
                BenefitsDescription = career.BenefitsDescription,
                LocationId = career.LocationId,
                RoleDescription = career.RoleDescription,
                RoleTags = career.RoleTags,
                SkillsDescription = career.SkillsDescription,
                Title = career.Title,
                Active = true
            };
            _careers.Add(newCareer);
            await WriteCareersJson();
            return newCareer;

            
        }

        public async Task<Career> DeactivateCareer(Guid careerId)
        {
            var foundCareer = _careers.Find(f => f.Id.Equals(careerId));
            if(foundCareer != null)
            {
                foundCareer.Active = false;
                await WriteCareersJson();
            }

            return foundCareer;
        }

        public IEnumerable<Career> GetCareersByLocation(int locationId)
        {
            IEnumerable<Career> foundCareers = null;
            if(!_careers.Any())
            {
                var reloadTask = ReloadCareersJson();
                reloadTask.ContinueWith(ant => { 
                    if(!ant.IsFaulted)
                    {
                         foundCareers = _careers.FindAll(b => b.LocationId.Equals(locationId));                        
                    }
                });
            }
            else
            {
                foundCareers = _careers.FindAll(b => b.LocationId.Equals(locationId));
            }
            return foundCareers;


        }

        public async Task<Career> UpdateCareer(Career career)
        {
            _careers.Remove(_careers.FirstOrDefault(f => f.Id.Equals(career.Id)));
            _careers.Add(career);
            await WriteCareersJson();
            return career;
        }
    }
}
