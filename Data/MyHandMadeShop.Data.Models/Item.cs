namespace MyHandMadeShop.Data.Models
{
    using System.Collections.Generic;

    using MoiteRecepti.Data.Models;
    using MyHandMadeShop.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
