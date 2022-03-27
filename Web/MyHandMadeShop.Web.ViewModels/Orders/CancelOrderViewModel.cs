using AutoMapper;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class CancelOrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order,CancelOrderViewModel>();
        }
    }
}
