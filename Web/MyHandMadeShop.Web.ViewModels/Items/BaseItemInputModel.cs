namespace MyHandMadeShop.Web.ViewModels.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseItemInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string ItemTypeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ItemType { get; set; }

        public int Quantity { get; set; }
    }
}
