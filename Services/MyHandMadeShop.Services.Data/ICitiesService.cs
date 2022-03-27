using MyHandMadeShop.Web.ViewModels.Cities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface ICitiesService
    {
        Task CreateAsync(CityCreateInputModel cityCreateInputMode);


        Task<IEnumerable<T>> GetByCountryIdAsync<T>(int countryId);

        Task<IEnumerable<CityServiceModel>> GetByCountryIdAsync(int countryId);

        Task DeleteByCountryIdAsync(int countryId);

        Task<bool> CheckIfCityExistsAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
