namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyHandMadeShop.Web.ViewModels.Countries;

    public interface ICountriesService 
    {
        Task<CountryDetailsViewModel> CreateAsync(CountryCreateInputModel countryCreateInputModel);

        Task EditAsync(CountryEditViewModel countryEditViewModel);

        Task<IEnumerable<TEntity>> GetAllCountriesAsync<TEntity>();

        Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id);

        Task DeleteByIdAsync(int id);
    }
}
