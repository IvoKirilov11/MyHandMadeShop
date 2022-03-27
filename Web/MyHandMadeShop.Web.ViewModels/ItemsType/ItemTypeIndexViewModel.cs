using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    public class ItemTypeIndexViewModel
    {
        public IEnumerable<ItemsInListViewModel> ItemsType { get; set; }
    }
}
