namespace MyHandMadeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrderItem
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
