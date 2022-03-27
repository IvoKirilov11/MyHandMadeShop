using Microsoft.EntityFrameworkCore;
using MyHandMadeShop.Data.Common.Repositories;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using MyHandMadeShop.Web.ViewModels.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task<bool> CheckIfCityExistsAsync(int id)
            => await this.citiesRepository.All()
            .Where(c => c.Id == id)
            .CountAsync() > 0;

        public async Task CreateAsync(CityCreateInputModel cityCreateInputMode)
        {
            var city = new City()
            {
                Name = cityCreateInputMode.Name,
            };

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();
        }


        public async Task DeleteByCountryIdAsync(int countryId)
        {
            var cities = this.citiesRepository.All()
                .Where(c => c.CountryId == countryId)
                .ToList();
            foreach (var city in cities)
            {
                this.citiesRepository.Delete(city);
            }

            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.citiesRepository
            .All()
            .To<T>()
            .ToListAsync();

        public async Task<IEnumerable<T>> GetByCountryIdAsync<T>(int countryId)
            => await this.citiesRepository
            .All()
            .Where(c => c.CountryId == countryId)
            .To<T>()
            .ToListAsync();

        public async Task<IEnumerable<CityServiceModel>> GetByCountryIdAsync(int countryId)
        {
            var cities = this.citiesRepository
            .All()
            .Where(c => c.CountryId == countryId);
            var resultCities = await cities.To<CityServiceModel>()
            .ToListAsync();

            return resultCities;
        }

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.citiesRepository.All()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();
    }
}
