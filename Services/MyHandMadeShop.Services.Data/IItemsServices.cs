namespace MyHandMadeShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyHandMadeShop.Web.ViewModels.Items;

    public interface IItemsServices
    {
        Task CreateAsync(CreateItemsInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        int GetCount();

        T GetById<T>(int id);

        IEnumerable<T> GetByItemType<T>(IEnumerable<string> itemTypeId);

        Task DeleteAsync(int id);
    }
}
