using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MyHandMadeShop.Web.ViewModels.Items
{
    public class CreateItemsInputModel : BaseItemInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
