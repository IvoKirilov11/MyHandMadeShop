using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Data;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHandMadeShop.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IOrdersService ordersService, UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        public IActionResult Buy()
        {
            string userId = this.userManager.GetUserId(this.User);
            var orders = this.ordersService.GetOrdersByUserId<OrderServiceModel>(userId);
            return this.View(orders);

        }

        [HttpPost]
        public async Task<IActionResult> Buy(OrderServiceModel input)
        {
            var orderItem = await this.ordersService.CreateAsync(input);
            return this.View(orderItem);
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var order = await this.ordersService.GetByIdAsync<CancelOrderViewModel>(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(CancelOrderViewModel input)
        {
            if (!this.ordersService.CheckIfOrderExists(input.Id))
            {
                return this.NotFound();
            }

            await this.ordersService.CancelAsync(input.Id);

            return this.Redirect("/Items/All");
        }
    }
}
