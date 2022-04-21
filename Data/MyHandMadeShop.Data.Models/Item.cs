namespace MyHandMadeShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MoiteRecepti.Data.Models;
    using MyHandMadeShop.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
