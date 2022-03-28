using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}
