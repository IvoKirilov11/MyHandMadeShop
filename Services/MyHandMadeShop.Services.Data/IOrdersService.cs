using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface IOrdersService
    {
        Task CancelAsync(int id);

        Task<string> CreateAsync(OrderServiceModel input);

        bool CheckIfOrderExists(int id);

        T GetById<T>(int id);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T>GetOrdersByUserId<T>(string userId);

    }
}
