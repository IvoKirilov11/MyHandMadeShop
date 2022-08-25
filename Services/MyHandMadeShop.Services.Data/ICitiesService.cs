namespace MyHandMadeShop.Services.Data
{
    using MyHandMadeShop.Web.ViewModels.Cities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICitiesService
    {
        Task CreateAsync(CityCreateInputModel cityCreateInputMode);

        Task<IEnumerable<T>> GetByCountryIdAsync<T>(int countryId);

        Task DeleteByCountryIdAsync(int countryId);

        Task<bool> CheckIfCityExistsAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
