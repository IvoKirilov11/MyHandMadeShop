using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    public class ItemTypeIndexViewModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> ItemsType { get; set; }
    }
}
