using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderServiceModel : IMapFrom<Order>
    {

            public int OrderId { get; set; }

            public List<OrderItemModel> OrderItemModels { get; set; }

            public string CustomerId { get; set; }

            public decimal TotalPrice()
            {
                return OrderItemModels.Sum(x => x.Price * x.Quantity);
            }

    }
}
