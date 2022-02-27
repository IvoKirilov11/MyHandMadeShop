using MyHandMadeShop.Data.Common.Models;
using System.Collections.Generic;

namespace MyHandMadeShop.Data.Models
{
    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
