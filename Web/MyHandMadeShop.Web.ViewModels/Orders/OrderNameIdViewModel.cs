using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderNameIdViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
