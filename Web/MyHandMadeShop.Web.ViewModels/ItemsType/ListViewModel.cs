namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyHandMadeShop.Web.ViewModels.Items;

    public class ListViewModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> Items { get; set; }
    }
}
