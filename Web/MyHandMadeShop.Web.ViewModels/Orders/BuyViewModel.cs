namespace MyHandMadeShop.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    using MyHandMadeShop.Web.ViewModels.Items;

    public class BuyViewModel
    {
        public IEnumerable<OrderNameIdViewModel> Orders { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> Items { get; set; }

    }
}
