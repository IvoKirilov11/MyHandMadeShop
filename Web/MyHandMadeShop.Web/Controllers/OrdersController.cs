namespace MyHandMadeShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyHandMadeShop.Data.Common.Repositories;
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
        private readonly IDeletableEntityRepository<Order> dataRepository;

        public OrdersController(
            IOrdersService ordersService,
            IItemsServices itemsServices,
            IDeletableEntityRepository<Order> dataRepository)
        {
            this.ordersService = ordersService;
            this.itemsServices = itemsServices;
            this.dataRepository = dataRepository;
        }

        [Authorize]
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
