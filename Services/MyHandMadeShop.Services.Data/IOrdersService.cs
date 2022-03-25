using MyHandMadeShop.Web.ViewModels.Orders;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface IOrdersService
    {
        Task CancelAsync(int id);

        Task<string> CreateAsync(OrderServiceModel input);

        Task CompleteAsync(int id);

        bool CheckIfOrderExists(int id);

        T GetById<T>(int id);

        Task<T> GetByIdAsync<T>(int id);

        IQueryable<T> GetOrdersByUserId<T>(string userId);

       
    }
}
