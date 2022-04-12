namespace MyHandMadeShop.Web.ViewModels.Items
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateItemsInputModel : BaseItemInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
