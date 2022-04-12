namespace MyHandMadeShop.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ItemsViewModel : PagingViewModel
    {
        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
