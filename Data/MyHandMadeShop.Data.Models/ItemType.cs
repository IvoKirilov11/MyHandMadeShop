using System;
using System.Collections.Generic;

namespace MyHandMadeShop.Data.Models
{
    public class ItemType 
    {

        public ItemType()
        {
            Id = Guid.NewGuid().ToString();
            Items = new HashSet<Item>();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
