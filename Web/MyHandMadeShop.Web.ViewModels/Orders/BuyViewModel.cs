using MyHandMadeShop.Web.ViewModels.Items;
using System.Collections.Generic;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class BuyViewModel
    {
        public IEnumerable<OrderNameIdViewModel> Orders { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
