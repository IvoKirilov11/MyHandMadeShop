namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;

    public interface IOrdersService
    {
        IEnumerable<T> GetAll<T>();

    }
}
