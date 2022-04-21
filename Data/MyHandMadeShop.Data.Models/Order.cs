namespace MyHandMadeShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyHandMadeShop.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Required]
        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
