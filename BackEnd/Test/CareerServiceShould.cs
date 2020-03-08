using Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;

namespace Test
{
    [TestFixture]
    public class CareerServiceShould
    {
        private ICareerService careerService;

        [SetUp]
        public void SetUp()
        {
            careerService = new FileBasedCareerService("careersJSON.json");
        }

        [Test]
        public void LoadOnInstanceCreation()
        {
            Assert.IsInstanceOf<FileBasedCareerService>(careerService);
        }
        [Test]
        public void AbleToAddNewCareer()
        {
            var returnCareer = careerService.AddCareer(new Career() { 
                Title = "Team Leader",
                LocationId = 5,
                BenefitsDescription = "Benefit 1",
                SkillsDescription = "Skill 2",
                RoleTags = new string[3] {"Powerpoint","Word","Excel"},
                RoleDescription = "Role 3"
            });
            returnCareer.ContinueWith(p => { 
                if(!p.IsFaulted)
                {
                    var readResult = File.ReadAllText("careersJSON.json");
                    var careers = JsonConvert.DeserializeObject<IEnumerable<Career>>(readResult);
                    
                    var addedCareer = careers.FirstOrDefault(p => p.Title == "Team Leader" && p.LocationId == 5);
                    Assert.IsNotNull(addedCareer);
                }
            },TaskContinuationOptions.ExecuteSynchronously);


        }
    }
}
