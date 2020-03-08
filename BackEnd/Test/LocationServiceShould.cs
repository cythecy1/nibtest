using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Configuration;
using Data;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class LocationServiceShould
    {
        private IConfiguration _config;
        [OneTimeSetUp]
        public void Setup()
        {
            if(_config == null)
            {
                var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
                _config = configBuilder.Build();
            }

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(_config);
        }

        [Test, Order(1)]
        public void Exists()
        {
            var locationService = new HttpLocationService(_config);
            Assert.IsInstanceOf<HttpLocationService>(locationService);
        }
        [Test, Order(2)]
        public async Task ReturnLocations()
        {
            var locationService = new HttpLocationService(_config);
            var result = await locationService.GetLocationsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<IEnumerable<Location>>(result);
            Assert.That(result.Count(), Is.GreaterThan(0));

            var firstLocation = result.FirstOrDefault();
            Assert.IsNotNull(firstLocation);
            Assert.IsInstanceOf<Location>(firstLocation);

            TestContext.WriteLine($"First {firstLocation.Id} - {firstLocation.Name} - {firstLocation.State}");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public async Task ReturnALocation(int Id)
        {
            var locationService = new HttpLocationService(_config);
            var result = await locationService.GetLocationByIdAsync(Id);
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(Id));

            TestContext.WriteLine($" {result.Id} - {result.Name} - {result.State}");

        }
    }
}