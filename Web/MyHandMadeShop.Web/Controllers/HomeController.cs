namespace MyHandMadeShop.Web.Controllers
{
    using System.Diagnostics;

    using MyHandMadeShop.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using MyHandMadeShop.Web.ViewModels.ItemsType;
    using MyHandMadeShop.Web.ViewModels.Items;
    using MyHandMadeShop.Services.Data;

    public class HomeController : BaseController
    {
        private readonly IItemsServices itemsService;

        public HomeController(IItemsServices itemsService)
        {
            this.itemsService = itemsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult List(ItemsTypeListInputModel input)
        {
            var viewModel = new ListViewModel
            {

                Items = this.itemsService
                .GetByItemType<ItemsInListViewModel>(input.ItemsTypeId),
            };

            return this.View(viewModel);
        }
    }
}
