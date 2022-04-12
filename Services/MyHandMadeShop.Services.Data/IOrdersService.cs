namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        IEnumerable<T> GetAll<T>();

    }
}
