using AutoMapper;
using MyHandMadeShop.Data.Models;

namespace MyHandMadeShop.Web.ViewModels.Orders
{
    public class CancelOrderViewModel
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order,CancelOrderViewModel>();
        }
    }
}
