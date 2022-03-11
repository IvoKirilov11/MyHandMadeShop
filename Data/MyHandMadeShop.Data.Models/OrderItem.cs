using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
