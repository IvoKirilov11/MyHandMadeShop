using System.Collections.Generic;

namespace MyHandMadeShop.Services.Data
{
    public interface IItemsTypeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
