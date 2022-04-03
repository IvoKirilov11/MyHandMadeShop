using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderServiceModel : IMapFrom<Order>
    {
            public int OrderId { get; set; }

            public ICollection<OrderItemModel> OrderItemModels { get; set; }

            [Required]
            public string CustomerId { get; set; }

            public decimal TotalPrice()
            {
                return this.OrderItemModels.Sum(x => x.Price * x.Quantity);
            }
    }
}
