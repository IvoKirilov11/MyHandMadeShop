using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderItemModel : IMapFrom<Order>
    {
        public int OrderId { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}
