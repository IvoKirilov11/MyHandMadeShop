using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    public class ListViewModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
