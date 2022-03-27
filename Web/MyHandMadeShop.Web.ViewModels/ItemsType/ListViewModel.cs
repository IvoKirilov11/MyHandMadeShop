using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    public  class ListViewModel
    {
        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
