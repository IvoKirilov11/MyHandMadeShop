using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Items
{
    public class ItemsViewModel : PagingViewModel
    {
        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
