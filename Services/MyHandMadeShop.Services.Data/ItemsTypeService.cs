namespace MyHandMadeShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyHandMadeShop.Data.Common.Repositories;
    using MyHandMadeShop.Data.Models;

    public class ItemsTypeService : IItemsTypeService
    {
        private readonly IRepository<ItemType> itemsTypeRepository;

        public ItemsTypeService(IRepository<ItemType> itemsTypeRepository)
        {
            this.itemsTypeRepository = itemsTypeRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.itemsTypeRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
