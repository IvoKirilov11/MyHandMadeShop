namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;

    public interface IItemsTypeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
