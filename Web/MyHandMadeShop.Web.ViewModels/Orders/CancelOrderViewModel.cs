namespace MyHandMadeShop.Web.ViewModels.Orders
{
    using AutoMapper;
    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class CancelOrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

    }
}
