namespace MyHandMadeShop.Data.Models
{
    using MyHandMadeShop.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Required]
        public string CustomerId { get; set; }

        public string ItemId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
