using MyHandMadeShop.Web.ViewModels.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface ICountriesService 
    {
        Task<CountryDetailsViewModel> CreateAsync(CountryCreateInputModel countryCreateInputModel);

        Task EditAsync(CountryEditViewModel countryEditViewModel);

        Task<IEnumerable<TEntity>> GetAllCountriesAsync<TEntity>();

        Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id);

        Task DeleteByIdAsync(int id);
    }
}
