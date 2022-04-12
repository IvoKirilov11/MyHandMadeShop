namespace MyHandMadeShop.Web.ViewModels.ItemsType
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyHandMadeShop.Web.ViewModels.Items;

    public class ItemTypeIndexViewModel
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<ItemsInListViewModel> ItemsType { get; set; }
    }
}
