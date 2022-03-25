using Microsoft.AspNetCore.Mvc;
using MyHandMadeShop.Services.Data;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Threading.Tasks;

namespace MyHandMadeShop.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Buy()
        {
            return this.View();
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
