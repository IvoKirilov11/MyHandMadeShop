namespace MyHandMadeShop.Services.Data
{
    using MyHandMadeShop.Web.ViewModels.Orders;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateOrder(string customerId, int orderId);

    }
}
