namespace MyHandMadeShop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Data;
    using MyHandMadeShop.Web.ViewModels.Items;
    using MyHandMadeShop.Web.ViewModels.ItemsType;
    using MyHandMadeShop.Web.ViewModels.Orders;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IItemsServices itemsServices;

        public OrdersController(IOrdersService ordersService, IItemsServices itemsServices)
        {
            this.ordersService = ordersService;
            this.itemsServices = itemsServices;
        }

        public IActionResult Buy(string input, string itemId)
        {
            var obj = new List<string>();
            var qString = $"{input}/{itemId}";
            obj.Add(qString);
            var items = itemsServices
                .GetByItemType<ItemsInListViewModel>(obj);

            if (items == null)
            {
                return RedirectToAction("Index", "HomeController");
            }

            var viewModel = new BuyViewModel
            {
                Orders = this.ordersService.GetAll<OrderNameIdViewModel>(),
                Items = items,
            };

            return this.View(viewModel);
        }

    }
}
