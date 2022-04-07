using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface IOrdersService
    {
        IEnumerable<T> GetAll<T>();

    }
}
