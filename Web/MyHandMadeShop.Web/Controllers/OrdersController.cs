using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Data;
using MyHandMadeShop.Web.ViewModels.Items;
using MyHandMadeShop.Web.ViewModels.ItemsType;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHandMadeShop.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IItemsServices itemsServices;

        public OrdersController(IOrdersService ordersService, UserManager<ApplicationUser> userManager,IItemsServices itemsServices)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
            this.itemsServices = itemsServices;
        }

        public IActionResult Buy(BuyListInputModel input)
        {

            var viewModel = new BuyViewModel
            {
                Orders = this.ordersService.GetAll<OrderNameIdViewModel>(),
                Items = this.itemsServices
                .GetByItemType<ItemsInListViewModel>(input.Orders),
            };
            return this.View(viewModel);

        }

    }
}
