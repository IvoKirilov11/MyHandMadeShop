using Microsoft.AspNetCore.Mvc;
using MyHandMadeShop.Services.Data;
using MyHandMadeShop.Web.ViewModels.Countries;
using System.Threading.Tasks;

namespace MyHandMadeShop.Web.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountriesService countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            this.countriesService = countriesService;
            this.countriesService = countriesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateInputModel countryCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(countryCreateInputModel);
            }

            await this.countriesService.CreateAsync(countryCreateInputModel);
            return this.RedirectToAction("All", "Countries", new { area = "Administration" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var countryToEdit = await this.countriesService
                .GetViewModelByIdAsync<CountryEditViewModel>(id);

            return this.View(countryToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryEditViewModel countryEditViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(countryEditViewModel);
            }

            await this.countriesService.EditAsync(countryEditViewModel);
            return this.RedirectToAction("All", "Countries", new { area = "Administration" });
        }

        public async Task<IActionResult> Remove(int id)
        {
            var countryToDelete = await this.countriesService.GetViewModelByIdAsync<CountryDetailsViewModel>(id);
            return this.View(countryToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CountryDetailsViewModel countryDetailsViewModel)
        {
            await this.countriesService.DeleteByIdAsync(countryDetailsViewModel.Id);
            return this.RedirectToAction("All", "Countries", new { area = "Administration" });
        }

        public async Task<IActionResult> GetAll()
        {
            var countries = await this.countriesService.GetAllCountriesAsync<CountryDetailsViewModel>();
            return this.View(countries);
        }
    }
}
