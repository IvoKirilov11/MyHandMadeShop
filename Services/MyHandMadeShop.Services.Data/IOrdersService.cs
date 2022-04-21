namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateOrder(string customerId, int orderId);

    }
}
