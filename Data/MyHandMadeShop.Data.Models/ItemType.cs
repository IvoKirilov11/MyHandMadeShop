namespace MyHandMadeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyHandMadeShop.Data.Common.Models;

    public class ItemType : BaseDeletableModel<string>
    {

        public ItemType()
        {
            this.Items = new HashSet<Item>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
