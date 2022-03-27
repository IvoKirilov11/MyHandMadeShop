using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using MyHandMadeShop.Web.ViewModels.Items;
using System.Collections.Generic;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderServiceModel : IMapFrom<Order>, IMapTo<Order>
    {

        public string CustomerId { get; set; }

        public string CustomerName { get; set; } 

        public IEnumerable<ItemsInListViewModel> Items { get; set; }

    }
}
