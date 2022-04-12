namespace MyHandMadeShop.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class OrderNameIdViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
