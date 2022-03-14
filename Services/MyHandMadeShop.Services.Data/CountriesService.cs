using Microsoft.EntityFrameworkCore;
using MyHandMadeShop.Data.Common.Repositories;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Data.Common;
using MyHandMadeShop.Services.Mapping;
using MyHandMadeShop.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countriesRepository;

        public CountriesService(IDeletableEntityRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<CountryDetailsViewModel> CreateAsync(CountryCreateInputModel countryCreateInputModel)
        {
            var country = new Country
            {
                Name = countryCreateInputModel.Name,
            };

            bool doesCountryExist = await this.countriesRepository.All().AnyAsync(x => x.Name == country.Name);
            if (doesCountryExist)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.CountryAlreadyExists, country.Name));
            }

            await this.countriesRepository.AddAsync(country);
            await this.countriesRepository.SaveChangesAsync();

            var viewModel = await this.GetViewModelByIdAsync<CountryDetailsViewModel>(country.Id);

            return viewModel;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var country = this.countriesRepository.All().FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CountryNotFound, id));
            }

            country.IsDeleted = true;
            country.DeletedOn = DateTime.UtcNow;
            this.countriesRepository.Update(country);
            await this.countriesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(CountryEditViewModel countryEditViewModel)
        {
            var country = this.countriesRepository.All().FirstOrDefault(g => g.Id == countryEditViewModel.Id);

            if (country == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CountryNotFound, countryEditViewModel.Id));
            }

            country.Name = countryEditViewModel.Name;
            country.ModifiedOn = DateTime.UtcNow;

            this.countriesRepository.Update(country);
            await this.countriesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAllCountriesAsync<TViewModel>()
        {
            var countries = await this.countriesRepository
                .All()
                .OrderBy(x => x.Name)
                .To<TViewModel>()
                .ToListAsync();

            return countries;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var countryViewModel = await this.countriesRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (countryViewModel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CountryNotFound, id));
            }

            return countryViewModel;
        }
    }
}
