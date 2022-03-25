using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class OrderServiceModel : IMapFrom<Order>, IMapTo<Order>
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
