using MyHandMadeShop.Data.Common.Models;
using System.Collections.Generic;

namespace MyHandMadeShop.Data.Models
{
    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
