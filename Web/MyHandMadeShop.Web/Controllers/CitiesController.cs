namespace MyHandMadeShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyHandMadeShop.Services.Data;
    using MyHandMadeShop.Web.ViewModels.Cities;

    public class CitiesController : BaseController
    {
        private readonly ICitiesService cityiesService;

        public CitiesController(ICitiesService cityiesService)
        {
            this.cityiesService = cityiesService;
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
        public async Task<IActionResult> Create(CityCreateInputModel cityCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(cityCreateInputModel);
            }

            await this.cityiesService.CreateAsync(cityCreateInputModel);
            return this.RedirectToAction("All", "Cities");
        }


        public async Task<IActionResult> Remove(int id)
        {
            var countryToDelete = await this.cityiesService.GetByCountryIdAsync<CityDetailsViewModel>(id);
            return this.View(countryToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CityDetailsViewModel cityDetailsViewModel)
        {
            await this.cityiesService.DeleteByCountryIdAsync(cityDetailsViewModel.Id);
            return this.RedirectToAction("All", "Cities");
        }

        public async Task<IActionResult> GetAll()
        {
            var cities = await this.cityiesService.GetAllAsync<CityDetailsViewModel>();
            return this.View(cities);
        }
    }
}
